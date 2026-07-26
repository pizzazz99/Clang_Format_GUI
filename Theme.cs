using System;
using System.Drawing;

namespace Clang_Format_Gui
{
  // Central palette + fonts so every control shares one look.
  internal static class Theme
  {
    public static readonly Color Background    = Color.FromArgb(22, 22, 30);
    public static readonly Color Surface        = Color.FromArgb(30, 30, 41);
    public static readonly Color Surface_Raised = Color.FromArgb(40, 40, 53);
    public static readonly Color Border         = Color.FromArgb(56, 56, 72);

    public static readonly Color Text_Primary   = Color.FromArgb(236, 236, 245);
    public static readonly Color Text_Secondary = Color.FromArgb(150, 150, 168);

    public static readonly Color Accent         = Color.FromArgb(124, 92, 255);
    public static readonly Color Accent_Hover   = Color.FromArgb(146, 118, 255);
    public static readonly Color Accent_Pressed = Color.FromArgb(102, 72, 226);

    public static readonly Color Success        = Color.FromArgb(88, 214, 145);
    public static readonly Color Warning        = Color.FromArgb(245, 199, 87);
    public static readonly Color Danger         = Color.FromArgb(237, 108, 108);
    public static readonly Color Info           = Color.FromArgb(120, 170, 255);

    public static readonly Font Font_UI       = Safe_Font("Segoe UI", 9.5f, FontStyle.Regular);
    public static readonly Font Font_UI_Bold  = Safe_Font("Segoe UI", 9.5f, FontStyle.Bold);
    public static readonly Font Font_Title    = Safe_Font("Segoe UI Semibold", 13f, FontStyle.Regular);
    public static readonly Font Font_Subtitle = Safe_Font("Segoe UI", 8.5f, FontStyle.Regular);
    public static readonly Font Font_Mono     = Safe_Font("Cascadia Mono", 9f, FontStyle.Regular, "Consolas");
    public static readonly Font Font_Logo     = Safe_Font("Consolas", 15f, FontStyle.Bold);

    // Some of the fancier fonts (Cascadia Mono, Segoe UI Semibold) are not
    // guaranteed to exist on every machine — fall back gracefully instead
    // of throwing at startup.
    private static Font Safe_Font(string Name, float Size, FontStyle Style, string Fallback = "Segoe UI")
    {
      try
      {
        var Candidate = new Font(Name, Size, Style);
        if (string.Equals(Candidate.Name, Name, StringComparison.OrdinalIgnoreCase))
          return Candidate;

        Candidate.Dispose();
        return new Font(Fallback, Size, Style);
      }
      catch
      {
        return new Font(Fallback, Size, Style);
      }
    }
  }
}
