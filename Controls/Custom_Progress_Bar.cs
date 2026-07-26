using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clang_Format_Gui
{
  // A thin gradient progress bar — the stock ProgressBar renders a
  // bright OS-themed block that clashes badly with a dark UI.
  public sealed class Custom_Progress_Bar : Control
  {
    private int _Value;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(0)]
    [Category("Behavior")]
    public int Value
    {
      get => _Value;
      set
      {
        _Value = Math.Max(0, Math.Min(100, value));
        Invalidate();
      }
    }

    public Custom_Progress_Bar()
    {
      SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
      Height = 6;
      BackColor = Theme.Surface_Raised;
    }

    protected override void OnPaint(PaintEventArgs Args)
    {
      var Canvas = Args.Graphics;
      Canvas.SmoothingMode = SmoothingMode.AntiAlias;

      using (var Track_Brush = new SolidBrush(Theme.Surface_Raised))
        Canvas.FillRectangle(Track_Brush, ClientRectangle);

      if (_Value <= 0 || Width <= 0)
        return;

      int Fill_Width = Math.Max(1, (int) (Width * (_Value / 100.0)));
      var Fill_Rect = new Rectangle(0, 0, Fill_Width, Math.Max(1, Height));
      var Gradient_Rect = new Rectangle(0, 0, Fill_Width + 1, Math.Max(1, Height));

      using var Fill_Brush = new LinearGradientBrush(
        Gradient_Rect, Theme.Accent, Theme.Accent_Hover, LinearGradientMode.Horizontal);
      Canvas.FillRectangle(Fill_Brush, Fill_Rect);
    }
  }
}
