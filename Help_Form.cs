using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clang_Format_Gui
{
  // A plain-chrome modal dialog (unlike Main_Form, this one keeps the
  // OS title bar — a Help window doesn't need custom drag/minimize
  // handling, and borrowing the OS close button is one less thing to
  // hand-roll).
  public sealed class Help_Form : Form
  {
    private static readonly (string Heading, string Body)[] Sections =
    {
      ("Overview",
        "Clang-Format GUI batch-runs clang-format over a folder of source files, " +
        "with a live before/after preview so you can check the result before anything " +
        "on disk changes."),

      ("1. Source folder",
        "Browse to the folder you want to format. \"Include subfolders\" makes the " +
        "scan recursive. \"File types\" controls which extensions are picked up."),

      ("2. clang-format.exe",
        "Point this at your clang-format.exe (installed with LLVM). This path is " +
        "remembered between launches."),

      ("3. Style target",
        "Choose C# or C / C++ from the dropdown. Each target remembers its own " +
        ".clang-format style file, and switching targets automatically enables only " +
        "the matching file-type checkboxes (.cs for C#; .h/.hpp/.cpp/.cc/.c for C/C++) " +
        "— the other set is greyed out so you can't accidentally scan the wrong " +
        "language with the wrong style."),

      ("4. Style file (.clang-format)",
        "Browse to the style file for the currently selected target. Click \"Edit\" " +
        "to open it in whatever program Windows has associated with .clang-format " +
        "files (e.g. Notepad++) — the first time, Windows will ask you to pick one " +
        "and remembers your choice after that."),

      ("Configuration errors",
        "A red message appears above \"Scan Folder\" whenever the current setup can't " +
        "run — missing/invalid style file, missing source folder, no file type " +
        "checked, or (most commonly) the selected folder simply has no files matching " +
        "the current style target. Both \"Scan Folder\" and \"Format Selected Files\" " +
        "stay disabled until the message clears."),

      ("5. Scan Folder",
        "Lists every matching file under the source folder, all checked by default. " +
        "Uncheck anything you don't want touched, or use the All / None shortcuts."),

      ("6. Preview (Before / After)",
        "Click any single file in the list to preview it. \"Before\" is the file exactly " +
        "as it is on disk. \"After\" is generated immediately by running clang-format " +
        "WITHOUT the -i flag — it only captures what clang-format would produce; the " +
        "file on disk is not touched just by previewing it."),

      ("Save This File",
        "Formats only the file currently shown in the preview, in place (-i). Use this " +
        "to apply one file at a time after checking the After pane."),

      ("Format Selected Files",
        "Runs clang-format -i on every checked file in the list, one at a time, logging " +
        "success/failure for each to the console panel at the bottom. If the style file " +
        "can't be found, it falls back to -style=llvm."),

      ("Console & status",
        "The console at the bottom logs every action with a timestamp. The status label " +
        "above it shows Idle / Scanning / Formatting / a running \"file N of M\" count " +
        "while a batch format is in progress."),

      ("Settings",
        "Clang-format.exe path, both style-file paths, style target, last source folder, " +
        "recursive flag and selected file types are all remembered between launches in " +
        "%AppData%\\Clang_Format_Gui\\settings.json."),

      ("Important caveats",
        "• Formatting is destructive like the original batch script — \"-i\" rewrites " +
        "files in place with no in-app undo, so rely on source control/backups.\n" +
        "• The window uses a custom borderless dark UI (drag by the title bar; use " +
        "the — / ✕ buttons to minimize/close) instead of OS chrome, and is a fixed size " +
        "rather than freely resizable.\n" +
        "• Preview text is normalized to CRLF before display, since the Windows edit " +
        "control only recognizes \\r\\n as a line break — files using bare \\n line " +
        "endings would otherwise look like one giant word-wrapped paragraph."),
    };

    public Help_Form()
    {
      Text = "Clang-Format GUI — Help";
      FormBorderStyle = FormBorderStyle.FixedDialog;
      StartPosition = FormStartPosition.CenterParent;
      MaximizeBox = false;
      MinimizeBox = false;
      ShowIcon = false;
      ShowInTaskbar = false;
      ClientSize = new Size(640, 600);
      BackColor = Theme.Background;
      Font = Theme.Font_UI;

      var Close_Button = new Rounded_Button
      {
        Text = "Close",
        Kind = Button_Kind.Primary,
        Dock = DockStyle.Bottom,
        Height = 44,
        Margin = new Padding(16)
      };
      Close_Button.Click += (Sender, Args) => Close();

      var Content_Panel = new Panel
      {
        Dock = DockStyle.Fill,
        Padding = new Padding(16),
        BackColor = Theme.Background
      };

      var Text_Box = new RichTextBox
      {
        Dock = DockStyle.Fill,
        ReadOnly = true,
        BorderStyle = BorderStyle.None,
        BackColor = Theme.Surface,
        ForeColor = Theme.Text_Primary,
        Font = Theme.Font_UI,
        ScrollBars = RichTextBoxScrollBars.Vertical,
        WordWrap = true
      };

      Populate(Text_Box);

      Content_Panel.Controls.Add(Text_Box);

      Controls.Add(Content_Panel);
      Controls.Add(Close_Button);
    }

    private static void Populate(RichTextBox Box)
    {
      foreach (var (Heading, Body) in Sections)
      {
        Box.SelectionFont = Theme.Font_UI_Bold;
        Box.SelectionColor = Theme.Accent;
        Box.AppendText(Heading + Environment.NewLine);

        Box.SelectionFont = Theme.Font_UI;
        Box.SelectionColor = Theme.Text_Primary;
        Box.AppendText(Body + Environment.NewLine + Environment.NewLine);
      }

      Box.SelectionStart = 0;
      Box.SelectionLength = 0;
    }
  }
}
