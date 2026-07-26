using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;


namespace Clang_Format_Gui
{
  public enum Button_Kind
  {
    Primary,
    Secondary,
    Danger
  }


 


  // A flat, rounded-corner button drawn entirely with GDI+ so it can
  // sit naturally on a dark background instead of the default OS chrome.
  public sealed class Rounded_Button : Button
  {

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(8)]
    [Category("Appearance")]
    public int Corner_Radius { get; set; } = 8;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(Button_Kind.Secondary)]
    [Category("Appearance")]
    public Button_Kind Kind { get; set; } = Button_Kind.Secondary;

    private bool _Is_Hovered;
    private bool _Is_Pressed;

    public Rounded_Button()
    {
      SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
      FlatStyle = FlatStyle.Flat;
      FlatAppearance.BorderSize = 0;
      Font = Theme.Font_UI_Bold;
      ForeColor = Theme.Text_Primary;
      Cursor = Cursors.Hand;
      Height = 36;
    }

    protected override void OnMouseEnter(EventArgs Args)
    {
      base.OnMouseEnter(Args);
      _Is_Hovered = true;
      Invalidate();
    }

    protected override void OnMouseLeave(EventArgs Args)
    {
      base.OnMouseLeave(Args);
      _Is_Hovered = false;
      _Is_Pressed = false;
      Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs Args)
    {
      base.OnMouseDown(Args);
      _Is_Pressed = true;
      Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs Args)
    {
      base.OnMouseUp(Args);
      _Is_Pressed = false;
      Invalidate();
    }

    protected override void OnPaint(PaintEventArgs Args)
    {
      var Canvas = Args.Graphics;
      Canvas.SmoothingMode = SmoothingMode.AntiAlias;

      Color Base_Color = Kind switch
      {
        Button_Kind.Primary => Theme.Accent,
        Button_Kind.Danger => Theme.Danger,
        _ => Theme.Surface_Raised
      };

      Color Fill_Color =
        !Enabled ? Darken(Base_Color, 0.35f) :
        _Is_Pressed ? Darken(Base_Color, 0.15f) :
        _Is_Hovered ? Lighten(Base_Color, 0.12f) :
        Base_Color;

      using var Path = Rounded_Rect(ClientRectangle, Corner_Radius);
      using (var Brush = new SolidBrush(Fill_Color))
        Canvas.FillPath(Brush, Path);

      if (Kind == Button_Kind.Secondary)
      {
        using var Pen = new Pen(Theme.Border, 1f);
        Canvas.DrawPath(Pen, Path);
      }

      TextRenderer.DrawText(
        Canvas,
        Text,
        Font,
        ClientRectangle,
        Enabled ? Theme.Text_Primary : Theme.Text_Secondary,
        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private static GraphicsPath Rounded_Rect(Rectangle Bounds, int Radius)
    {
      var Path = new GraphicsPath();
      int Diameter = Radius * 2;

      var Rect = new Rectangle(Bounds.X, Bounds.Y, Math.Max(Bounds.Width - 1, Diameter), Math.Max(Bounds.Height - 1, Diameter));

      Path.AddArc(Rect.X, Rect.Y, Diameter, Diameter, 180, 90);
      Path.AddArc(Rect.Right - Diameter, Rect.Y, Diameter, Diameter, 270, 90);
      Path.AddArc(Rect.Right - Diameter, Rect.Bottom - Diameter, Diameter, Diameter, 0, 90);
      Path.AddArc(Rect.X, Rect.Bottom - Diameter, Diameter, Diameter, 90, 90);
      Path.CloseFigure();
      return Path;
    }

    private static Color Lighten(Color Source, float Amount)
    {
      return Color.FromArgb(
        Source.A,
        (int) Math.Min(255, Source.R + (255 - Source.R) * Amount),
        (int) Math.Min(255, Source.G + (255 - Source.G) * Amount),
        (int) Math.Min(255, Source.B + (255 - Source.B) * Amount));
    }

    private static Color Darken(Color Source, float Amount)
    {
      return Color.FromArgb(
        Source.A,
        (int) Math.Max(0, Source.R * (1 - Amount)),
        (int) Math.Max(0, Source.G * (1 - Amount)),
        (int) Math.Max(0, Source.B * (1 - Amount)));
    }
  }
}
