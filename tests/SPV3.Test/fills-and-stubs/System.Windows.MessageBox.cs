#region Assembly PresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// /home/noah/.cache/NuGetPackages/microsoft.windowsdesktop.app.ref/6.0.36/ref/net6.0/PresentationFramework.dll
#endregion

#if !Windows
#pragma warning disable HXE9001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
using Window = HXE.Window;
#endif

namespace System.Windows
{
  //
  // Summary:
  //     Displays a message box.
  public sealed class MessageBox
  {
    //
    // Summary:
    //     Displays a message box that has a message and that returns a result.
    //
    // Parameters:
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(string messageBoxText) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box that has a message and title bar caption; and that returns
    //     a result.
    //
    // Parameters:
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(string messageBoxText, string caption) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box that has a message, title bar caption, and button; and
    //     that returns a result.
    //
    // Parameters:
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    //   button:
    //     A System.Windows.MessageBoxButton value that specifies which button or buttons
    //     to display.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box that has a message, title bar caption, button, and icon;
    //     and that returns a result.
    //
    // Parameters:
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    //   button:
    //     A System.Windows.MessageBoxButton value that specifies which button or buttons
    //     to display.
    //
    //   icon:
    //     A System.Windows.MessageBoxImage value that specifies the icon to display.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box that has a message, title bar caption, button, and icon;
    //     and that accepts a default message box result and returns a result.
    //
    // Parameters:
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    //   button:
    //     A System.Windows.MessageBoxButton value that specifies which button or buttons
    //     to display.
    //
    //   icon:
    //     A System.Windows.MessageBoxImage value that specifies the icon to display.
    //
    //   defaultResult:
    //     A System.Windows.MessageBoxResult value that specifies the default result of
    //     the message box.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box that has a message, title bar caption, button, and icon;
    //     and that accepts a default message box result, complies with the specified options,
    //     and returns a result.
    //
    // Parameters:
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    //   button:
    //     A System.Windows.MessageBoxButton value that specifies which button or buttons
    //     to display.
    //
    //   icon:
    //     A System.Windows.MessageBoxImage value that specifies the icon to display.
    //
    //   defaultResult:
    //     A System.Windows.MessageBoxResult value that specifies the default result of
    //     the message box.
    //
    //   options:
    //     A System.Windows.MessageBoxOptions value object that specifies the options.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box in front of the specified window. The message box displays
    //     a message and returns a result.
    //
    // Parameters:
    //   owner:
    //     A System.Windows.Window that represents the owner window of the message box.
    //
    //
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(Window owner, string messageBoxText) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box in front of the specified window. The message box displays
    //     a message and title bar caption; and it returns a result.
    //
    // Parameters:
    //   owner:
    //     A System.Windows.Window that represents the owner window of the message box.
    //
    //
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box in front of the specified window. The message box displays
    //     a message, title bar caption, and button; and it also returns a result.
    //
    // Parameters:
    //   owner:
    //     A System.Windows.Window that represents the owner window of the message box.
    //
    //
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    //   button:
    //     A System.Windows.MessageBoxButton value that specifies which button or buttons
    //     to display.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box in front of the specified window. The message box displays
    //     a message, title bar caption, button, and icon; and it also returns a result.
    //
    //
    // Parameters:
    //   owner:
    //     A System.Windows.Window that represents the owner window of the message box.
    //
    //
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    //   button:
    //     A System.Windows.MessageBoxButton value that specifies which button or buttons
    //     to display.
    //
    //   icon:
    //     A System.Windows.MessageBoxImage value that specifies the icon to display.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box in front of the specified window. The message box displays
    //     a message, title bar caption, button, and icon; and accepts a default message
    //     box result and returns a result.
    //
    // Parameters:
    //   owner:
    //     A System.Windows.Window that represents the owner window of the message box.
    //
    //
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    //   button:
    //     A System.Windows.MessageBoxButton value that specifies which button or buttons
    //     to display.
    //
    //   icon:
    //     A System.Windows.MessageBoxImage value that specifies the icon to display.
    //
    //   defaultResult:
    //     A System.Windows.MessageBoxResult value that specifies the default result of
    //     the message box.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult) => throw new NotImplementedException();
    //
    // Summary:
    //     Displays a message box in front of the specified window. The message box displays
    //     a message, title bar caption, button, and icon; and accepts a default message
    //     box result, complies with the specified options, and returns a result.
    //
    // Parameters:
    //   owner:
    //     A System.Windows.Window that represents the owner window of the message box.
    //
    //
    //   messageBoxText:
    //     A System.String that specifies the text to display.
    //
    //   caption:
    //     A System.String that specifies the title bar caption to display.
    //
    //   button:
    //     A System.Windows.MessageBoxButton value that specifies which button or buttons
    //     to display.
    //
    //   icon:
    //     A System.Windows.MessageBoxImage value that specifies the icon to display.
    //
    //   defaultResult:
    //     A System.Windows.MessageBoxResult value that specifies the default result of
    //     the message box.
    //
    //   options:
    //     A System.Windows.MessageBoxOptions value object that specifies the options.
    //
    // Returns:
    //     A System.Windows.MessageBoxResult value that specifies which message box button
    //     is clicked by the user.
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options) => throw new NotImplementedException();
  }
}
