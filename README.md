# vXboxInterfaceWrap

This is a C# wrapper for [vXboxInterface](https://github.com/shauleiz/vXboxInterface/releases/latest) by [shauleiz](https://github.com/shauleiz/).


```csharp
using vXboxInterfaceWrap;

using (var myController = new VirtualXboxController(1, bool forceOwnership = false)) { // Manage controller in slot 1.

    // The Button enumeration is provided in the vXboxInterfaceWrap namespace.
    
    myController.Press(Button.A); // Presses and holds the A button.
    myController.Release(Button.A); // Releases the A button.
    myController.SetAxisX(); // Set the X-axis of the left stick.
    myController.SetAxisY(); // Set the Y-axis of the left stick.
    myController.SetAxisRx(); // Set the X-axis of the right stick.
    myController.SetAxisRy(); // Set the Y-axis of the right stick.
    
    // The implementation provides several button stroke variation to avoid Press/Releases.
    
    myController.Stroke(Button.A);
    myController.Stroke(Button.A, 42); // Will press the button 42 times.
    myController.Stroke(new []{ Button.A, Button.B, Button.X });
    myController.Stroke(Button.LeftTrigger, Button.A); // The first parameter acts as a modifier which is pressed first and released last.
    myController.Stroke(Button.LeftTrigger, new []{ Button.A, Button.B }); // Similar to above. The buttons get released in reverse order.
    
    myController.GetVibrationFrequencies(); // Returns a tuple in which the first item is the low-frequency and the second item the high-frequency rumble motor value.
    
    myController.Exists(); // True if the virtual bus and controller exists in the managed slot index.
    myController.Acquire(bool force = false); // If the controller wasn't acquired on construction you can manually try again with this call.
    myController.Release(bool force = false); // Disconnects from the device. (Un-Plug)
}
```
Note that the ``VirtualXboxController`` implements ``IDisposable``.   
``Dispose`` resets and releases the device if its acquired by the calling application.

# Fields

```csharp
public const AXIS_MAX; // Highest value an axis can be set to.
public const AXIS_MIN; // Lowest value an axis can be set to.

public bool Acquired; // Indicates if the device is owned by and connected to the calling application.
public uint SlotIndex; // The slot index which is set on construction and which is managed by this object.
```
