#region Assembly PresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// /home/noah/.cache/NuGetPackages/microsoft.windowsdesktop.app.ref/6.0.36/ref/net6.0/PresentationFramework.dll
#endregion


namespace System.Windows
{
  //
  // Summary:
  //     Specifies special display options for a message box.
  [Flags]
  public enum MessageBoxOptions
  {
    //
    // Summary:
    //     No options are set.
    None = 0,
    //
    // Summary:
    //     The message box is displayed on the default desktop of the interactive window
    //     station. Specifies that the message box is displayed from a .NET Windows Service
    //     application in order to notify the user of an event.
    DefaultDesktopOnly = 131072,
    //
    // Summary:
    //     The message box text and title bar caption are right-aligned.
    RightAlign = 524288,
    //
    // Summary:
    //     All text, buttons, icons, and title bars are displayed right-to-left.
    RtlReading = 1048576,
    //
    // Summary:
    //     The message box is displayed on the currently active desktop even if a user is
    //     not logged on to the computer. Specifies that the message box is displayed from
    //     a .NET Windows Service application in order to notify the user of an event.
    ServiceNotification = 2097152
  }
}
