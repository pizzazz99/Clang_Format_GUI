using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Clang_Format_Gui
{
  partial class Main_Form
  {
    private IContainer components = null!;

    // -------------------- Title bar --------------------
    private Panel _Root_Panel = null!;
    private TableLayoutPanel _Root_Table = null!;
    private Panel _Title_Bar = null!;
    private Label _Logo_Label = null!;
    private Label _Title_Label = null!;
    private Label _Subtitle_Label = null!;
    private Panel _Window_Controls_Panel = null!;
    private Label _Help_Button = null!;
    private Label _Minimize_Button = null!;
    private Label _Close_Button = null!;

    // -------------------- Left card --------------------
    private TableLayoutPanel _Body_Table = null!;
    private Panel _Left_Card = null!;
    private Label _Source_Heading_Label = null!;
    private TextBox _Source_Folder_Text_Box = null!;
    private Rounded_Button _Browse_Folder_Button = null!;
    private Custom_Check_Box _Recursive_Check_Box = null!;
    private Label _File_Types_Heading_Label = null!;
    private Custom_Check_Box _Cs_Check_Box = null!;
    private Custom_Check_Box _H_Check_Box = null!;
    private Custom_Check_Box _Hpp_Check_Box = null!;
    private Custom_Check_Box _Cpp_Check_Box = null!;
    private Custom_Check_Box _Cc_Check_Box = null!;
    private Custom_Check_Box _C_Check_Box = null!;
    private Label _Clang_Heading_Label = null!;
    private TextBox _Clang_Path_Text_Box = null!;
    private Rounded_Button _Browse_Clang_Button = null!;
    private Label _Style_Target_Heading_Label = null!;
    private ComboBox _Style_Target_Combo_Box = null!;
    private Label _Style_Heading_Label = null!;
    private TextBox _Style_Path_Text_Box = null!;
    private Rounded_Button _Browse_Style_Button = null!;
    private Rounded_Button _Edit_Style_Button = null!;
    private Label _Config_Error_Label = null!;
    private Rounded_Button _Scan_Button = null!;
    private Label _Hint_Label = null!;

    // -------------------- Files card --------------------
    private TableLayoutPanel _Right_Table = null!;
    private Panel _Files_Card = null!;
    private TableLayoutPanel _Files_Table = null!;
    private Panel _Files_Header_Panel = null!;
    private Label _File_Count_Label = null!;
    private Rounded_Button _Select_All_Button = null!;
    private Rounded_Button _Select_None_Button = null!;
    private Panel _List_Border = null!;
    private CheckedListBox _File_List_Box = null!;
    private Rounded_Button _Format_Button = null!;

    // -------------------- Preview card --------------------
    private Panel _Preview_Card = null!;
    private TableLayoutPanel _Preview_Table = null!;
    private Panel _Preview_Header_Panel = null!;
    private Label _Preview_File_Name_Label = null!;
    private Rounded_Button _Save_Preview_Button = null!;
    private TableLayoutPanel _Preview_Split_Table = null!;
    private TableLayoutPanel _Before_Pane = null!;
    private Panel _Before_Heading_Wrap = null!;
    private Label _Before_Heading_Label = null!;
    private Panel _Before_Border = null!;
    private TextBox _Before_Text_Box = null!;
    private TableLayoutPanel _After_Pane = null!;
    private Panel _After_Heading_Wrap = null!;
    private Label _After_Heading_Label = null!;
    private Panel _After_Border = null!;
    private TextBox _After_Text_Box = null!;

    // -------------------- Console card --------------------
    private Panel _Console_Card = null!;
    private TableLayoutPanel _Console_Table = null!;
    private Panel _Console_Header_Panel = null!;
    private Label _Console_Label = null!;
    private Label _Status_Label = null!;
    private Custom_Progress_Bar _Progress_Bar = null!;
    private Panel _Console_Border = null!;
    private RichTextBox _Console_Text_Box = null!;

    protected override void Dispose(bool Disposing)
    {
      if (Disposing && components != null)
        components.Dispose();

      base.Dispose(Disposing);
    }

    private void InitializeComponent()
    {
      components = new Container();

      _Root_Panel = new Panel();
      _Root_Table = new TableLayoutPanel();
      _Title_Bar = new Panel();
      _Logo_Label = new Label();
      _Title_Label = new Label();
      _Subtitle_Label = new Label();
      _Window_Controls_Panel = new Panel();
      _Help_Button = new Label();
      _Minimize_Button = new Label();
      _Close_Button = new Label();
      _Body_Table = new TableLayoutPanel();
      _Left_Card = new Panel();
      _Source_Heading_Label = new Label();
      _Source_Folder_Text_Box = new TextBox();
      _Browse_Folder_Button = new Rounded_Button();
      _Recursive_Check_Box = new Custom_Check_Box();
      _File_Types_Heading_Label = new Label();
      _Cs_Check_Box = new Custom_Check_Box();
      _H_Check_Box = new Custom_Check_Box();
      _Hpp_Check_Box = new Custom_Check_Box();
      _Cpp_Check_Box = new Custom_Check_Box();
      _Cc_Check_Box = new Custom_Check_Box();
      _C_Check_Box = new Custom_Check_Box();
      _Clang_Heading_Label = new Label();
      _Clang_Path_Text_Box = new TextBox();
      _Browse_Clang_Button = new Rounded_Button();
      _Style_Target_Heading_Label = new Label();
      _Style_Target_Combo_Box = new ComboBox();
      _Style_Heading_Label = new Label();
      _Style_Path_Text_Box = new TextBox();
      _Browse_Style_Button = new Rounded_Button();
      _Edit_Style_Button = new Rounded_Button();
      _Config_Error_Label = new Label();
      _Scan_Button = new Rounded_Button();
      _Hint_Label = new Label();
      _Right_Table = new TableLayoutPanel();
      _Files_Card = new Panel();
      _Files_Table = new TableLayoutPanel();
      _Files_Header_Panel = new Panel();
      _File_Count_Label = new Label();
      _Select_All_Button = new Rounded_Button();
      _Select_None_Button = new Rounded_Button();
      _List_Border = new Panel();
      _File_List_Box = new CheckedListBox();
      _Format_Button = new Rounded_Button();
      _Preview_Card = new Panel();
      _Preview_Table = new TableLayoutPanel();
      _Preview_Header_Panel = new Panel();
      _Preview_File_Name_Label = new Label();
      _Save_Preview_Button = new Rounded_Button();
      _Preview_Split_Table = new TableLayoutPanel();
      _Before_Pane = new TableLayoutPanel();
      _Before_Heading_Wrap = new Panel();
      _Before_Heading_Label = new Label();
      _Before_Border = new Panel();
      _Before_Text_Box = new TextBox();
      _After_Pane = new TableLayoutPanel();
      _After_Heading_Wrap = new Panel();
      _After_Heading_Label = new Label();
      _After_Border = new Panel();
      _After_Text_Box = new TextBox();
      _Console_Card = new Panel();
      _Console_Table = new TableLayoutPanel();
      _Console_Header_Panel = new Panel();
      _Console_Label = new Label();
      _Status_Label = new Label();
      _Progress_Bar = new Custom_Progress_Bar();
      _Console_Border = new Panel();
      _Console_Text_Box = new RichTextBox();

      SuspendLayout();

      // ==========================================================
      //  _Root_Panel / _Root_Table
      // ==========================================================
      _Root_Panel.Dock = DockStyle.Fill;
      _Root_Panel.BackColor = Theme.Background;
      _Root_Panel.Controls.Add(_Root_Table);

      _Root_Table.Dock = DockStyle.Fill;
      _Root_Table.ColumnCount = 1;
      _Root_Table.RowCount = 2;
      _Root_Table.BackColor = Theme.Background;
      _Root_Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
      _Root_Table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      _Root_Table.Controls.Add(_Title_Bar, 0, 0);
      _Root_Table.Controls.Add(_Body_Table, 0, 1);

      // ==========================================================
      //  Title bar
      // ==========================================================
      _Title_Bar.Dock = DockStyle.Fill;
      _Title_Bar.BackColor = Theme.Surface;
      _Title_Bar.Margin = new Padding(0);
      _Title_Bar.Controls.Add(_Logo_Label);
      _Title_Bar.Controls.Add(_Title_Label);
      _Title_Bar.Controls.Add(_Subtitle_Label);
      _Title_Bar.Controls.Add(_Window_Controls_Panel);
      _Title_Bar.MouseDown += Title_Bar_Mouse_Down;
      _Title_Bar.MouseMove += Title_Bar_Mouse_Move;
      _Title_Bar.MouseUp += Title_Bar_Mouse_Up;

      _Logo_Label.Text = "{ }";
      _Logo_Label.Font = Theme.Font_Logo;
      _Logo_Label.ForeColor = Theme.Accent;
      _Logo_Label.AutoSize = true;
      _Logo_Label.Location = new Point(18, 8);
      _Logo_Label.BackColor = Color.Transparent;
      _Logo_Label.MouseDown += Title_Bar_Mouse_Down;
      _Logo_Label.MouseMove += Title_Bar_Mouse_Move;
      _Logo_Label.MouseUp += Title_Bar_Mouse_Up;

      _Title_Label.Text = "CLANG-FORMAT GUI";
      _Title_Label.Font = Theme.Font_Title;
      _Title_Label.ForeColor = Theme.Text_Primary;
      _Title_Label.AutoSize = true;
      _Title_Label.Location = new Point(56, 5);
      _Title_Label.BackColor = Color.Transparent;
      _Title_Label.MouseDown += Title_Bar_Mouse_Down;
      _Title_Label.MouseMove += Title_Bar_Mouse_Move;
      _Title_Label.MouseUp += Title_Bar_Mouse_Up;

      _Subtitle_Label.Text = "Batch source formatter";
      _Subtitle_Label.Font = Theme.Font_Subtitle;
      _Subtitle_Label.ForeColor = Theme.Text_Secondary;
      _Subtitle_Label.AutoSize = true;
      _Subtitle_Label.Location = new Point(58, 25);
      _Subtitle_Label.BackColor = Color.Transparent;
      _Subtitle_Label.MouseDown += Title_Bar_Mouse_Down;
      _Subtitle_Label.MouseMove += Title_Bar_Mouse_Move;
      _Subtitle_Label.MouseUp += Title_Bar_Mouse_Up;

      _Window_Controls_Panel.Dock = DockStyle.Right;
      _Window_Controls_Panel.Width = 128;
      _Window_Controls_Panel.BackColor = Theme.Surface;
      _Window_Controls_Panel.Controls.Add(_Help_Button);
      _Window_Controls_Panel.Controls.Add(_Minimize_Button);
      _Window_Controls_Panel.Controls.Add(_Close_Button);

      _Help_Button.Text = "?";
      _Help_Button.Font = Theme.Font_UI_Bold;
      _Help_Button.ForeColor = Theme.Text_Secondary;
      _Help_Button.BackColor = Theme.Surface;
      _Help_Button.TextAlign = ContentAlignment.MiddleCenter;
      _Help_Button.Size = new Size(36, 32);
      _Help_Button.Location = new Point(0, 6);
      _Help_Button.Cursor = Cursors.Hand;
      _Help_Button.MouseEnter += Window_Button_Mouse_Enter;
      _Help_Button.MouseLeave += Window_Button_Mouse_Leave;
      _Help_Button.Click += Help_Button_Click;

      _Minimize_Button.Text = "—";
      _Minimize_Button.Font = Theme.Font_UI_Bold;
      _Minimize_Button.ForeColor = Theme.Text_Secondary;
      _Minimize_Button.BackColor = Theme.Surface;
      _Minimize_Button.TextAlign = ContentAlignment.MiddleCenter;
      _Minimize_Button.Size = new Size(36, 32);
      _Minimize_Button.Location = new Point(44, 6);
      _Minimize_Button.Cursor = Cursors.Hand;
      _Minimize_Button.MouseEnter += Window_Button_Mouse_Enter;
      _Minimize_Button.MouseLeave += Window_Button_Mouse_Leave;
      _Minimize_Button.Click += Minimize_Button_Click;

      _Close_Button.Text = "✕";
      _Close_Button.Font = Theme.Font_UI_Bold;
      _Close_Button.ForeColor = Theme.Text_Secondary;
      _Close_Button.BackColor = Theme.Surface;
      _Close_Button.TextAlign = ContentAlignment.MiddleCenter;
      _Close_Button.Size = new Size(36, 32);
      _Close_Button.Location = new Point(88, 6);
      _Close_Button.Cursor = Cursors.Hand;
      _Close_Button.MouseEnter += Window_Button_Mouse_Enter;
      _Close_Button.MouseLeave += Window_Button_Mouse_Leave;
      _Close_Button.Click += Close_Button_Click;

      // ==========================================================
      //  Body
      // ==========================================================
      _Body_Table.Dock = DockStyle.Fill;
      _Body_Table.ColumnCount = 2;
      _Body_Table.RowCount = 1;
      _Body_Table.BackColor = Theme.Background;
      _Body_Table.Padding = new Padding(16);
      _Body_Table.Margin = new Padding(0);
      _Body_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 356F));
      _Body_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      _Body_Table.Controls.Add(_Left_Card, 0, 0);
      _Body_Table.Controls.Add(_Right_Table, 1, 0);

      // ==========================================================
      //  Left card
      // ==========================================================
      _Left_Card.Dock = DockStyle.Fill;
      _Left_Card.BackColor = Theme.Surface;
      _Left_Card.AutoScroll = true;
      _Left_Card.Margin = new Padding(0, 0, 16, 0);
      _Left_Card.Controls.Add(_Source_Heading_Label);
      _Left_Card.Controls.Add(_Source_Folder_Text_Box);
      _Left_Card.Controls.Add(_Browse_Folder_Button);
      _Left_Card.Controls.Add(_Recursive_Check_Box);
      _Left_Card.Controls.Add(_File_Types_Heading_Label);
      _Left_Card.Controls.Add(_Cs_Check_Box);
      _Left_Card.Controls.Add(_H_Check_Box);
      _Left_Card.Controls.Add(_Hpp_Check_Box);
      _Left_Card.Controls.Add(_Cpp_Check_Box);
      _Left_Card.Controls.Add(_Cc_Check_Box);
      _Left_Card.Controls.Add(_C_Check_Box);
      _Left_Card.Controls.Add(_Clang_Heading_Label);
      _Left_Card.Controls.Add(_Clang_Path_Text_Box);
      _Left_Card.Controls.Add(_Browse_Clang_Button);
      _Left_Card.Controls.Add(_Style_Target_Heading_Label);
      _Left_Card.Controls.Add(_Style_Target_Combo_Box);
      _Left_Card.Controls.Add(_Style_Heading_Label);
      _Left_Card.Controls.Add(_Style_Path_Text_Box);
      _Left_Card.Controls.Add(_Browse_Style_Button);
      _Left_Card.Controls.Add(_Edit_Style_Button);
      _Left_Card.Controls.Add(_Config_Error_Label);
      _Left_Card.Controls.Add(_Scan_Button);
      _Left_Card.Controls.Add(_Hint_Label);

      _Source_Heading_Label.Text = "SOURCE FOLDER";
      _Source_Heading_Label.Font = Theme.Font_UI_Bold;
      _Source_Heading_Label.ForeColor = Theme.Text_Secondary;
      _Source_Heading_Label.AutoSize = true;
      _Source_Heading_Label.Location = new Point(18, 18);

      _Source_Folder_Text_Box.BackColor = Theme.Surface_Raised;
      _Source_Folder_Text_Box.ForeColor = Theme.Text_Primary;
      _Source_Folder_Text_Box.BorderStyle = BorderStyle.FixedSingle;
      _Source_Folder_Text_Box.Font = Theme.Font_UI;
      _Source_Folder_Text_Box.Location = new Point(18, 40);
      _Source_Folder_Text_Box.Size = new Size(226, 28);
      _Source_Folder_Text_Box.TextChanged += Source_Folder_Text_Changed;

      _Browse_Folder_Button.Text = "...";
      _Browse_Folder_Button.Kind = Button_Kind.Secondary;
      _Browse_Folder_Button.Location = new Point(252, 39);
      _Browse_Folder_Button.Size = new Size(70, 30);
      _Browse_Folder_Button.Click += Browse_Folder_Button_Click;

      _Recursive_Check_Box.Text = "Include subfolders";
      _Recursive_Check_Box.Location = new Point(18, 80);
      _Recursive_Check_Box.Size = new Size(304, 24);
      _Recursive_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;

      _File_Types_Heading_Label.Text = "FILE TYPES";
      _File_Types_Heading_Label.Font = Theme.Font_UI_Bold;
      _File_Types_Heading_Label.ForeColor = Theme.Text_Secondary;
      _File_Types_Heading_Label.AutoSize = true;
      _File_Types_Heading_Label.Location = new Point(18, 120);

      _Cs_Check_Box.Text = ".cs";
      _Cs_Check_Box.Checked = true;
      _Cs_Check_Box.Location = new Point(18, 142);
      _Cs_Check_Box.Size = new Size(97, 24);
      _Cs_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;

      _H_Check_Box.Text = ".h";
      _H_Check_Box.Checked = true;
      _H_Check_Box.Location = new Point(119, 142);
      _H_Check_Box.Size = new Size(97, 24);
      _H_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;

      _Hpp_Check_Box.Text = ".hpp";
      _Hpp_Check_Box.Checked = true;
      _Hpp_Check_Box.Location = new Point(220, 142);
      _Hpp_Check_Box.Size = new Size(97, 24);
      _Hpp_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;

      _Cpp_Check_Box.Text = ".cpp";
      _Cpp_Check_Box.Checked = true;
      _Cpp_Check_Box.Location = new Point(18, 166);
      _Cpp_Check_Box.Size = new Size(97, 24);
      _Cpp_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;

      _Cc_Check_Box.Text = ".cc";
      _Cc_Check_Box.Checked = true;
      _Cc_Check_Box.Location = new Point(119, 166);
      _Cc_Check_Box.Size = new Size(97, 24);
      _Cc_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;

      _C_Check_Box.Text = ".c";
      _C_Check_Box.Checked = true;
      _C_Check_Box.Location = new Point(220, 166);
      _C_Check_Box.Size = new Size(97, 24);
      _C_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;

      _Clang_Heading_Label.Text = "CLANG-FORMAT.EXE";
      _Clang_Heading_Label.Font = Theme.Font_UI_Bold;
      _Clang_Heading_Label.ForeColor = Theme.Text_Secondary;
      _Clang_Heading_Label.AutoSize = true;
      _Clang_Heading_Label.Location = new Point(18, 206);

      _Clang_Path_Text_Box.BackColor = Theme.Surface_Raised;
      _Clang_Path_Text_Box.ForeColor = Theme.Text_Primary;
      _Clang_Path_Text_Box.BorderStyle = BorderStyle.FixedSingle;
      _Clang_Path_Text_Box.Font = Theme.Font_UI;
      _Clang_Path_Text_Box.Location = new Point(18, 228);
      _Clang_Path_Text_Box.Size = new Size(226, 28);

      _Browse_Clang_Button.Text = "...";
      _Browse_Clang_Button.Kind = Button_Kind.Secondary;
      _Browse_Clang_Button.Location = new Point(252, 227);
      _Browse_Clang_Button.Size = new Size(70, 30);
      _Browse_Clang_Button.Click += Browse_Clang_Button_Click;

      _Style_Target_Heading_Label.Text = "STYLE TARGET";
      _Style_Target_Heading_Label.Font = Theme.Font_UI_Bold;
      _Style_Target_Heading_Label.ForeColor = Theme.Text_Secondary;
      _Style_Target_Heading_Label.AutoSize = true;
      _Style_Target_Heading_Label.Location = new Point(18, 268);

      _Style_Target_Combo_Box.BackColor = Theme.Surface_Raised;
      _Style_Target_Combo_Box.ForeColor = Theme.Text_Primary;
      _Style_Target_Combo_Box.Font = Theme.Font_UI;
      _Style_Target_Combo_Box.FlatStyle = FlatStyle.Flat;
      _Style_Target_Combo_Box.DropDownStyle = ComboBoxStyle.DropDownList;
      _Style_Target_Combo_Box.Location = new Point(18, 290);
      _Style_Target_Combo_Box.Size = new Size(304, 28);
      _Style_Target_Combo_Box.Items.Add("C#");
      _Style_Target_Combo_Box.Items.Add("C / C++");
      _Style_Target_Combo_Box.SelectedIndexChanged += Style_Target_Combo_Selected_Index_Changed;

      _Style_Heading_Label.Text = "STYLE FILE (.clang-format)";
      _Style_Heading_Label.Font = Theme.Font_UI_Bold;
      _Style_Heading_Label.ForeColor = Theme.Text_Secondary;
      _Style_Heading_Label.AutoSize = true;
      _Style_Heading_Label.Location = new Point(18, 330);

      _Style_Path_Text_Box.BackColor = Theme.Surface_Raised;
      _Style_Path_Text_Box.ForeColor = Theme.Text_Primary;
      _Style_Path_Text_Box.BorderStyle = BorderStyle.FixedSingle;
      _Style_Path_Text_Box.Font = Theme.Font_UI;
      _Style_Path_Text_Box.Location = new Point(18, 352);
      _Style_Path_Text_Box.Size = new Size(166, 28);
      _Style_Path_Text_Box.TextChanged += Style_Path_Text_Changed;

      _Browse_Style_Button.Text = "...";
      _Browse_Style_Button.Kind = Button_Kind.Secondary;
      _Browse_Style_Button.Location = new Point(188, 351);
      _Browse_Style_Button.Size = new Size(58, 30);
      _Browse_Style_Button.Click += Browse_Style_Button_Click;

      _Edit_Style_Button.Text = "Edit";
      _Edit_Style_Button.Kind = Button_Kind.Secondary;
      _Edit_Style_Button.Location = new Point(250, 351);
      _Edit_Style_Button.Size = new Size(58, 30);
      _Edit_Style_Button.Click += Edit_Style_Button_Click;

      _Config_Error_Label.Text = "";
      _Config_Error_Label.Font = Theme.Font_Subtitle;
      _Config_Error_Label.ForeColor = Theme.Danger;
      _Config_Error_Label.Location = new Point(18, 390);
      _Config_Error_Label.Size = new Size(304, 44);
      _Config_Error_Label.Visible = false;

      _Scan_Button.Text = "SCAN FOLDER";
      _Scan_Button.Kind = Button_Kind.Primary;
      _Scan_Button.Location = new Point(18, 442);
      _Scan_Button.Size = new Size(304, 42);
      _Scan_Button.Click += Scan_Button_Click;

      _Hint_Label.Text = "Tip: paths and folder are remembered between launches. " +
                         "Click a file below to preview it before/after formatting.";
      _Hint_Label.Font = Theme.Font_Subtitle;
      _Hint_Label.ForeColor = Theme.Text_Secondary;
      _Hint_Label.Location = new Point(18, 494);
      _Hint_Label.Size = new Size(304, 50);

      // ==========================================================
      //  Right side
      // ==========================================================
      _Right_Table.Dock = DockStyle.Fill;
      _Right_Table.ColumnCount = 1;
      _Right_Table.RowCount = 3;
      _Right_Table.BackColor = Theme.Background;
      _Right_Table.Margin = new Padding(0);
      _Right_Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
      _Right_Table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      _Right_Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
      _Right_Table.Controls.Add(_Files_Card, 0, 0);
      _Right_Table.Controls.Add(_Preview_Card, 0, 1);
      _Right_Table.Controls.Add(_Console_Card, 0, 2);

      // -------------------- Files card --------------------
      _Files_Card.Dock = DockStyle.Fill;
      _Files_Card.BackColor = Theme.Surface;
      _Files_Card.Padding = new Padding(16);
      _Files_Card.Margin = new Padding(0, 0, 0, 12);
      _Files_Card.Controls.Add(_Files_Table);

      _Files_Table.Dock = DockStyle.Fill;
      _Files_Table.ColumnCount = 1;
      _Files_Table.RowCount = 3;
      _Files_Table.BackColor = Theme.Surface;
      _Files_Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
      _Files_Table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      _Files_Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
      _Files_Table.Controls.Add(_Files_Header_Panel, 0, 0);
      _Files_Table.Controls.Add(_List_Border, 0, 1);
      _Files_Table.Controls.Add(_Format_Button, 0, 2);

      _Files_Header_Panel.Dock = DockStyle.Fill;
      _Files_Header_Panel.BackColor = Theme.Surface;
      _Files_Header_Panel.Size = new Size(800, 34);
      _Files_Header_Panel.Controls.Add(_File_Count_Label);
      _Files_Header_Panel.Controls.Add(_Select_All_Button);
      _Files_Header_Panel.Controls.Add(_Select_None_Button);

      _File_Count_Label.Text = "FILES FOUND (0)";
      _File_Count_Label.Font = Theme.Font_UI_Bold;
      _File_Count_Label.ForeColor = Theme.Text_Secondary;
      _File_Count_Label.AutoSize = true;
      _File_Count_Label.Location = new Point(0, 8);

      _Select_All_Button.Text = "All";
      _Select_All_Button.Kind = Button_Kind.Secondary;
      _Select_All_Button.Width = 72;
      _Select_All_Button.Dock = DockStyle.Right;
      _Select_All_Button.Margin = new Padding(0, 4, 8, 4);
      _Select_All_Button.Click += Select_All_Button_Click;

      _Select_None_Button.Text = "None";
      _Select_None_Button.Kind = Button_Kind.Secondary;
      _Select_None_Button.Width = 72;
      _Select_None_Button.Dock = DockStyle.Right;
      _Select_None_Button.Margin = new Padding(0, 4, 0, 4);
      _Select_None_Button.Click += Select_None_Button_Click;

      _List_Border.Dock = DockStyle.Fill;
      _List_Border.BackColor = Theme.Border;
      _List_Border.Padding = new Padding(1);
      _List_Border.Margin = new Padding(0, 4, 0, 8);
      _List_Border.Controls.Add(_File_List_Box);

      _File_List_Box.Dock = DockStyle.Fill;
      _File_List_Box.BackColor = Theme.Surface_Raised;
      _File_List_Box.ForeColor = Theme.Text_Primary;
      _File_List_Box.BorderStyle = BorderStyle.None;
      _File_List_Box.Font = Theme.Font_UI;
      _File_List_Box.CheckOnClick = true;
      _File_List_Box.IntegralHeight = false;
      _File_List_Box.SelectionMode = SelectionMode.One;
      _File_List_Box.SelectedIndexChanged += File_List_Selected_Index_Changed;

      _Format_Button.Text = "FORMAT SELECTED FILES";
      _Format_Button.Kind = Button_Kind.Primary;
      _Format_Button.Dock = DockStyle.Fill;
      _Format_Button.Margin = new Padding(0, 6, 0, 0);
      _Format_Button.Click += Format_Button_Click;

      // -------------------- Preview card --------------------
      _Preview_Card.Dock = DockStyle.Fill;
      _Preview_Card.BackColor = Theme.Surface;
      _Preview_Card.Padding = new Padding(16);
      _Preview_Card.Margin = new Padding(0, 0, 0, 12);
      _Preview_Card.Controls.Add(_Preview_Table);

      _Preview_Table.Dock = DockStyle.Fill;
      _Preview_Table.ColumnCount = 1;
      _Preview_Table.RowCount = 2;
      _Preview_Table.BackColor = Theme.Surface;
      _Preview_Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
      _Preview_Table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      _Preview_Table.Controls.Add(_Preview_Header_Panel, 0, 0);
      _Preview_Table.Controls.Add(_Preview_Split_Table, 0, 1);

      _Preview_Header_Panel.Dock = DockStyle.Fill;
      _Preview_Header_Panel.BackColor = Theme.Surface;
      _Preview_Header_Panel.Size = new Size(800, 24);
      _Preview_Header_Panel.Controls.Add(_Preview_File_Name_Label);
      _Preview_Header_Panel.Controls.Add(_Save_Preview_Button);

      _Preview_File_Name_Label.Text = "PREVIEW — select a single file below";
      _Preview_File_Name_Label.Font = Theme.Font_UI_Bold;
      _Preview_File_Name_Label.ForeColor = Theme.Text_Secondary;
      _Preview_File_Name_Label.AutoSize = true;
      _Preview_File_Name_Label.Location = new Point(0, 4);

      _Save_Preview_Button.Text = "Save This File";
      _Save_Preview_Button.Kind = Button_Kind.Primary;
      _Save_Preview_Button.Width = 130;
      _Save_Preview_Button.Dock = DockStyle.Right;
      _Save_Preview_Button.Enabled = false;
      _Save_Preview_Button.Click += Save_Preview_Button_Click;

      _Preview_Split_Table.Dock = DockStyle.Fill;
      _Preview_Split_Table.ColumnCount = 2;
      _Preview_Split_Table.RowCount = 1;
      _Preview_Split_Table.BackColor = Theme.Surface;
      _Preview_Split_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      _Preview_Split_Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      _Preview_Split_Table.Controls.Add(_Before_Pane, 0, 0);
      _Preview_Split_Table.Controls.Add(_After_Pane, 1, 0);

      // Before pane
      _Before_Pane.Dock = DockStyle.Fill;
      _Before_Pane.ColumnCount = 1;
      _Before_Pane.RowCount = 2;
      _Before_Pane.BackColor = Theme.Surface;
      _Before_Pane.Margin = new Padding(0, 6, 8, 0);
      _Before_Pane.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
      _Before_Pane.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      _Before_Pane.Controls.Add(_Before_Heading_Wrap, 0, 0);
      _Before_Pane.Controls.Add(_Before_Border, 0, 1);

      _Before_Heading_Wrap.Dock = DockStyle.Fill;
      _Before_Heading_Wrap.BackColor = Theme.Surface;
      _Before_Heading_Wrap.Controls.Add(_Before_Heading_Label);

      _Before_Heading_Label.Text = "BEFORE";
      _Before_Heading_Label.Font = Theme.Font_Subtitle;
      _Before_Heading_Label.ForeColor = Theme.Text_Secondary;
      _Before_Heading_Label.AutoSize = true;
      _Before_Heading_Label.Location = new Point(0, 0);

      _Before_Border.Dock = DockStyle.Fill;
      _Before_Border.BackColor = Theme.Border;
      _Before_Border.Padding = new Padding(1);
      _Before_Border.Controls.Add(_Before_Text_Box);

      _Before_Text_Box.Dock = DockStyle.Fill;
      _Before_Text_Box.Multiline = true;
      _Before_Text_Box.ReadOnly = true;
      _Before_Text_Box.WordWrap = false;
      _Before_Text_Box.ScrollBars = ScrollBars.Both;
      _Before_Text_Box.BackColor = Color.FromArgb(14, 14, 20);
      _Before_Text_Box.ForeColor = Theme.Text_Primary;
      _Before_Text_Box.Font = Theme.Font_Mono;
      _Before_Text_Box.BorderStyle = BorderStyle.None;

      // After pane
      _After_Pane.Dock = DockStyle.Fill;
      _After_Pane.ColumnCount = 1;
      _After_Pane.RowCount = 2;
      _After_Pane.BackColor = Theme.Surface;
      _After_Pane.Margin = new Padding(8, 6, 0, 0);
      _After_Pane.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
      _After_Pane.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      _After_Pane.Controls.Add(_After_Heading_Wrap, 0, 0);
      _After_Pane.Controls.Add(_After_Border, 0, 1);

      _After_Heading_Wrap.Dock = DockStyle.Fill;
      _After_Heading_Wrap.BackColor = Theme.Surface;
      _After_Heading_Wrap.Controls.Add(_After_Heading_Label);

      _After_Heading_Label.Text = "AFTER";
      _After_Heading_Label.Font = Theme.Font_Subtitle;
      _After_Heading_Label.ForeColor = Theme.Text_Secondary;
      _After_Heading_Label.AutoSize = true;
      _After_Heading_Label.Location = new Point(0, 0);

      _After_Border.Dock = DockStyle.Fill;
      _After_Border.BackColor = Theme.Border;
      _After_Border.Padding = new Padding(1);
      _After_Border.Controls.Add(_After_Text_Box);

      _After_Text_Box.Dock = DockStyle.Fill;
      _After_Text_Box.Multiline = true;
      _After_Text_Box.ReadOnly = true;
      _After_Text_Box.WordWrap = false;
      _After_Text_Box.ScrollBars = ScrollBars.Both;
      _After_Text_Box.BackColor = Color.FromArgb(14, 14, 20);
      _After_Text_Box.ForeColor = Theme.Text_Primary;
      _After_Text_Box.Font = Theme.Font_Mono;
      _After_Text_Box.BorderStyle = BorderStyle.None;

      // -------------------- Console card --------------------
      _Console_Card.Dock = DockStyle.Fill;
      _Console_Card.BackColor = Theme.Surface;
      _Console_Card.Padding = new Padding(16);
      _Console_Card.Margin = new Padding(0);
      _Console_Card.Controls.Add(_Console_Table);

      _Console_Table.Dock = DockStyle.Fill;
      _Console_Table.ColumnCount = 1;
      _Console_Table.RowCount = 3;
      _Console_Table.BackColor = Theme.Surface;
      _Console_Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
      _Console_Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
      _Console_Table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      _Console_Table.Controls.Add(_Console_Header_Panel, 0, 0);
      _Console_Table.Controls.Add(_Progress_Bar, 0, 1);
      _Console_Table.Controls.Add(_Console_Border, 0, 2);

      _Console_Header_Panel.Dock = DockStyle.Fill;
      _Console_Header_Panel.BackColor = Theme.Surface;
      _Console_Header_Panel.Size = new Size(800, 26);
      _Console_Header_Panel.Controls.Add(_Console_Label);
      _Console_Header_Panel.Controls.Add(_Status_Label);

      _Console_Label.Text = "CONSOLE OUTPUT";
      _Console_Label.Font = Theme.Font_UI_Bold;
      _Console_Label.ForeColor = Theme.Text_Secondary;
      _Console_Label.AutoSize = true;
      _Console_Label.Location = new Point(0, 4);

      _Status_Label.Text = "Idle";
      _Status_Label.Font = Theme.Font_Subtitle;
      _Status_Label.ForeColor = Theme.Text_Secondary;
      _Status_Label.AutoSize = false;
      _Status_Label.TextAlign = ContentAlignment.MiddleRight;
      _Status_Label.Width = 220;
      _Status_Label.Dock = DockStyle.Right;

      _Progress_Bar.Dock = DockStyle.Fill;
      _Progress_Bar.Margin = new Padding(0, 2, 0, 2);

      _Console_Border.Dock = DockStyle.Fill;
      _Console_Border.BackColor = Theme.Border;
      _Console_Border.Padding = new Padding(1);
      _Console_Border.Margin = new Padding(0, 8, 0, 0);
      _Console_Border.Controls.Add(_Console_Text_Box);

      _Console_Text_Box.Dock = DockStyle.Fill;
      _Console_Text_Box.BackColor = Color.FromArgb(14, 14, 20);
      _Console_Text_Box.ForeColor = Theme.Text_Primary;
      _Console_Text_Box.Font = Theme.Font_Mono;
      _Console_Text_Box.BorderStyle = BorderStyle.None;
      _Console_Text_Box.ReadOnly = true;
      _Console_Text_Box.WordWrap = false;
      _Console_Text_Box.ScrollBars = RichTextBoxScrollBars.Both;

      // ==========================================================
      //  Form
      // ==========================================================
      AutoScaleMode = AutoScaleMode.None;
      FormBorderStyle = FormBorderStyle.None;
      BackColor = Theme.Border;
      Padding = new Padding(1);
      ClientSize = new Size(1440, 900);
      StartPosition = FormStartPosition.CenterScreen;
      Font = Theme.Font_UI;
      Text = "Clang-Format GUI";
      Name = "Main_Form";
      Controls.Add(_Root_Panel);
      FormClosing += Main_Form_Closing;

      ResumeLayout(false);
    }
  }
}
