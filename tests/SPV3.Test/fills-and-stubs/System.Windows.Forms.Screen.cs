#region Assembly System.Windows.Forms, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// .cache/NuGetPackages/microsoft.windowsdesktop.app.ref/6.0.36/ref/net6.0/System.Windows.Forms.dll
#endregion

using System.Drawing;
using Control = object;

namespace System.Windows.Forms
{
  //
  // Summary:
  //     Represents a display device or multiple display devices on a single system.
  public class Screen
  {
    //
    // Summary:
    //     Gets the primary display.
    //
    // Returns:
    //     The primary display.
    public static Screen PrimaryScreen { get; } = new();
    //
    // Summary:
    //     Gets an array of all displays on the system.
    //
    // Returns:
    //     An array of type System.Windows.Forms.Screen, containing all displays on the
    //     system.
    public static Screen[] AllScreens { get; } = [];
    //
    // Summary:
    //     Gets the working area of the display. The working area is the desktop area of
    //     the display, excluding taskbars, docked windows, and docked tool bars.
    //
    // Returns:
    //     A System.Drawing.Rectangle, representing the working area of the display.
    public Rectangle WorkingArea { get; }
    //
    // Summary:
    //     Gets a value indicating whether a particular display is the primary device.
    //
    // Returns:
    //     true if this display is primary; otherwise, false.
    public bool Primary { get; }
    //
    // Summary:
    //     Gets the device name associated with a display.
    //
    // Returns:
    //     The device name associated with a display.
    public string DeviceName { get; } = string.Empty;
    //
    // Summary:
    //     Gets the bounds of the display.
    //
    // Returns:
    //     A System.Drawing.Rectangle, representing the bounds of the display.
    public Rectangle Bounds { get; }
    //
    // Summary:
    //     Gets the number of bits of memory, associated with one pixel of data.
    //
    // Returns:
    //     The number of bits of memory, associated with one pixel of data.
    public int BitsPerPixel { get; }

