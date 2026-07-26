using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Clang_Format_Gui
{
  public static class Folder_Scanner
  {
    // Cheaper than Scan() for validation — stops at the first hit instead
    // of enumerating and sorting every matching file in the tree.
    public static bool Has_Any_Match(string Root_Folder, IEnumerable<string> Extensions, bool Recursive)
    {
      if (string.IsNullOrWhiteSpace(Root_Folder) || !Directory.Exists(Root_Folder))
        return false;

      var Search_Option = Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

      foreach (var Extension in Extensions)
      {
        try
        {
          if (Directory.EnumerateFiles(Root_Folder, "*" + Extension, Search_Option).Any())
            return true;
        }
        catch
        {
          // A locked or inaccessible subfolder shouldn't abort the whole check.
        }
      }

      return false;
    }

    public static List<string> Scan(string Root_Folder, IEnumerable<string> Extensions, bool Recursive)
    {
      var Result = new List<string>();

      if (string.IsNullOrWhiteSpace(Root_Folder) || !Directory.Exists(Root_Folder))
        return Result;

      var Search_Option = Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
      var Seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

      foreach (var Extension in Extensions)
      {
        string Pattern = "*" + Extension;

        try
        {
          foreach (var File_Path in Directory.EnumerateFiles(Root_Folder, Pattern, Search_Option))
          {
            if (Seen.Add(File_Path))
              Result.Add(File_Path);
          }
        }
        catch
        {
          // A locked or inaccessible subfolder shouldn't abort the whole scan.
        }
      }

      Result.Sort(StringComparer.OrdinalIgnoreCase);
      return Result;
    }
  }
}
