<<<<<<< HEAD
# Clang-Format GUI

A small WinForms front-end for batch-running `clang-format` over a folder of
source files, with separate style targets for C# and C/C++, and a live
before/after preview so you can check the result before anything on disk
changes.

![Clang-Format GUI main window, showing source folder, style target, files
found, and the before/after preview panes](docs/screenshot.png)

## Features

- **Two style targets** — C# and C/C++ each remember their own
  `.clang-format` file. Switching the target automatically enables only the
  matching file-type checkboxes (`.cs` for C#; `.h`/`.hpp`/`.cpp`/`.cc`/`.c`
  for C/C++), so you can't scan the wrong language against the wrong style.
- **Live validation** — a red banner and disabled Scan/Format buttons tell
  you immediately if the style file is missing, the source folder is
  invalid, no file type is checked, or the folder simply has no files
  matching the current style target.
- **Before/After preview** — click any scanned file to see it exactly as it
  is on disk next to what clang-format would produce, without touching the
  file. Save just that one file, or format everything you've checked at
  once.
- **Edit button** — opens the current `.clang-format` file in whatever
  program Windows has associated with it (e.g. Notepad++), so you don't
  have to leave the app to tweak the style.
- **Remembers everything** — clang-format.exe path, both style-file paths,
  style target, last source folder, recursive flag, and selected file types
  persist between launches.
- **In-app Help** — the `?` button in the title bar opens a detailed
  walkthrough of every field and button.

## Requirements

- Windows
- [.NET SDK](https://dotnet.microsoft.com/) matching the `<TargetFramework>`
  in `ClangFormatGui.csproj` (currently `net10.0-windows`)
- [clang-format.exe](https://releases.llvm.org/download.html) (installed
  with LLVM)

## Getting started

1. Clone or copy this folder anywhere on disk.
2. Open `ClangFormatGui.csproj` directly in Visual Studio (File > Open >
   Project/Solution), or run `dotnet run` from inside the folder.
3. If your installed SDK is older than the project's
   `<TargetFramework>`, lower it in the `.csproj` (e.g. `net8.0-windows`).

## Using it

1. **Source folder** — browse to the folder you want to format.
   **Include subfolders** toggles recursive scanning.
2. **Clang-format.exe** — point this at your `clang-format.exe`.
3. **Style target** — pick **C#** or **C / C++**. This gates which file-type
   checkboxes are enabled and which remembered style file is shown below.
4. **Style file (.clang-format)** — browse to (or **Edit**) the style file
   for the current target.
5. If anything above is missing or the folder doesn't have any files
   matching the current target, a red message explains why and **Scan
   Folder** / **Format Selected Files** stay disabled until it's fixed.
6. **Scan Folder** — lists every matching file, all checked by default.
   Uncheck anything you don't want touched, or use **All** / **None**.
7. Click a single file in the list to preview it — **Before** is the file
   as-is; **After** is a live, unsaved preview of what clang-format would
   produce. **Save This File** applies just that one file.
8. **Format Selected Files** — runs `clang-format -i` on every checked file,
   logging success/failure per file to the console panel at the bottom. If
   the style file isn't found, it falls back to `-style=llvm`.

Settings (paths, target, last folder, file types) are stored in
`%AppData%\Clang_Format_Gui\settings.json` and reloaded on the next launch.

## Notes

- This is destructive like the original script: `-i` rewrites files in
  place. There's no undo beyond your own source control / backups.
- The window is a custom borderless dark UI (drag by the title bar; use the
  `?` / `—` / `✕` buttons for help/minimize/close) rather than the OS
  default chrome, and is a fixed size rather than freely resizable.
=======
# Clang_Format_GUI
A graphical windows form application for formatting code with clang-format
>>>>>>> 832baf103a450a140c0dff1f3dcccb0312bf8964
