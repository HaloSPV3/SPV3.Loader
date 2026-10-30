/*
 * Copyright (c) 2019 Emilian Roman
 * Copyright (c) 2021 Noah Sherwin
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

using System;
using System.Collections.Generic;
using HXE.HCE;
using static HXE.OpenSauce.OpenSauceObjects.ObjectsWeapon;
using static SPV3.Kernel;

namespace SPV3
{
  public partial class Configuration
  {
    // a string.replace relies on this ending with "]"
    private const string _logMsgPrefix = $"[{nameof(SPV3)}.{nameof(Configuration)}] ";

    // See SPV3.Kernel class
    public ConfigurationLoader Loader { get; set; } = spv3;

    public ConfigurationShaders Shaders { get; set; } = new ConfigurationShaders();
    public ConfigurationOpenSauce OpenSauce { get; set; } = new ConfigurationOpenSauce();
    public ConfigurationChimera Chimera { get; set; } = new ConfigurationChimera();

    public void Load()
    {
      Kernel.Load();    // kernel/loader bin
      Loader = spv3;    // loader bin. Copy static instance to local instance. Deprecate local instance?
      Shaders.Load();   // kernel bin, load from Kernel.hxe
      OpenSauce.Load(); // OS_Settings.user.xml
      Chimera.Load();   // chimera bin
    }

    public void Save()
    {
      spv3 = Loader; // loader bin. Copy local instance to static instance
      Shaders.Save(); // kernel bin, load from Kernel.hxe
      Kernel.Save(); // kernel/loader bin.
      OpenSauce.Save(); // OS_Settings.user.xml
      Chimera.Save(); // chimera bin
    }

    public void CalculateFOV()
    {
      OpenSauce.FieldOfView = OpenSauce.Configuration.Camera.CalculateFOV(Loader.Width, Loader.Height);
    }

    public void ResetWeaponPositions()
    {
      OpenSauce.Configuration.Objects.Weapon.Positions = new List<PositionWeapon>();
    }

    /// <summary> Reset the gamepad bindings to built-in spv3 controller preset </summary>
    /// <remarks>
    ///   This method must operate differently than the rest of the API.
    ///   Normally, we would set HXE's configuration so the action is taken right before the game launches.
    ///   However, a button implies the action is taken immediately.
    ///   If we set a boolean, we'd have to provide some way for the user to unset the boolean so their controls are _not_ reset
    /// </remarks>
    internal static bool ApplyGamepadPreset()
    {
      LogInfo("Applying gamepad preset...", nameof(ApplyGamepadPreset));
      // todo: respect user-defined path; grab it from Kernel.spv3 or Kernel.hxe?
      // e.g. "%APPDATA%/SPV3" or "%USERPROFILE%/Documents/My Games/Halo CE/"
      var userDataDirectory = Paths.Directory;
      var lastProfile = (LastProfile)HXE.Paths.Custom.LastProfile(userDataDirectory);

      Profile? blam;
      try
      {
        // if the directories and/or files do not exist, this Load() should create them.

        lastProfile.Load();
        // using Paths.Directory is very fragile; If the user wants to use a different directory (e.g. for portability), this method doesn't have a good way of respecting their choice.
        // may throw FileNotFoundException e.g. new FileNotFoundException("Cannot detect profile - lastprof.txt does not exist.");
        blam = Profile.Detect(userDataDirectory);
      }
      catch (Exception exception)
      {
        var msg = $"Failed to find player profile when it should exists!\n{exception}";
        LogWarning(msg, nameof(ApplyGamepadPreset));
        var log = (HXE.File)Paths.Exception;
        HXE.Console.Warn(msg);
        log.AppendAllText(msg + "\n");
        return false;
      }

      blam.Input.ApplyPreset(Profile.ProfileInput.Presets.SPV3Gamepad);
      return true;
    }

    public void ShowHxeSettings()
    {
      Save(); // Save all settings, copy Loader to Kernel equivalents

      var settings = new HXE.Settings(hxe); // Pass modified Kernel instance to Settings.
      settings.ShowDialog();
      if (settings.DialogResult == true)
      {
        hxe.Load();
        spv3.Load();
        CopyKernelToLoader();
        Loader = spv3;
      }
    }

    public void ShowHxeWepPositions()
    {
      new HXE.Positions().ShowDialog();
    }

    /// <summary>
    /// Log an error message to console and file logs
    /// </summary>
    /// <param name="message"></param>
    /// <param name="nameofCaller">e.g. nameof(ShowInputPresetWindowConfirmation)}</param>
    private static void LogInfo(string message, string nameofCaller)
    {
      var msg = _logMsgPrefix.Replace("]", $".{nameofCaller}]") + message;
      HXE.Console.Info(msg);
      var exception = (HXE.File)Paths.Exception;
      exception.AppendAllText(msg + Environment.NewLine);
    }

    /// <summary>
    /// Log an error message to console and file logs
    /// </summary>
    /// <param name="message"></param>
    /// <param name="nameofCaller">e.g. nameof(ShowInputPresetWindowConfirmation)}</param>
    private static void LogWarning(string message, string nameofCaller)
    {
      var msg = _logMsgPrefix.Replace("]", $".{nameofCaller}]") + message;
      HXE.Console.Warn(msg);
      var exception = (HXE.File)Paths.Exception;
      exception.AppendAllText(msg + Environment.NewLine);
    }
  }
}
