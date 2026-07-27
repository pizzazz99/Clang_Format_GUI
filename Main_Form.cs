using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clang_Format_Gui
{
  public partial class Main_Form : Form
  {
    // -------------------- Settings / state --------------------
    private readonly App_Settings _Settings;
    private readonly List<string> _Scanned_Files = new();
    private readonly List<Custom_Check_Box> _Extension_Check_Boxes = new();

    private bool _Is_Dragging;
    private Point _Drag_Cursor_Start;
    private Point _Drag_Form_Start;

    // The size InitializeComponent lays every control out at — resizing
    // scales everything relative to this baseline, not incrementally
    // from the previous frame, so repeated resizes don't drift.
    private static readonly Size _Base_Client_Size = new(1440, 900);
    private float _Current_Scale_X = 1f;
    private float _Current_Scale_Y = 1f;

    private bool _Is_Busy;
    private string? _Current_Preview_Target;

    private Clang_Format_Target Current_Style_Target =>
      _Style_Target_Combo_Box.SelectedIndex == 0 ? Clang_Format_Target.CSharp : Clang_Format_Target.Cpp;


    public Main_Form()
    {
      _Settings = App_Settings.Load();

      InitializeComponent();

      // Designer-placed extension boxes are collected here so the rest of
      // the code can keep treating them as one list. Drop a new
      // Custom_Check_Box on the left card and add it to this list to
      // support another file extension.
      _Extension_Check_Boxes.AddRange(new[]
      {
        _Cs_Check_Box, _H_Check_Box, _Hpp_Check_Box,
        _Cpp_Check_Box, _Cc_Check_Box, _C_Check_Box
      });

      Apply_Settings_To_Controls();
    }

    // ============================================================
    //  Title bar
    // ============================================================
    private void Help_Button_Click(object? Sender, EventArgs Args)
    {
      using var Dialog = new Help_Form();
      Dialog.ShowDialog(this);
    }

    private void Minimize_Button_Click(object? Sender, EventArgs Args)
    {
      WindowState = FormWindowState.Minimized;
    }

    private void Close_Button_Click(object? Sender, EventArgs Args)
    {
      Close();
    }

    private void Window_Button_Mouse_Enter(object? Sender, EventArgs Args)
    {
      if (Sender is Control Target)
        Target.BackColor = Theme.Surface_Raised;
    }

    private void Window_Button_Mouse_Leave(object? Sender, EventArgs Args)
    {
      if (Sender is Control Target)
        Target.BackColor = Theme.Surface;
    }

    private void Title_Bar_Mouse_Down(object? Sender, MouseEventArgs Args)
    {
      if (Args.Button != MouseButtons.Left) return;
      _Is_Dragging = true;
      _Drag_Cursor_Start = Cursor.Position;
      _Drag_Form_Start = Location;
    }

    private void Title_Bar_Mouse_Move(object? Sender, MouseEventArgs Args)
    {
      if (!_Is_Dragging) return;
      var Current = Cursor.Position;
      Location = new Point(
        _Drag_Form_Start.X + (Current.X - _Drag_Cursor_Start.X),
        _Drag_Form_Start.Y + (Current.Y - _Drag_Cursor_Start.Y));
    }

    private void Title_Bar_Mouse_Up(object? Sender, MouseEventArgs Args)
    {
      _Is_Dragging = false;
    }

    // ============================================================
    //  Borderless-window resize
    // ============================================================
    // FormBorderStyle.None removes the OS resize border along with its
    // chrome, so the standard resize-edge behavior has to be re-created
    // by hand: tell Windows the outer few pixels are non-client resize
    // handles, and it drives the actual drag-resize natively from there.
    private const int _WM_NCHITTEST = 0x0084;
    private const int _HTCLIENT = 1;
    private const int _Resize_Border_Thickness = 6;

    protected override void WndProc(ref Message Msg)
    {
      if (Msg.Msg == _WM_NCHITTEST)
      {
        base.WndProc(ref Msg);
        if ((int)Msg.Result == _HTCLIENT)
        {
          int Packed = (int)(long)Msg.LParam;
          var Screen_Point = new Point((short)(Packed & 0xFFFF), (short)((Packed >> 16) & 0xFFFF));
          var Client_Point = PointToClient(Screen_Point);

          bool On_Left = Client_Point.X <= _Resize_Border_Thickness;
          bool On_Right = Client_Point.X >= ClientSize.Width - _Resize_Border_Thickness;
          bool On_Top = Client_Point.Y <= _Resize_Border_Thickness;
          bool On_Bottom = Client_Point.Y >= ClientSize.Height - _Resize_Border_Thickness;

          if (On_Top && On_Left) Msg.Result = 13;        // HTTOPLEFT
          else if (On_Top && On_Right) Msg.Result = 14;  // HTTOPRIGHT
          else if (On_Bottom && On_Left) Msg.Result = 16;  // HTBOTTOMLEFT
          else if (On_Bottom && On_Right) Msg.Result = 17; // HTBOTTOMRIGHT
          else if (On_Left) Msg.Result = 10;   // HTLEFT
          else if (On_Right) Msg.Result = 11;  // HTRIGHT
          else if (On_Top) Msg.Result = 12;    // HTTOP
          else if (On_Bottom) Msg.Result = 15; // HTBOTTOM
        }
        return;
      }

      base.WndProc(ref Msg);
    }

    // Rescales every control's position, size and font relative to the
    // 1440x900 baseline InitializeComponent lays out, so the whole UI
    // grows/shrinks in proportion as the window is dragged to a new size.
    private void Main_Form_Resize(object? Sender, EventArgs Args)
    {
      if (WindowState != FormWindowState.Normal) return;
      if (ClientSize.Width <= 0 || ClientSize.Height <= 0) return;

      float Target_Scale_X = (float)ClientSize.Width / _Base_Client_Size.Width;
      float Target_Scale_Y = (float)ClientSize.Height / _Base_Client_Size.Height;

      float Delta_X = Target_Scale_X / _Current_Scale_X;
      float Delta_Y = Target_Scale_Y / _Current_Scale_Y;

      if (Math.Abs(Delta_X - 1f) < 0.0005f && Math.Abs(Delta_Y - 1f) < 0.0005f)
        return;

      SuspendLayout();
      _Root_Panel.Scale(new SizeF(Delta_X, Delta_Y));
      ResumeLayout(true);

      _Current_Scale_X = Target_Scale_X;
      _Current_Scale_Y = Target_Scale_Y;
    }

    // ============================================================
    //  Preview
    // ============================================================
    private async void File_List_Selected_Index_Changed(object? Sender, EventArgs Args)
    {
      if (_File_List_Box.SelectedIndices.Count != 1)
      {
        _Preview_File_Name_Label.Text = "PREVIEW — select a single file below";
        _Before_Text_Box.Text = "";
        _After_Text_Box.Text = "";
        _Current_Preview_Target = null;
        _Save_Preview_Button.Enabled = false;
        return;
      }

      int Index = _File_List_Box.SelectedIndex;
      if (Index < 0 || Index >= _Scanned_Files.Count)
        return;

      string Target = _Scanned_Files[Index];
      _Current_Preview_Target = Target;
      _Save_Preview_Button.Enabled = true;
      _Preview_File_Name_Label.Text = "PREVIEW — " + Path.GetFileName(Target);

      try
      {
        _Before_Text_Box.Text = Normalize_Line_Endings(File.ReadAllText(Target));
      }
      catch (Exception Ex)
      {
        _Before_Text_Box.Text = "(could not read file: " + Ex.Message + ")";
      }

      _After_Text_Box.Text = "Formatting preview...";

      string Clang_Path = _Clang_Path_Text_Box.Text.Trim();
      string Style_Path = _Style_Path_Text_Box.Text.Trim();

      var Preview_Result = await Clang_Format_Runner.Preview_File_Async(Clang_Path, Style_Path, Target);

      // The user may have clicked a different file while this was running.
      bool Still_Same_Selection =
        _File_List_Box.SelectedIndex >= 0 &&
        _File_List_Box.SelectedIndex < _Scanned_Files.Count &&
        _Scanned_Files[_File_List_Box.SelectedIndex] == Target;

      if (!Still_Same_Selection)
        return;

      _After_Text_Box.Text = Preview_Result.Succeeded
        ? Normalize_Line_Endings(Preview_Result.Formatted_Text ?? "")
        : "(preview failed: " + Preview_Result.Message + ")";
    }

    private async void Save_Preview_Button_Click(object? Sender, EventArgs Args)
    {
      if (_Current_Preview_Target == null)
        return;

      string Target = _Current_Preview_Target;
      string Clang_Path = _Clang_Path_Text_Box.Text.Trim();
      string Style_Path = _Style_Path_Text_Box.Text.Trim();

      _Save_Preview_Button.Enabled = false;
      Append_Log("Saving " + Path.GetFileName(Target) + " ...", Theme.Info);

      var Result = await Clang_Format_Runner.Format_File_Async(Clang_Path, Style_Path, Target);

      if (Result.Succeeded)
      {
        Append_Log("[OK] " + Path.GetFileName(Target) + " — " + Result.Message, Theme.Success);

        // The file on disk now matches what the After pane already showed —
        // reload Before from disk so both panes agree there's nothing left to apply.
        if (_Current_Preview_Target == Target)
        {
          try
          {
            _Before_Text_Box.Text = Normalize_Line_Endings(File.ReadAllText(Target));
          }
          catch (Exception Ex)
          {
            _Before_Text_Box.Text = "(could not re-read file: " + Ex.Message + ")";
          }
        }
      }
      else
      {
        Append_Log("[FAIL] " + Path.GetFileName(Target) + " — " + Result.Message, Theme.Danger);
      }

      if (_Current_Preview_Target == Target)
        _Save_Preview_Button.Enabled = true;
    }

    // ============================================================
    //  Settings <-> controls
    // ============================================================
    private void Apply_Settings_To_Controls()
    {
      // Fires Style_Target_Combo_Selected_Index_Changed, which sets the
      // extension checkboxes' Enabled/Checked defaults and loads the
      // matching style-file path for that target.
      _Style_Target_Combo_Box.SelectedIndex = _Settings.Style_Target == Clang_Format_Target.CSharp ? 0 : 1;

      _Source_Folder_Text_Box.Text = _Settings.Last_Source_Folder;
      _Clang_Path_Text_Box.Text = _Settings.Clang_Format_Path;
      _Recursive_Check_Box.Checked = _Settings.Recursive_Scan;

      foreach (var Box in _Extension_Check_Boxes.Where(Box => Box.Enabled))
        Box.Checked = _Settings.Selected_Extensions.Contains(Box.Text, StringComparer.OrdinalIgnoreCase);

      Update_Validation_State();
      Append_Log("Ready. Pick a source folder and press Scan Folder.", Theme.Info);
    }

    private void Main_Form_Closing(object? Sender, FormClosingEventArgs Args)
    {
      _Settings.Last_Source_Folder = _Source_Folder_Text_Box.Text;
      _Settings.Clang_Format_Path = _Clang_Path_Text_Box.Text;
      _Settings.Style_Target = Current_Style_Target;
      _Settings.Recursive_Scan = _Recursive_Check_Box.Checked;
      _Settings.Selected_Extensions = _Extension_Check_Boxes
        .Where(Box => Box.Checked)
        .Select(Box => Box.Text)
        .ToArray();

      _Settings.Save();
    }

    // ============================================================
    //  Style target / live validation
    // ============================================================
    private void Style_Target_Combo_Selected_Index_Changed(object? Sender, EventArgs Args)
    {
      var Target = Current_Style_Target;
      var Allowed = Clang_Format_Target_Extensions.Allowed_Extensions[Target];

      foreach (var Box in _Extension_Check_Boxes)
      {
        bool Is_Allowed = Allowed.Contains(Box.Text, StringComparer.OrdinalIgnoreCase);
        Box.Enabled = Is_Allowed;
        Box.Checked = Is_Allowed;
      }

      _Style_Path_Text_Box.Text = Target == Clang_Format_Target.CSharp
        ? _Settings.Style_File_Path_CSharp
        : _Settings.Style_File_Path_Cpp;

      Update_Validation_State();
    }

    private void Style_Path_Text_Changed(object? Sender, EventArgs Args)
    {
      if (Current_Style_Target == Clang_Format_Target.CSharp)
        _Settings.Style_File_Path_CSharp = _Style_Path_Text_Box.Text;
      else
        _Settings.Style_File_Path_Cpp = _Style_Path_Text_Box.Text;

      Update_Validation_State();
    }

    private void Source_Folder_Text_Changed(object? Sender, EventArgs Args)
    {
      Update_Validation_State();
    }

    private void Extension_Or_Recursive_Changed(object? Sender, EventArgs Args)
    {
      Update_Validation_State();
    }

    // Returns null when the current configuration is usable, or an
    // error message describing the first problem found.
    private string? Validate_Configuration()
    {
      var Target = Current_Style_Target;
      string Style_Path = _Style_Path_Text_Box.Text.Trim();

      if (string.IsNullOrWhiteSpace(Style_Path) || !File.Exists(Style_Path))
        return "Select a valid " + Target.Display_Name() + " clang-format style file.";

      string Source_Folder = _Source_Folder_Text_Box.Text.Trim();
      if (string.IsNullOrWhiteSpace(Source_Folder) || !Directory.Exists(Source_Folder))
        return "Select a valid source folder.";

      var Extensions = _Extension_Check_Boxes.Where(Box => Box.Checked).Select(Box => Box.Text).ToList();
      if (Extensions.Count == 0)
        return "Select at least one file type.";

      bool Recursive = _Recursive_Check_Box.Checked;
      if (!Folder_Scanner.Has_Any_Match(Source_Folder, Extensions, Recursive))
        return "This folder has no " + Target.Display_Name() + " files — pick a different folder or style target.";

      return null;
    }

    private void Update_Validation_State()
    {
      string? Error = Validate_Configuration();

      _Config_Error_Label.Text = Error ?? "";
      _Config_Error_Label.Visible = Error != null;

      bool Is_Valid = Error == null;
      _Scan_Button.Enabled = Is_Valid && !_Is_Busy;
      _Format_Button.Enabled = Is_Valid && !_Is_Busy;
    }

    // ============================================================
    //  Browse buttons
    // ============================================================
    private void Browse_Folder_Button_Click(object? Sender, EventArgs Args)
    {
      using var Dialog = new FolderBrowserDialog
      {
        Description = "Select the source folder to scan",
        SelectedPath = Directory.Exists(_Source_Folder_Text_Box.Text) ? _Source_Folder_Text_Box.Text : ""
      };

      if (Dialog.ShowDialog(this) == DialogResult.OK)
        _Source_Folder_Text_Box.Text = Dialog.SelectedPath;
    }

    private void Browse_Clang_Button_Click(object? Sender, EventArgs Args)
    {
      using var Dialog = new OpenFileDialog
      {
        Title = "Locate clang-format.exe",
        Filter = "Executable|*.exe|All files|*.*"
      };

      if (Dialog.ShowDialog(this) == DialogResult.OK)
        _Clang_Path_Text_Box.Text = Dialog.FileName;
    }

    private void Browse_Style_Button_Click(object? Sender, EventArgs Args)
    {
      using var Dialog = new OpenFileDialog
      {
        Title = "Locate " + Current_Style_Target.Display_Name() + " .clang-format style file",
        Filter = "Clang-format style file|*.clang-format|All files|*.*"
      };

      if (Dialog.ShowDialog(this) == DialogResult.OK)
        _Style_Path_Text_Box.Text = Dialog.FileName;
    }

    // Opens the style file with whatever program Windows has associated
    // with it — first use will show the "How do you want to open this
    // file?" picker (e.g. Notepad++), and Windows remembers that choice
    // for next time.
    private void Edit_Style_Button_Click(object? Sender, EventArgs Args)
    {
      string Style_Path = _Style_Path_Text_Box.Text.Trim();

      if (string.IsNullOrWhiteSpace(Style_Path))
      {
        Append_Log("No style file path set to edit.", Theme.Warning);
        return;
      }

      try
      {
        Process.Start(new ProcessStartInfo(Style_Path) { UseShellExecute = true });
      }
      catch (Exception Ex)
      {
        Append_Log("Could not open style file for editing: " + Ex.Message, Theme.Danger);
      }
    }

    // ============================================================
    //  Scan
    // ============================================================
    private async void Scan_Button_Click(object? Sender, EventArgs Args)
    {
      string Source_Folder = _Source_Folder_Text_Box.Text.Trim();

      if (!Directory.Exists(Source_Folder))
      {
        Append_Log("ERROR: source folder does not exist: " + Source_Folder, Theme.Danger);
        return;
      }

      var Extensions = _Extension_Check_Boxes.Where(Box => Box.Checked).Select(Box => Box.Text).ToList();
      if (Extensions.Count == 0)
      {
        Append_Log("ERROR: select at least one file type first.", Theme.Danger);
        return;
      }

      Set_Busy(true, "Scanning...");
      Append_Log("Scanning " + Source_Folder + " ...", Theme.Info);

      _Preview_File_Name_Label.Text = "PREVIEW — select a single file below";
      _Before_Text_Box.Text = "";
      _After_Text_Box.Text = "";

      bool Recursive = _Recursive_Check_Box.Checked;
      var Files = await Task.Run(() => Folder_Scanner.Scan(Source_Folder, Extensions, Recursive));

      _Scanned_Files.Clear();
      _Scanned_Files.AddRange(Files);

      _File_List_Box.Items.Clear();
      foreach (var Full_Path in _Scanned_Files)
      {
        string Relative = Path.GetRelativePath(Source_Folder, Full_Path);
        _File_List_Box.Items.Add(Relative, true);
      }

      _File_Count_Label.Text = "FILES FOUND (" + _Scanned_Files.Count + ")";
      Append_Log("Found " + _Scanned_Files.Count + " file(s).", Theme.Success);

      Set_Busy(false, "Idle");
    }

    private void Select_All_Button_Click(object? Sender, EventArgs Args)
    {
      Set_All_Checked(true);
    }

    private void Select_None_Button_Click(object? Sender, EventArgs Args)
    {
      Set_All_Checked(false);
    }

    private void Set_All_Checked(bool Checked_State)
    {
      for (int I = 0; I < _File_List_Box.Items.Count; I++)
        _File_List_Box.SetItemChecked(I, Checked_State);
    }

    // ============================================================
    //  Format
    // ============================================================
    private async void Format_Button_Click(object? Sender, EventArgs Args)
    {
      var Targets = new List<string>();
      for (int I = 0; I < _File_List_Box.Items.Count; I++)
      {
        if (_File_List_Box.GetItemChecked(I))
          Targets.Add(_Scanned_Files[I]);
      }

      if (Targets.Count == 0)
      {
        Append_Log("Nothing selected — check at least one file.", Theme.Warning);
        return;
      }

      string Clang_Path = _Clang_Path_Text_Box.Text.Trim();
      string Style_Path = _Style_Path_Text_Box.Text.Trim();

      if (!File.Exists(Clang_Path))
      {
        Append_Log("ERROR: clang-format.exe not found at: " + Clang_Path, Theme.Danger);
        return;
      }

      Set_Busy(true, "Formatting...");
      Append_Log("Formatting " + Targets.Count + " file(s)...", Theme.Info);

      int Succeeded = 0;
      int Failed = 0;

      for (int I = 0; I < Targets.Count; I++)
      {
        string Target = Targets[I];
        _Status_Label.Text = "File " + (I + 1) + " of " + Targets.Count;

        var Result = await Clang_Format_Runner.Format_File_Async(Clang_Path, Style_Path, Target);

        if (Result.Succeeded)
        {
          Succeeded++;
          Append_Log("[OK] " + Path.GetFileName(Target) + " — " + Result.Message, Theme.Success);
        }
        else
        {
          Failed++;
          Append_Log("[FAIL] " + Path.GetFileName(Target) + " — " + Result.Message, Theme.Danger);
        }

        _Progress_Bar.Value = (int)((I + 1) * 100.0 / Targets.Count);
      }

      Append_Log(
        "Done: " + Succeeded + " formatted, " + Failed + " failed.",
        Failed == 0 ? Theme.Success : Theme.Warning);

      Set_Busy(false, Succeeded + " ok / " + Failed + " failed");
    }

    // ============================================================
    //  Helpers
    // ============================================================
    private void Set_Busy(bool Is_Busy, string Status_Text)
    {
      _Is_Busy = Is_Busy;
      Update_Validation_State();

      _Select_All_Button.Enabled = !Is_Busy;
      _Select_None_Button.Enabled = !Is_Busy;

      if (!Is_Busy)
        _Progress_Bar.Value = 0;

      _Status_Label.Text = Status_Text;
    }

    // The native Win32 edit control behind TextBox only recognizes "\r\n"
    // as a line break — a bare "\n" (common in C/C++ sources, or clang-format
    // output when the source has Unix line endings) renders as if the whole
    // file were one unbroken line.
    private static string Normalize_Line_Endings(string Text) =>
      Text.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");

    private void Append_Log(string Message, Color Line_Color)
    {
      if (_Console_Text_Box.InvokeRequired)
      {
        _Console_Text_Box.Invoke(new Action(() => Append_Log(Message, Line_Color)));
        return;
      }

      _Console_Text_Box.SelectionStart = _Console_Text_Box.TextLength;
      _Console_Text_Box.SelectionLength = 0;
      _Console_Text_Box.SelectionColor = Line_Color;
      _Console_Text_Box.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + Message + Environment.NewLine);
      _Console_Text_Box.SelectionColor = _Console_Text_Box.ForeColor;
      _Console_Text_Box.ScrollToCaret();
    }
  }
}
