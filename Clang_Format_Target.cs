using System;
using System.Collections.Generic;

namespace Clang_Format_Gui
{
  public enum Clang_Format_Target
  {
    CSharp,
    Cpp
  }

  public static class Clang_Format_Target_Extensions
  {
    public static readonly IReadOnlyDictionary<Clang_Format_Target, string[]> Allowed_Extensions =
      new Dictionary<Clang_Format_Target, string[]>
      {
        [Clang_Format_Target.CSharp] = new[] { ".cs" },
        [Clang_Format_Target.Cpp] = new[] { ".h", ".hpp", ".cpp", ".cc", ".c" }
      };

    public static string Display_Name(this Clang_Format_Target Target) =>
      Target == Clang_Format_Target.CSharp ? "C#" : "C / C++";
  }
}
