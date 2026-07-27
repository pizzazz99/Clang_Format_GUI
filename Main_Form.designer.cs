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
    private Panel _Title_Bar = null!;
    private Label _Logo_Label = null!;
    private Label _Title_Label = null!;
    private Label _Subtitle_Label = null!;
    private Panel _Window_Controls_Panel = null!;
    private Label _Help_Button = null!;
    private Label _Minimize_Button = null!;
    private Label _Close_Button = null!;

    // -------------------- Left card --------------------
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
    private Panel _Files_Card = null!;
    private Label _File_Count_Label = null!;
    private Rounded_Button _Select_All_Button = null!;
    private Rounded_Button _Select_None_Button = null!;
    private Panel _List_Border = null!;
    private CheckedListBox _File_List_Box = null!;
    private Rounded_Button _Format_Button = null!;

    // -------------------- Preview card --------------------
    private Panel _Preview_Card = null!;
    private Label _Preview_File_Name_Label = null!;
    private Rounded_Button _Save_Preview_Button = null!;
    private Label _Before_Heading_Label = null!;
    private Panel _Before_Border = null!;
    private TextBox _Before_Text_Box = null!;
    private Label _After_Heading_Label = null!;
    private Panel _After_Border = null!;
    private TextBox _After_Text_Box = null!;

    // -------------------- Console card --------------------
    private Panel _Console_Card = null!;
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
      _Root_Panel = new Panel();
      _Title_Bar = new Panel();
      _Logo_Label = new Label();
      _Title_Label = new Label();
      _Subtitle_Label = new Label();
      _Window_Controls_Panel = new Panel();
      _Help_Button = new Label();
      _Minimize_Button = new Label();
      _Close_Button = new Label();
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
      _Files_Card = new Panel();
      _File_Count_Label = new Label();
      _Select_All_Button = new Rounded_Button();
      _Select_None_Button = new Rounded_Button();
      _List_Border = new Panel();
      _File_List_Box = new CheckedListBox();
      _Format_Button = new Rounded_Button();
      _Preview_Card = new Panel();
      _Preview_File_Name_Label = new Label();
      _Save_Preview_Button = new Rounded_Button();
      _Before_Heading_Label = new Label();
      _Before_Border = new Panel();
      _Before_Text_Box = new TextBox();
      _After_Heading_Label = new Label();
      _After_Border = new Panel();
      _After_Text_Box = new TextBox();
      _Console_Card = new Panel();
      _Console_Label = new Label();
      _Status_Label = new Label();
      _Progress_Bar = new Custom_Progress_Bar();
      _Console_Border = new Panel();
      _Console_Text_Box = new RichTextBox();
      _Root_Panel.SuspendLayout();
      _Title_Bar.SuspendLayout();
      _Window_Controls_Panel.SuspendLayout();
      _Left_Card.SuspendLayout();
      _Files_Card.SuspendLayout();
      _List_Border.SuspendLayout();
      _Preview_Card.SuspendLayout();
      _Before_Border.SuspendLayout();
      _After_Border.SuspendLayout();
      _Console_Card.SuspendLayout();
      _Console_Border.SuspendLayout();
      SuspendLayout();
      // 
      // _Root_Panel
      // 
      _Root_Panel.BackColor = Color.FromArgb(22, 22, 30);
      _Root_Panel.Controls.Add(_Title_Bar);
      _Root_Panel.Controls.Add(_Left_Card);
      _Root_Panel.Controls.Add(_Files_Card);
      _Root_Panel.Controls.Add(_Preview_Card);
      _Root_Panel.Controls.Add(_Console_Card);
      _Root_Panel.Dock = DockStyle.Fill;
      _Root_Panel.Location = new Point(1, 1);
      _Root_Panel.Name = "_Root_Panel";
      _Root_Panel.Size = new Size(1438, 923);
      _Root_Panel.TabIndex = 0;
      // 
      // _Title_Bar
      // 
      _Title_Bar.BackColor = Color.FromArgb(30, 30, 41);
      _Title_Bar.Controls.Add(_Logo_Label);
      _Title_Bar.Controls.Add(_Title_Label);
      _Title_Bar.Controls.Add(_Subtitle_Label);
      _Title_Bar.Controls.Add(_Window_Controls_Panel);
      _Title_Bar.Dock = DockStyle.Top;
      _Title_Bar.Location = new Point(0, 0);
      _Title_Bar.Margin = new Padding(0);
      _Title_Bar.Name = "_Title_Bar";
      _Title_Bar.Size = new Size(1438, 44);
      _Title_Bar.TabIndex = 1;
      _Title_Bar.MouseDown += Title_Bar_Mouse_Down;
      _Title_Bar.MouseMove += Title_Bar_Mouse_Move;
      _Title_Bar.MouseUp += Title_Bar_Mouse_Up;
      // 
      // _Logo_Label
      // 
      _Logo_Label.AutoSize = true;
      _Logo_Label.BackColor = Color.Transparent;
      _Logo_Label.Font = new Font("Consolas", 15F, FontStyle.Bold);
      _Logo_Label.ForeColor = Color.FromArgb(124, 92, 255);
      _Logo_Label.Location = new Point(18, 8);
      _Logo_Label.Name = "_Logo_Label";
      _Logo_Label.Size = new Size(43, 23);
      _Logo_Label.TabIndex = 0;
      _Logo_Label.Text = "{ }";
      _Logo_Label.MouseDown += Title_Bar_Mouse_Down;
      _Logo_Label.MouseMove += Title_Bar_Mouse_Move;
      _Logo_Label.MouseUp += Title_Bar_Mouse_Up;
      // 
      // _Title_Label
      // 
      _Title_Label.AutoSize = true;
      _Title_Label.BackColor = Color.Transparent;
      _Title_Label.Font = new Font("Segoe UI Semibold", 13F);
      _Title_Label.ForeColor = Color.FromArgb(236, 236, 245);
      _Title_Label.Location = new Point(56, 5);
      _Title_Label.Name = "_Title_Label";
      _Title_Label.Size = new Size(186, 25);
      _Title_Label.TabIndex = 1;
      _Title_Label.Text = "CLANG-FORMAT GUI";
      _Title_Label.MouseDown += Title_Bar_Mouse_Down;
      _Title_Label.MouseMove += Title_Bar_Mouse_Move;
      _Title_Label.MouseUp += Title_Bar_Mouse_Up;
      // 
      // _Subtitle_Label
      // 
      _Subtitle_Label.AutoSize = true;
      _Subtitle_Label.BackColor = Color.Transparent;
      _Subtitle_Label.Font = new Font("Segoe UI", 8.5F);
      _Subtitle_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Subtitle_Label.Location = new Point(58, 25);
      _Subtitle_Label.Name = "_Subtitle_Label";
      _Subtitle_Label.Size = new Size(128, 15);
      _Subtitle_Label.TabIndex = 2;
      _Subtitle_Label.Text = "Batch source formatter";
      _Subtitle_Label.MouseDown += Title_Bar_Mouse_Down;
      _Subtitle_Label.MouseMove += Title_Bar_Mouse_Move;
      _Subtitle_Label.MouseUp += Title_Bar_Mouse_Up;
      // 
      // _Window_Controls_Panel
      // 
      _Window_Controls_Panel.BackColor = Color.FromArgb(30, 30, 41);
      _Window_Controls_Panel.Controls.Add(_Help_Button);
      _Window_Controls_Panel.Controls.Add(_Minimize_Button);
      _Window_Controls_Panel.Controls.Add(_Close_Button);
      _Window_Controls_Panel.Dock = DockStyle.Right;
      _Window_Controls_Panel.Location = new Point(1310, 0);
      _Window_Controls_Panel.Name = "_Window_Controls_Panel";
      _Window_Controls_Panel.Size = new Size(128, 44);
      _Window_Controls_Panel.TabIndex = 3;
      // 
      // _Help_Button
      // 
      _Help_Button.BackColor = Color.FromArgb(30, 30, 41);
      _Help_Button.Cursor = Cursors.Hand;
      _Help_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Help_Button.ForeColor = Color.FromArgb(150, 150, 168);
      _Help_Button.Location = new Point(0, 6);
      _Help_Button.Name = "_Help_Button";
      _Help_Button.Size = new Size(36, 32);
      _Help_Button.TabIndex = 0;
      _Help_Button.Text = "?";
      _Help_Button.TextAlign = ContentAlignment.MiddleCenter;
      _Help_Button.Click += Help_Button_Click;
      _Help_Button.MouseEnter += Window_Button_Mouse_Enter;
      _Help_Button.MouseLeave += Window_Button_Mouse_Leave;
      // 
      // _Minimize_Button
      // 
      _Minimize_Button.BackColor = Color.FromArgb(30, 30, 41);
      _Minimize_Button.Cursor = Cursors.Hand;
      _Minimize_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Minimize_Button.ForeColor = Color.FromArgb(150, 150, 168);
      _Minimize_Button.Location = new Point(44, 6);
      _Minimize_Button.Name = "_Minimize_Button";
      _Minimize_Button.Size = new Size(36, 32);
      _Minimize_Button.TabIndex = 1;
      _Minimize_Button.Text = "—";
      _Minimize_Button.TextAlign = ContentAlignment.MiddleCenter;
      _Minimize_Button.Click += Minimize_Button_Click;
      _Minimize_Button.MouseEnter += Window_Button_Mouse_Enter;
      _Minimize_Button.MouseLeave += Window_Button_Mouse_Leave;
      // 
      // _Close_Button
      // 
      _Close_Button.BackColor = Color.FromArgb(30, 30, 41);
      _Close_Button.Cursor = Cursors.Hand;
      _Close_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Close_Button.ForeColor = Color.FromArgb(150, 150, 168);
      _Close_Button.Location = new Point(88, 6);
      _Close_Button.Name = "_Close_Button";
      _Close_Button.Size = new Size(36, 32);
      _Close_Button.TabIndex = 2;
      _Close_Button.Text = "✕";
      _Close_Button.TextAlign = ContentAlignment.MiddleCenter;
      _Close_Button.Click += Close_Button_Click;
      _Close_Button.MouseEnter += Window_Button_Mouse_Enter;
      _Close_Button.MouseLeave += Window_Button_Mouse_Leave;
      // 
      // _Left_Card
      // 
      _Left_Card.AutoScroll = true;
      _Left_Card.BackColor = Color.FromArgb(30, 30, 41);
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
      _Left_Card.Location = new Point(17, 59);
      _Left_Card.Name = "_Left_Card";
      _Left_Card.Size = new Size(340, 866);
      _Left_Card.TabIndex = 0;
      // 
      // _Source_Heading_Label
      // 
      _Source_Heading_Label.AutoSize = true;
      _Source_Heading_Label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Source_Heading_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Source_Heading_Label.Location = new Point(18, 18);
      _Source_Heading_Label.Name = "_Source_Heading_Label";
      _Source_Heading_Label.Size = new Size(110, 17);
      _Source_Heading_Label.TabIndex = 0;
      _Source_Heading_Label.Text = "SOURCE FOLDER";
      // 
      // _Source_Folder_Text_Box
      // 
      _Source_Folder_Text_Box.BackColor = Color.FromArgb(40, 40, 53);
      _Source_Folder_Text_Box.BorderStyle = BorderStyle.FixedSingle;
      _Source_Folder_Text_Box.Font = new Font("Segoe UI", 9.5F);
      _Source_Folder_Text_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Source_Folder_Text_Box.Location = new Point(18, 40);
      _Source_Folder_Text_Box.Name = "_Source_Folder_Text_Box";
      _Source_Folder_Text_Box.Size = new Size(226, 24);
      _Source_Folder_Text_Box.TabIndex = 1;
      _Source_Folder_Text_Box.TextChanged += Source_Folder_Text_Changed;
      // 
      // _Browse_Folder_Button
      // 
      _Browse_Folder_Button.FlatStyle = FlatStyle.Flat;
      _Browse_Folder_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Browse_Folder_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Browse_Folder_Button.Location = new Point(252, 39);
      _Browse_Folder_Button.Name = "_Browse_Folder_Button";
      _Browse_Folder_Button.Size = new Size(70, 30);
      _Browse_Folder_Button.TabIndex = 2;
      _Browse_Folder_Button.Text = "...";
      _Browse_Folder_Button.Click += Browse_Folder_Button_Click;
      // 
      // _Recursive_Check_Box
      // 
      _Recursive_Check_Box.Font = new Font("Segoe UI", 9.5F);
      _Recursive_Check_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Recursive_Check_Box.Location = new Point(18, 80);
      _Recursive_Check_Box.MinimumSize = new Size(0, 22);
      _Recursive_Check_Box.Name = "_Recursive_Check_Box";
      _Recursive_Check_Box.Size = new Size(304, 24);
      _Recursive_Check_Box.TabIndex = 3;
      _Recursive_Check_Box.Text = "Include subfolders";
      _Recursive_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;
      // 
      // _File_Types_Heading_Label
      // 
      _File_Types_Heading_Label.AutoSize = true;
      _File_Types_Heading_Label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _File_Types_Heading_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _File_Types_Heading_Label.Location = new Point(18, 120);
      _File_Types_Heading_Label.Name = "_File_Types_Heading_Label";
      _File_Types_Heading_Label.Size = new Size(75, 17);
      _File_Types_Heading_Label.TabIndex = 4;
      _File_Types_Heading_Label.Text = "FILE TYPES";
      // 
      // _Cs_Check_Box
      // 
      _Cs_Check_Box.Checked = true;
      _Cs_Check_Box.CheckState = CheckState.Checked;
      _Cs_Check_Box.Font = new Font("Segoe UI", 9.5F);
      _Cs_Check_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Cs_Check_Box.Location = new Point(18, 142);
      _Cs_Check_Box.MinimumSize = new Size(0, 22);
      _Cs_Check_Box.Name = "_Cs_Check_Box";
      _Cs_Check_Box.Size = new Size(97, 24);
      _Cs_Check_Box.TabIndex = 5;
      _Cs_Check_Box.Text = ".cs";
      _Cs_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;
      // 
      // _H_Check_Box
      // 
      _H_Check_Box.Checked = true;
      _H_Check_Box.CheckState = CheckState.Checked;
      _H_Check_Box.Font = new Font("Segoe UI", 9.5F);
      _H_Check_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _H_Check_Box.Location = new Point(119, 142);
      _H_Check_Box.MinimumSize = new Size(0, 22);
      _H_Check_Box.Name = "_H_Check_Box";
      _H_Check_Box.Size = new Size(97, 24);
      _H_Check_Box.TabIndex = 6;
      _H_Check_Box.Text = ".h";
      _H_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;
      // 
      // _Hpp_Check_Box
      // 
      _Hpp_Check_Box.Checked = true;
      _Hpp_Check_Box.CheckState = CheckState.Checked;
      _Hpp_Check_Box.Font = new Font("Segoe UI", 9.5F);
      _Hpp_Check_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Hpp_Check_Box.Location = new Point(220, 142);
      _Hpp_Check_Box.MinimumSize = new Size(0, 22);
      _Hpp_Check_Box.Name = "_Hpp_Check_Box";
      _Hpp_Check_Box.Size = new Size(97, 24);
      _Hpp_Check_Box.TabIndex = 7;
      _Hpp_Check_Box.Text = ".hpp";
      _Hpp_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;
      // 
      // _Cpp_Check_Box
      // 
      _Cpp_Check_Box.Checked = true;
      _Cpp_Check_Box.CheckState = CheckState.Checked;
      _Cpp_Check_Box.Font = new Font("Segoe UI", 9.5F);
      _Cpp_Check_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Cpp_Check_Box.Location = new Point(18, 166);
      _Cpp_Check_Box.MinimumSize = new Size(0, 22);
      _Cpp_Check_Box.Name = "_Cpp_Check_Box";
      _Cpp_Check_Box.Size = new Size(97, 24);
      _Cpp_Check_Box.TabIndex = 8;
      _Cpp_Check_Box.Text = ".cpp";
      _Cpp_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;
      // 
      // _Cc_Check_Box
      // 
      _Cc_Check_Box.Checked = true;
      _Cc_Check_Box.CheckState = CheckState.Checked;
      _Cc_Check_Box.Font = new Font("Segoe UI", 9.5F);
      _Cc_Check_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Cc_Check_Box.Location = new Point(119, 166);
      _Cc_Check_Box.MinimumSize = new Size(0, 22);
      _Cc_Check_Box.Name = "_Cc_Check_Box";
      _Cc_Check_Box.Size = new Size(97, 24);
      _Cc_Check_Box.TabIndex = 9;
      _Cc_Check_Box.Text = ".cc";
      _Cc_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;
      // 
      // _C_Check_Box
      // 
      _C_Check_Box.Checked = true;
      _C_Check_Box.CheckState = CheckState.Checked;
      _C_Check_Box.Font = new Font("Segoe UI", 9.5F);
      _C_Check_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _C_Check_Box.Location = new Point(220, 166);
      _C_Check_Box.MinimumSize = new Size(0, 22);
      _C_Check_Box.Name = "_C_Check_Box";
      _C_Check_Box.Size = new Size(97, 24);
      _C_Check_Box.TabIndex = 10;
      _C_Check_Box.Text = ".c";
      _C_Check_Box.CheckedChanged += Extension_Or_Recursive_Changed;
      // 
      // _Clang_Heading_Label
      // 
      _Clang_Heading_Label.AutoSize = true;
      _Clang_Heading_Label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Clang_Heading_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Clang_Heading_Label.Location = new Point(15, 240);
      _Clang_Heading_Label.Name = "_Clang_Heading_Label";
      _Clang_Heading_Label.Size = new Size(194, 17);
      _Clang_Heading_Label.TabIndex = 11;
      _Clang_Heading_Label.Text = "PATH TO CLANG-FORMAT.EXE";
      // 
      // _Clang_Path_Text_Box
      // 
      _Clang_Path_Text_Box.BackColor = Color.FromArgb(40, 40, 53);
      _Clang_Path_Text_Box.BorderStyle = BorderStyle.FixedSingle;
      _Clang_Path_Text_Box.Font = new Font("Segoe UI", 9.5F);
      _Clang_Path_Text_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Clang_Path_Text_Box.Location = new Point(18, 262);
      _Clang_Path_Text_Box.Name = "_Clang_Path_Text_Box";
      _Clang_Path_Text_Box.Size = new Size(304, 24);
      _Clang_Path_Text_Box.TabIndex = 12;
      // 
      // _Browse_Clang_Button
      // 
      _Browse_Clang_Button.FlatStyle = FlatStyle.Flat;
      _Browse_Clang_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Browse_Clang_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Browse_Clang_Button.Location = new Point(18, 292);
      _Browse_Clang_Button.Name = "_Browse_Clang_Button";
      _Browse_Clang_Button.Size = new Size(70, 30);
      _Browse_Clang_Button.TabIndex = 13;
      _Browse_Clang_Button.Text = "...";
      _Browse_Clang_Button.Click += Browse_Clang_Button_Click;
      // 
      // _Style_Target_Heading_Label
      // 
      _Style_Target_Heading_Label.AutoSize = true;
      _Style_Target_Heading_Label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Style_Target_Heading_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Style_Target_Heading_Label.Location = new Point(14, 348);
      _Style_Target_Heading_Label.Name = "_Style_Target_Heading_Label";
      _Style_Target_Heading_Label.Size = new Size(129, 17);
      _Style_Target_Heading_Label.TabIndex = 14;
      _Style_Target_Heading_Label.Text = "TARGET LANGUAGE";
      // 
      // _Style_Target_Combo_Box
      // 
      _Style_Target_Combo_Box.BackColor = Color.FromArgb(40, 40, 53);
      _Style_Target_Combo_Box.DropDownStyle = ComboBoxStyle.DropDownList;
      _Style_Target_Combo_Box.FlatStyle = FlatStyle.Flat;
      _Style_Target_Combo_Box.Font = new Font("Segoe UI", 9.5F);
      _Style_Target_Combo_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Style_Target_Combo_Box.Items.AddRange(new object[] { "C#", "C / C++" });
      _Style_Target_Combo_Box.Location = new Point(18, 370);
      _Style_Target_Combo_Box.Name = "_Style_Target_Combo_Box";
      _Style_Target_Combo_Box.Size = new Size(304, 25);
      _Style_Target_Combo_Box.TabIndex = 15;
      _Style_Target_Combo_Box.SelectedIndexChanged += Style_Target_Combo_Selected_Index_Changed;
      // 
      // _Style_Heading_Label
      // 
      _Style_Heading_Label.AutoSize = true;
      _Style_Heading_Label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Style_Heading_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Style_Heading_Label.Location = new Point(18, 410);
      _Style_Heading_Label.Name = "_Style_Heading_Label";
      _Style_Heading_Label.Size = new Size(245, 17);
      _Style_Heading_Label.TabIndex = 16;
      _Style_Heading_Label.Text = "LANGUAGE STYLE FILE (.clang-format)";
      // 
      // _Style_Path_Text_Box
      // 
      _Style_Path_Text_Box.BackColor = Color.FromArgb(40, 40, 53);
      _Style_Path_Text_Box.BorderStyle = BorderStyle.FixedSingle;
      _Style_Path_Text_Box.Font = new Font("Segoe UI", 9.5F);
      _Style_Path_Text_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Style_Path_Text_Box.Location = new Point(18, 432);
      _Style_Path_Text_Box.Name = "_Style_Path_Text_Box";
      _Style_Path_Text_Box.Size = new Size(304, 24);
      _Style_Path_Text_Box.TabIndex = 17;
      _Style_Path_Text_Box.TextChanged += Style_Path_Text_Changed;
      // 
      // _Browse_Style_Button
      // 
      _Browse_Style_Button.FlatStyle = FlatStyle.Flat;
      _Browse_Style_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Browse_Style_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Browse_Style_Button.Location = new Point(18, 462);
      _Browse_Style_Button.Name = "_Browse_Style_Button";
      _Browse_Style_Button.Size = new Size(58, 30);
      _Browse_Style_Button.TabIndex = 18;
      _Browse_Style_Button.Text = "...";
      _Browse_Style_Button.Click += Browse_Style_Button_Click;
      // 
      // _Edit_Style_Button
      // 
      _Edit_Style_Button.FlatStyle = FlatStyle.Flat;
      _Edit_Style_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Edit_Style_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Edit_Style_Button.Location = new Point(264, 462);
      _Edit_Style_Button.Name = "_Edit_Style_Button";
      _Edit_Style_Button.Size = new Size(58, 30);
      _Edit_Style_Button.TabIndex = 19;
      _Edit_Style_Button.Text = "Edit";
      _Edit_Style_Button.Click += Edit_Style_Button_Click;
      // 
      // _Config_Error_Label
      // 
      _Config_Error_Label.Font = new Font("Segoe UI", 8.5F);
      _Config_Error_Label.ForeColor = Color.FromArgb(237, 108, 108);
      _Config_Error_Label.Location = new Point(18, 507);
      _Config_Error_Label.Name = "_Config_Error_Label";
      _Config_Error_Label.Size = new Size(304, 51);
      _Config_Error_Label.TabIndex = 20;
      _Config_Error_Label.Visible = false;
      // 
      // _Scan_Button
      // 
      _Scan_Button.FlatStyle = FlatStyle.Flat;
      _Scan_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Scan_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Scan_Button.Kind = Button_Kind.Primary;
      _Scan_Button.Location = new Point(13, 595);
      _Scan_Button.Name = "_Scan_Button";
      _Scan_Button.Size = new Size(304, 42);
      _Scan_Button.TabIndex = 21;
      _Scan_Button.Text = "SCAN FOLDER";
      _Scan_Button.Click += Scan_Button_Click;
      // 
      // _Hint_Label
      // 
      _Hint_Label.Font = new Font("Segoe UI", 8.5F);
      _Hint_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Hint_Label.Location = new Point(13, 647);
      _Hint_Label.Name = "_Hint_Label";
      _Hint_Label.Size = new Size(304, 50);
      _Hint_Label.TabIndex = 22;
      _Hint_Label.Text = "Tip: paths and folder are remembered between launches. Click a file below to preview it before/after formatting.";
      // 
      // _Files_Card
      // 
      _Files_Card.BackColor = Color.FromArgb(30, 30, 41);
      _Files_Card.Controls.Add(_File_Count_Label);
      _Files_Card.Controls.Add(_Select_All_Button);
      _Files_Card.Controls.Add(_Select_None_Button);
      _Files_Card.Controls.Add(_List_Border);
      _Files_Card.Controls.Add(_Format_Button);
      _Files_Card.Location = new Point(373, 59);
      _Files_Card.Name = "_Files_Card";
      _Files_Card.Size = new Size(1066, 199);
      _Files_Card.TabIndex = 2;
      // 
      // _File_Count_Label
      // 
      _File_Count_Label.AutoSize = true;
      _File_Count_Label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _File_Count_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _File_Count_Label.Location = new Point(19, 27);
      _File_Count_Label.Name = "_File_Count_Label";
      _File_Count_Label.Size = new Size(111, 17);
      _File_Count_Label.TabIndex = 0;
      _File_Count_Label.Text = "FILES FOUND (0)";
      // 
      // _Select_All_Button
      // 
      _Select_All_Button.FlatStyle = FlatStyle.Flat;
      _Select_All_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Select_All_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Select_All_Button.Location = new Point(903, 19);
      _Select_All_Button.Name = "_Select_All_Button";
      _Select_All_Button.Size = new Size(72, 28);
      _Select_All_Button.TabIndex = 1;
      _Select_All_Button.Text = "All";
      _Select_All_Button.Click += Select_All_Button_Click;
      // 
      // _Select_None_Button
      // 
      _Select_None_Button.FlatStyle = FlatStyle.Flat;
      _Select_None_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Select_None_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Select_None_Button.Location = new Point(975, 19);
      _Select_None_Button.Name = "_Select_None_Button";
      _Select_None_Button.Size = new Size(72, 28);
      _Select_None_Button.TabIndex = 2;
      _Select_None_Button.Text = "None";
      _Select_None_Button.Click += Select_None_Button_Click;
      // 
      // _List_Border
      // 
      _List_Border.BackColor = Color.FromArgb(56, 56, 72);
      _List_Border.Controls.Add(_File_List_Box);
      _List_Border.Location = new Point(16, 54);
      _List_Border.Name = "_List_Border";
      _List_Border.Padding = new Padding(1);
      _List_Border.Size = new Size(1034, 81);
      _List_Border.TabIndex = 3;
      // 
      // _File_List_Box
      // 
      _File_List_Box.BackColor = Color.FromArgb(40, 40, 53);
      _File_List_Box.BorderStyle = BorderStyle.None;
      _File_List_Box.CheckOnClick = true;
      _File_List_Box.Dock = DockStyle.Fill;
      _File_List_Box.Font = new Font("Segoe UI", 9.5F);
      _File_List_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _File_List_Box.IntegralHeight = false;
      _File_List_Box.Location = new Point(1, 1);
      _File_List_Box.Name = "_File_List_Box";
      _File_List_Box.Size = new Size(1032, 79);
      _File_List_Box.TabIndex = 0;
      _File_List_Box.SelectedIndexChanged += File_List_Selected_Index_Changed;
      // 
      // _Format_Button
      // 
      _Format_Button.FlatStyle = FlatStyle.Flat;
      _Format_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Format_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Format_Button.Kind = Button_Kind.Primary;
      _Format_Button.Location = new Point(16, 149);
      _Format_Button.Name = "_Format_Button";
      _Format_Button.Size = new Size(1034, 34);
      _Format_Button.TabIndex = 4;
      _Format_Button.Text = "FORMAT SELECTED FILES";
      _Format_Button.Click += Format_Button_Click;
      // 
      // _Preview_Card
      // 
      _Preview_Card.BackColor = Color.FromArgb(30, 30, 41);
      _Preview_Card.Controls.Add(_Preview_File_Name_Label);
      _Preview_Card.Controls.Add(_Save_Preview_Button);
      _Preview_Card.Controls.Add(_Before_Heading_Label);
      _Preview_Card.Controls.Add(_Before_Border);
      _Preview_Card.Controls.Add(_After_Heading_Label);
      _Preview_Card.Controls.Add(_After_Border);
      _Preview_Card.Location = new Point(373, 269);
      _Preview_Card.Name = "_Preview_Card";
      _Preview_Card.Size = new Size(1066, 495);
      _Preview_Card.TabIndex = 3;
      // 
      // _Preview_File_Name_Label
      // 
      _Preview_File_Name_Label.AutoSize = true;
      _Preview_File_Name_Label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Preview_File_Name_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Preview_File_Name_Label.Location = new Point(19, 23);
      _Preview_File_Name_Label.Name = "_Preview_File_Name_Label";
      _Preview_File_Name_Label.Size = new Size(237, 17);
      _Preview_File_Name_Label.TabIndex = 0;
      _Preview_File_Name_Label.Text = "PREVIEW — select a single file below";
      // 
      // _Save_Preview_Button
      // 
      _Save_Preview_Button.Enabled = false;
      _Save_Preview_Button.FlatStyle = FlatStyle.Flat;
      _Save_Preview_Button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Save_Preview_Button.ForeColor = Color.FromArgb(236, 236, 245);
      _Save_Preview_Button.Kind = Button_Kind.Primary;
      _Save_Preview_Button.Location = new Point(917, 19);
      _Save_Preview_Button.Name = "_Save_Preview_Button";
      _Save_Preview_Button.Size = new Size(130, 28);
      _Save_Preview_Button.TabIndex = 1;
      _Save_Preview_Button.Text = "Save This File";
      _Save_Preview_Button.Click += Save_Preview_Button_Click;
      // 
      // _Before_Heading_Label
      // 
      _Before_Heading_Label.AutoSize = true;
      _Before_Heading_Label.Font = new Font("Segoe UI", 8.5F);
      _Before_Heading_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Before_Heading_Label.Location = new Point(22, 52);
      _Before_Heading_Label.Name = "_Before_Heading_Label";
      _Before_Heading_Label.Size = new Size(48, 15);
      _Before_Heading_Label.TabIndex = 2;
      _Before_Heading_Label.Text = "BEFORE";
      // 
      // _Before_Border
      // 
      _Before_Border.BackColor = Color.FromArgb(56, 56, 72);
      _Before_Border.Controls.Add(_Before_Text_Box);
      _Before_Border.Location = new Point(22, 70);
      _Before_Border.Name = "_Before_Border";
      _Before_Border.Padding = new Padding(1);
      _Before_Border.Size = new Size(500, 403);
      _Before_Border.TabIndex = 3;
      // 
      // _Before_Text_Box
      // 
      _Before_Text_Box.BackColor = Color.FromArgb(14, 14, 20);
      _Before_Text_Box.BorderStyle = BorderStyle.None;
      _Before_Text_Box.Dock = DockStyle.Fill;
      _Before_Text_Box.Font = new Font("Cascadia Mono", 9F);
      _Before_Text_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Before_Text_Box.Location = new Point(1, 1);
      _Before_Text_Box.Multiline = true;
      _Before_Text_Box.Name = "_Before_Text_Box";
      _Before_Text_Box.ReadOnly = true;
      _Before_Text_Box.ScrollBars = ScrollBars.Both;
      _Before_Text_Box.Size = new Size(498, 401);
      _Before_Text_Box.TabIndex = 0;
      _Before_Text_Box.WordWrap = false;
      // 
      // _After_Heading_Label
      // 
      _After_Heading_Label.AutoSize = true;
      _After_Heading_Label.Font = new Font("Segoe UI", 8.5F);
      _After_Heading_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _After_Heading_Label.Location = new Point(544, 52);
      _After_Heading_Label.Name = "_After_Heading_Label";
      _After_Heading_Label.Size = new Size(41, 15);
      _After_Heading_Label.TabIndex = 4;
      _After_Heading_Label.Text = "AFTER";
      // 
      // _After_Border
      // 
      _After_Border.BackColor = Color.FromArgb(56, 56, 72);
      _After_Border.Controls.Add(_After_Text_Box);
      _After_Border.Location = new Point(544, 70);
      _After_Border.Name = "_After_Border";
      _After_Border.Padding = new Padding(1);
      _After_Border.Size = new Size(500, 403);
      _After_Border.TabIndex = 5;
      // 
      // _After_Text_Box
      // 
      _After_Text_Box.BackColor = Color.FromArgb(14, 14, 20);
      _After_Text_Box.BorderStyle = BorderStyle.None;
      _After_Text_Box.Dock = DockStyle.Fill;
      _After_Text_Box.Font = new Font("Cascadia Mono", 9F);
      _After_Text_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _After_Text_Box.Location = new Point(1, 1);
      _After_Text_Box.Multiline = true;
      _After_Text_Box.Name = "_After_Text_Box";
      _After_Text_Box.ReadOnly = true;
      _After_Text_Box.ScrollBars = ScrollBars.Both;
      _After_Text_Box.Size = new Size(498, 401);
      _After_Text_Box.TabIndex = 0;
      _After_Text_Box.WordWrap = false;
      // 
      // _Console_Card
      // 
      _Console_Card.BackColor = Color.FromArgb(30, 30, 41);
      _Console_Card.Controls.Add(_Console_Label);
      _Console_Card.Controls.Add(_Status_Label);
      _Console_Card.Controls.Add(_Progress_Bar);
      _Console_Card.Controls.Add(_Console_Border);
      _Console_Card.Location = new Point(373, 775);
      _Console_Card.Name = "_Console_Card";
      _Console_Card.Size = new Size(1066, 150);
      _Console_Card.TabIndex = 4;
      // 
      // _Console_Label
      // 
      _Console_Label.AutoSize = true;
      _Console_Label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
      _Console_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Console_Label.Location = new Point(19, 23);
      _Console_Label.Name = "_Console_Label";
      _Console_Label.Size = new Size(123, 17);
      _Console_Label.TabIndex = 0;
      _Console_Label.Text = "CONSOLE OUTPUT";
      // 
      // _Status_Label
      // 
      _Status_Label.Font = new Font("Segoe UI", 8.5F);
      _Status_Label.ForeColor = Color.FromArgb(150, 150, 168);
      _Status_Label.Location = new Point(827, 19);
      _Status_Label.Name = "_Status_Label";
      _Status_Label.Size = new Size(220, 20);
      _Status_Label.TabIndex = 1;
      _Status_Label.Text = "Idle";
      _Status_Label.TextAlign = ContentAlignment.MiddleRight;
      // 
      // _Progress_Bar
      // 
      _Progress_Bar.BackColor = Color.FromArgb(40, 40, 53);
      _Progress_Bar.Location = new Point(16, 44);
      _Progress_Bar.Name = "_Progress_Bar";
      _Progress_Bar.Size = new Size(1034, 7);
      _Progress_Bar.TabIndex = 2;
      // 
      // _Console_Border
      // 
      _Console_Border.BackColor = Color.FromArgb(56, 56, 72);
      _Console_Border.Controls.Add(_Console_Text_Box);
      _Console_Border.Location = new Point(16, 61);
      _Console_Border.Name = "_Console_Border";
      _Console_Border.Padding = new Padding(1);
      _Console_Border.Size = new Size(1034, 73);
      _Console_Border.TabIndex = 3;
      // 
      // _Console_Text_Box
      // 
      _Console_Text_Box.BackColor = Color.FromArgb(14, 14, 20);
      _Console_Text_Box.BorderStyle = BorderStyle.None;
      _Console_Text_Box.Dock = DockStyle.Fill;
      _Console_Text_Box.Font = new Font("Cascadia Mono", 9F);
      _Console_Text_Box.ForeColor = Color.FromArgb(236, 236, 245);
      _Console_Text_Box.Location = new Point(1, 1);
      _Console_Text_Box.Name = "_Console_Text_Box";
      _Console_Text_Box.ReadOnly = true;
      _Console_Text_Box.Size = new Size(1032, 71);
      _Console_Text_Box.TabIndex = 0;
      _Console_Text_Box.Text = "";
      _Console_Text_Box.WordWrap = false;
      // 
      // Main_Form
      // 
      AutoScaleMode = AutoScaleMode.None;
      BackColor = Color.FromArgb(56, 56, 72);
      ClientSize = new Size(1440, 925);
      Controls.Add(_Root_Panel);
      Font = new Font("Segoe UI", 9.5F);
      FormBorderStyle = FormBorderStyle.None;
      MinimumSize = new Size(1100, 700);
      Name = "Main_Form";
      Padding = new Padding(1);
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Clang-Format GUI";
      FormClosing += Main_Form_Closing;
      Resize += Main_Form_Resize;
      _Root_Panel.ResumeLayout(false);
      _Title_Bar.ResumeLayout(false);
      _Title_Bar.PerformLayout();
      _Window_Controls_Panel.ResumeLayout(false);
      _Left_Card.ResumeLayout(false);
      _Left_Card.PerformLayout();
      _Files_Card.ResumeLayout(false);
      _Files_Card.PerformLayout();
      _List_Border.ResumeLayout(false);
      _Preview_Card.ResumeLayout(false);
      _Preview_Card.PerformLayout();
      _Before_Border.ResumeLayout(false);
      _Before_Border.PerformLayout();
      _After_Border.ResumeLayout(false);
      _After_Border.PerformLayout();
      _Console_Card.ResumeLayout(false);
      _Console_Card.PerformLayout();
      _Console_Border.ResumeLayout(false);
      ResumeLayout(false);
    }
  }
}
