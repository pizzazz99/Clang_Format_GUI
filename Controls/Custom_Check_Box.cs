using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clang_Format_Gui
{
  // The stock CheckBox always paints an OS-themed (light) glyph box,
  // which looks wrong on a dark background — so this draws its own.
  public sealed class Custom_Check_Box : CheckBox
  {
    private const int Box_Size = 16;

    public Custom_Check_Box()
    {
      SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
      Font = Theme.Font_UI;
      ForeColor = Theme.Text_Primary;
      Cursor = Cursors.Hand;
      MinimumSize = new Size(0, 22);
      AutoSize = false;
    }

    protected override void OnCheckedChanged(System.EventArgs Args)
    {
      base.OnCheckedChanged(Args);
      Invalidate();
    }

    protected override void OnPaint(PaintEventArgs Args)
    {
      var Canvas = Args.Graphics;
      Canvas.SmoothingMode = SmoothingMode.AntiAlias;
      Canvas.Clear(Parent?.BackColor ?? Theme.Surface);

      int Box_Top = (Height - Box_Size) / 2;
      var Box_Rect = new Rectangle(0, Box_Top, Box_Size, Box_Size);

      using (var Path = Rounded_Rect(Box_Rect, 4))
      {
        using (var Fill_Brush = new SolidBrush(Checked ? Theme.Accent : Theme.Surface_Raised))
          Canvas.FillPath(Fill_Brush, Path);

        if (!Checked)
        {
          using var Border_Pen = new Pen(Theme.Border, 1.2f);
          Canvas.DrawPath(Border_Pen, Path);
        }
      }

      if (Checked)
      {
        using var Check_Pen = new Pen(Color.White, 2f)
        {
          StartCap = LineCap.Round,
          EndCap = LineCap.Round,
          LineJoin = LineJoin.Round
        };

        Canvas.DrawLines(Check_Pen, new[]
        {
          new Point(Box_Rect.X + 3, Box_Rect.Y + 8),
          new Point(Box_Rect.X + 6, Box_Rect.Y + 11),
          new Point(Box_Rect.X + 13, Box_Rect.Y + 4)
        });
      }

      var Text_Rect = new Rectangle(Box_Size + 8, 0, Width - Box_Size - 8, Height);
      TextRenderer.DrawText(
        Canvas,
        Text,
        Font,
        Text_Rect,
        Enabled ? ForeColor : Theme.Text_Secondary,
        TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
    }

    private static GraphicsPath Rounded_Rect(Rectangle Bounds, int Radius)
    {
      var Path = new GraphicsPath();
      int Diameter = Radius * 2;

      Path.AddArc(Bounds.X, Bounds.Y, Diameter, Diameter, 180, 90);
      Path.AddArc(Bounds.Right - Diameter, Bounds.Y, Diameter, Diameter, 270, 90);
      Path.AddArc(Bounds.Right - Diameter, Bounds.Bottom - Diameter, Diameter, Diameter, 0, 90);
      Path.AddArc(Bounds.X, Bounds.Bottom - Diameter, Diameter, Diameter, 90, 90);
      Path.CloseFigure();
      return Path;
    }
  }
}
