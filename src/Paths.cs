/**
 * Copyright (c) 2019 Emilian Roman
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using static System.Environment;
using static System.Environment.SpecialFolder;
using static System.IO.Path;

namespace SPV3
{
  public static class Paths
  {
#pragma warning disable format
    public const string Compile    = "0xCOMPILE";
    public const string AmaiSosu   = "amaisosu.exe";
    public const string Executable = "spv3.exe";

    /// <summary> %APPDATA%/SPV3 </summary>
    public static readonly string Directory     = Combine(GetFolderPath(ApplicationData), "SPV3");
    /// <summary> ${Directory}/initc.txt </summary>
    public static readonly string Initiation    = Combine(Directory,                      "initc.txt");
    /// <summary> ${Directory}/exception.log </summary>
    public static readonly string Exception     = Combine(Directory,                      "exception.log");
    /// <summary> ${Directory}/install-loader.log </summary>
    public static readonly string Install       = Combine(Directory,                      "install-loader.log");
    /// <summary> ${Directory}/loader-0x05.bin </summary>
    public static readonly string Configuration = Combine(Directory,                      "loader-0x05.bin");
    /// <summary> ${Directory}/kernel-0x05.bin </summary>
    public static readonly string Kernel        = Combine(Directory,                      "kernel-0x05.bin");
    /// <summary> ${CurrentDirectory}/doom.bin </summary>
    public static readonly string DOOM          = Combine(CurrentDirectory,               "doom.bin");
    /// <summary> ${CurrentDirectory}/photo.bin </summary>
    public static readonly string Photo         = Combine(CurrentDirectory,               "photo.bin");
    /// <summary> ${CurrentDirectory}/setup.exe </summary>
    public static readonly string Setup         = Combine(CurrentDirectory,               "setup.exe");
    /// <summary> ${CurrentDirectory}/hxe.exe </summary>
    public static readonly string HXE           = Combine(CurrentDirectory,               "hxe.exe");
    /// <summary> ${CurrentDirectory}/readme.pdf </summary>
    public static readonly string Readme        = Combine(CurrentDirectory,               "readme.pdf");
    /// <summary> ${CurrentDirectory}/changelog.pdf </summary>
    public static readonly string Changelog     = Combine(CurrentDirectory,               "changelog.pdf");
    /// <summary> ${CurrentDirectory}/credits.pdf </summary>
    public static readonly string Credits       = Combine(CurrentDirectory,               "credits.pdf");
    /// <summary> ${CurrentDirectory}/optimization_guide.pdf </summary>
    public static readonly string OptimizeGuide = Combine(CurrentDirectory,               "optimization_guide.pdf");
#pragma warning restore format

    public static string Packages(string target)
    {
      return Combine(target, "data");
    }
  }
}
