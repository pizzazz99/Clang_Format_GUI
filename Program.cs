using System;
using System.Windows.Forms;

namespace Clang_Format_Gui
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      ApplicationConfiguration.Initialize();
      Application.Run(new Main_Form());
    }
  }
}
