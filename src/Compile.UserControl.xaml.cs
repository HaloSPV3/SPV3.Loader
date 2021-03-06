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

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace SPV3
{
  public partial class Compile_UserControl : UserControl
  {
    private readonly Compile _compile;

    public Compile_UserControl()
    {
      InitializeComponent();
      _compile = (Compile) DataContext;
    }

    public event EventHandler Home;

    private async void Compile(object sender, RoutedEventArgs e)
    {
      CompileButton.Content = "Compiling...";
      await Task.Run(() => _compile.Commit());
      CompileButton.Content = "Compile";
    }

    private void Back(object sender, RoutedEventArgs e)
    {
      Home?.Invoke(sender, e);
    }

    private void Browse(object sender, RoutedEventArgs e)
    {
      using (var dialog = new FolderBrowserDialog())
      {
        if (dialog.ShowDialog() == DialogResult.OK)
          _compile.Target = dialog.SelectedPath;
      }
    }
  }
}
