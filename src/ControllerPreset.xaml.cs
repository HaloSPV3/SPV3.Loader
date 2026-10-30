using System.Windows;

namespace SPV3
{
  /// <summary>
  /// Interaction logic for ControllerPreset.xaml
  /// </summary>
  public partial class ControllerPreset : Window
  {
    public ControllerPreset()
    {
      InitializeComponent();
    }

    private void Accept(object? sender, RoutedEventArgs e)
    {
      DialogResult = true;
      this.Close();
    }

    private void Cancel(object? sender, RoutedEventArgs e)
    {
      DialogResult = false;
      this.Close();
    }
  }
}
