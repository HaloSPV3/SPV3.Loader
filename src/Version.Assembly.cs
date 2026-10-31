/**
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Semver;
using SPV3.Annotations;

namespace SPV3
{
  public partial class Version
  {
    public class VersionAssembly : INotifyPropertyChanged
    {
      private string _address = string.Empty;
      private string _content = string.Empty;
      private System.Version _version = new();

      private Visibility _visibility = Visibility.Collapsed;

      public Visibility Visibility
      {
        get => _visibility;
        set
        {
          if (value == _visibility) return;
          _visibility = value;
          OnPropertyChanged();
        }
      }

      public string Content
      {
        get => _content;
        set
        {
          if (value == _content) return;
          _content = value;
          OnPropertyChanged();
        }
      }

      public string Address
      {
        get => _address;
        set
        {
          if (value == _address) return;
          _address = value;
          OnPropertyChanged();
        }
      }

      [Obsolete($"Superseded by {nameof(SemVersion)}")]
      public System.Version Version
      {
        get => _version;
        set
        {
          if (value == _version) return;
          _version = value;
          OnPropertyChanged();
        }
      }

      public SemVersion SemVersion
      {
        get;
        set
        {
          if (value == field) return;
          field = value;
          OnPropertyChanged();
        }
      } = new(0);

      public event PropertyChangedEventHandler? PropertyChanged;

      public void Initialise()
      {
        {
          if (SemVersion.Major == 0)
            SemVersion = SemVersion.TryParse(GitVersionInformation.FullSemVer, out var semResult)
              ? semResult
              : new(0);
        }

#pragma warning disable CS0618 // Type or member is obsolete
        Version = System.Version.TryParse(GitVersionInformation.AssemblySemVer, out var result)
#pragma warning restore CS0618 // Type or member is obsolete
          ? result
          : new();
        Content = $"Version {GitVersionInformation.FullSemVer}-{GitVersionInformation.ShortSha.ToUpper()}";
        Address = $"https://github.com/HaloSPV3/SPV3.Loader/releases/v{GitVersionInformation.FullSemVer}";
        Visibility = Visibility.Visible;
      }

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