    //
    // Summary:
    //     Retrieves a System.Windows.Forms.Screen for the display that contains the largest
    //     portion of the specified control.
    //
    // Parameters:
    //   control:
    //     A System.Windows.Forms.Control for which to retrieve a System.Windows.Forms.Screen.
    //
    //
    // Returns:
    //     A System.Windows.Forms.Screen for the display that contains the largest region
    //     of the specified control. In multiple display environments where no display contains
    //     the control, the display closest to the specified control is returned.
    public static Screen FromControl(Control control) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves a System.Windows.Forms.Screen for the display that contains the largest
    //     portion of the object referred to by the specified handle.
    //
    // Parameters:
    //   hwnd:
    //     The window handle for which to retrieve the System.Windows.Forms.Screen.
    //
    // Returns:
    //     A System.Windows.Forms.Screen for the display that contains the largest region
    //     of the object. In multiple display environments where no display contains any
    //     portion of the specified window, the display closest to the object is returned.
    public static Screen FromHandle(IntPtr hwnd) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves a System.Windows.Forms.Screen for the display that contains the specified
    //     point.
    //
    // Parameters:
    //   point:
    //     A System.Drawing.Point that specifies the location for which to retrieve a System.Windows.Forms.Screen.
    //
    //
    // Returns:
    //     A System.Windows.Forms.Screen for the display that contains the point. In multiple
    //     display environments where no display contains the point, the display closest
    //     to the specified point is returned.
    public static Screen FromPoint(Point point) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves a System.Windows.Forms.Screen for the display that contains the largest
    //     portion of the rectangle.
    //
    // Parameters:
    //   rect:
    //     A System.Drawing.Rectangle that specifies the area for which to retrieve the
    //     display.
    //
    // Returns:
    //     A System.Windows.Forms.Screen for the display that contains the largest region
    //     of the specified rectangle. In multiple display environments where no display
    //     contains the rectangle, the display closest to the rectangle is returned.
    public static Screen FromRectangle(Rectangle rect) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves the bounds of the display that contains the largest portion of the
    //     specified rectangle.
    //
    // Parameters:
    //   rect:
    //     A System.Drawing.Rectangle that specifies the area for which to retrieve the
    //     display bounds.
    //
    // Returns:
    //     A System.Drawing.Rectangle that specifies the bounds of the display that contains
    //     the specified rectangle. In multiple display environments where no monitor contains
    //     the specified rectangle, the monitor closest to the rectangle is returned.
    public static Rectangle GetBounds(Rectangle rect) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves the bounds of the display that contains the largest portion of the
    //     specified control.
    //
    // Parameters:
    //   ctl:
    //     The System.Windows.Forms.Control for which to retrieve the display bounds.
    //
    // Returns:
    //     A System.Drawing.Rectangle that specifies the bounds of the display that contains
    //     the specified control. In multiple display environments where no display contains
    //     the specified control, the display closest to the control is returned.
    public static Rectangle GetBounds(Control ctl) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves the bounds of the display that contains the specified point.
    //
    // Parameters:
    //   pt:
    //     A System.Drawing.Point that specifies the coordinates for which to retrieve the
    //     display bounds.
    //
    // Returns:
    //     A System.Drawing.Rectangle that specifies the bounds of the display that contains
    //     the specified point. In multiple display environments where no display contains
    //     the specified point, the display closest to the point is returned.
    public static Rectangle GetBounds(Point pt) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves the working area for the display that contains the largest region of
    //     the specified control. The working area is the desktop area of the display, excluding
    //     taskbars, docked windows, and docked tool bars.
    //
    // Parameters:
    //   ctl:
    //     The System.Windows.Forms.Control for which to retrieve the working area.
    //
    // Returns:
    //     A System.Drawing.Rectangle that specifies the working area. In multiple display
    //     environments where no display contains the specified control, the display closest
    //     to the control is returned.
    public static Rectangle GetWorkingArea(Control ctl) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves the working area for the display that contains the largest portion
    //     of the specified rectangle. The working area is the desktop area of the display,
    //     excluding taskbars, docked windows, and docked tool bars.
    //
    // Parameters:
    //   rect:
    //     The System.Drawing.Rectangle that specifies the area for which to retrieve the
    //     working area.
    //
    // Returns:
    //     A System.Drawing.Rectangle that specifies the working area. In multiple display
    //     environments where no display contains the specified rectangle, the display closest
    //     to the rectangle is returned.
    public static Rectangle GetWorkingArea(Rectangle rect) => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves the working area closest to the specified point. The working area is
    //     the desktop area of the display, excluding taskbars, docked windows, and docked
    //     tool bars.
    //
    // Parameters:
    //   pt:
    //     A System.Drawing.Point that specifies the coordinates for which to retrieve the
    //     working area.
    //
    // Returns:
    //     A System.Drawing.Rectangle that specifies the working area. In multiple display
    //     environments where no display contains the specified point, the display closest
    //     to the point is returned.
    public static Rectangle GetWorkingArea(Point pt) => throw new NotImplementedException();
    //
    // Summary:
    //     Gets or sets a value indicating whether the specified object is equal to this
    //     Screen.
    //
    // Parameters:
    //   obj:
    //     The object to compare to this System.Windows.Forms.Screen.
    //
    // Returns:
    //     true if the specified object is equal to this System.Windows.Forms.Screen; otherwise,
    //     false.
    public override bool Equals(object? obj) => throw new NotImplementedException();
    //
    // Summary:
    //     Computes and retrieves a hash code for an object.
    //
    // Returns:
    //     A hash code for an object.
    public override int GetHashCode() => throw new NotImplementedException();
    //
    // Summary:
    //     Retrieves a string representing this object.
    //
    // Returns:
    //     A string representation of the object.
    public override string ToString() => throw new NotImplementedException();
  }
}
