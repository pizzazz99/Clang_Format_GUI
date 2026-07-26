using System;
using System.IO;
using System.Text.Json;

namespace Clang_Format_Gui
{
  // Small JSON-backed settings file so the user doesn't have to
  // re-type the clang-format / style-file paths every launch.
  public sealed class App_Settings
  {
    public string Clang_Format_Path { get; set; } =
      @"C:\Program Files\LLVM\bin\clang-format.exe";

    public string Style_File_Path_CSharp { get; set; } =
      @"C:\Users\Administrator\Documents\Mike_Code_Projects\Desktop_Apps\Clang_Formatter_GUI\Clang_Format_Rules\C_Sharp\.clang-format";

    public string Style_File_Path_Cpp { get; set; } =
      @"C:\Users\Administrator\Documents\Mike_Code_Projects\Desktop_Apps\Clang_Formatter_GUI\Clang_Format_Rules\C++\.clang-format";

    public Clang_Format_Target Style_Target { get; set; } = Clang_Format_Target.Cpp;

    public string Last_Source_Folder { get; set; } = "";

    public bool Recursive_Scan { get; set; } = true;

    public string[] Selected_Extensions { get; set; } =
      { ".cs", ".h", ".hpp", ".cpp", ".cc", ".c" };

    private static string Settings_File_Path
    {
      get
      {
        string Folder = Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
          "Clang_Format_Gui");
        Directory.CreateDirectory(Folder);
        return Path.Combine(Folder, "settings.json");
      }
    }

    public static App_Settings Load()
    {
      try
      {
        if (File.Exists(Settings_File_Path))
        {
          string Json = File.ReadAllText(Settings_File_Path);
          var Loaded = JsonSerializer.Deserialize<App_Settings>(Json);
          if (Loaded != null)
            return Loaded;
        }
      }
      catch
      {
        // Corrupt or unreadable settings file — fall back to defaults
        // rather than crashing the app on startup.
      }

      return new App_Settings();
    }

    public void Save()
    {
      try
      {
        var Options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(Settings_File_Path, JsonSerializer.Serialize(this, Options));
      }
      catch
      {
        // Best-effort persistence; a failed save shouldn't crash the app.
      }
    }
  }
}
