using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Clang_Format_Gui
{
  public sealed class Format_Result
  {
    public string File_Path { get; init; } = "";
    public bool Succeeded { get; init; }
    public string Message { get; init; } = "";

    // Only populated by Preview_File_Async — the formatted text,
    // without ever touching the file on disk.
    public string? Formatted_Text { get; init; }
  }

  // Mirrors the logic of Format_File.bat: locate clang-format.exe,
  // fall back to the LLVM default style if the .clang-format file is
  // missing, then either run "-i" (in-place) or capture stdout for a
  // preview, depending on the caller.
  public static class Clang_Format_Runner
  {
    public static Task<Format_Result> Format_File_Async(
      string Clang_Format_Path, string Style_File_Path, string Target_File_Path)
    {
      return Run_Async(Clang_Format_Path, Style_File_Path, Target_File_Path, In_Place: true);
    }

    // Runs clang-format WITHOUT "-i" so the result is only captured from
    // stdout — the file on disk is never touched.
    public static Task<Format_Result> Preview_File_Async(
      string Clang_Format_Path, string Style_File_Path, string Target_File_Path)
    {
      return Run_Async(Clang_Format_Path, Style_File_Path, Target_File_Path, In_Place: false);
    }

    private static async Task<Format_Result> Run_Async(
      string Clang_Format_Path, string Style_File_Path, string Target_File_Path, bool In_Place)
    {
      if (!File.Exists(Clang_Format_Path))
      {
        return new Format_Result
        {
          File_Path = Target_File_Path,
          Succeeded = false,
          Message = "clang-format not found at: " + Clang_Format_Path
        };
      }

      if (!File.Exists(Target_File_Path))
      {
        return new Format_Result
        {
          File_Path = Target_File_Path,
          Succeeded = false,
          Message = "Input file not found."
        };
      }

      bool Style_File_Exists = File.Exists(Style_File_Path);
      string Style_Arg = Style_File_Exists
        ? "-style=file:\"" + Style_File_Path + "\""
        : "-style=llvm";

      string Arguments = (In_Place ? "-i " : "") + Style_Arg + " \"" + Target_File_Path + "\"";

      var Start_Info = new ProcessStartInfo
      {
        FileName = Clang_Format_Path,
        Arguments = Arguments,
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        CreateNoWindow = true
      };

      try
      {
        using var Process_Instance = Process.Start(Start_Info);

        if (Process_Instance == null)
        {
          return new Format_Result
          {
            File_Path = Target_File_Path,
            Succeeded = false,
            Message = "Failed to start the clang-format process."
          };
        }

        Task<string> Std_Output_Task = Process_Instance.StandardOutput.ReadToEndAsync();
        Task<string> Std_Error_Task = Process_Instance.StandardError.ReadToEndAsync();
        await Task.WhenAll(Std_Output_Task, Std_Error_Task);
        await Process_Instance.WaitForExitAsync();

        string Std_Output = Std_Output_Task.Result;
        string Std_Error = Std_Error_Task.Result;

        if (Process_Instance.ExitCode != 0)
        {
          return new Format_Result
          {
            File_Path = Target_File_Path,
            Succeeded = false,
            Message = "clang-format exited with code " + Process_Instance.ExitCode +
                      (string.IsNullOrWhiteSpace(Std_Error) ? "" : ": " + Std_Error.Trim())
          };
        }

        return new Format_Result
        {
          File_Path = Target_File_Path,
          Succeeded = true,
          Formatted_Text = In_Place ? null : Std_Output,
          Message = Style_File_Exists
            ? "Formatted successfully."
            : "Formatted (style file not found — used LLVM default)."
        };
      }
      catch (Exception Ex)
      {
        return new Format_Result
        {
          File_Path = Target_File_Path,
          Succeeded = false,
          Message = Ex.Message
        };
      }
    }
  }
}
