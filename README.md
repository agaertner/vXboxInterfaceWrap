# vXboxInterfaceWrap

This is a C# wrapper for [vXboxInterface](https://github.com/shauleiz/vXboxInterface/releases/latest) by [shauleiz](https://github.com/shauleiz/).  
The ``vXboxInterface.dll`` needs to be placed alongside the ``vXboxInterfaceWrap.dll``.

```csharp
using vXboxInterfaceWrap;

using (var myController = new VirtualXboxController(1, bool forceOwnership = false)) { // Manage controller in slot 1.

    // The Button enumeration is provided in the vXboxInterfaceWrap namespace.
    
    myController.Press(Button.A); // Presses (and holds) the A button.
    myController.Release(Button.A); // Releases the A button.
    myController.SetAxisX(0.42 * AXIS_MAX); // Set the X-axis of the left stick. Usually called with a normalized value of an direction vector.
    myController.SetAxisY(0.42 * AXIS_MAX); // Set the Y-axis of the left stick. Usually called with a normalized value of an direction vector.
    myController.SetAxisRx(0.42 * AXIS_MAX); // Set the X-axis of the right stick. Usually called with a normalized value of an direction vector.
    myController.SetAxisRy(0.42 * AXIS_MAX); // Set the Y-axis of the right stick. Usually called with a normalized value of an direction vector.
    
    // The implementation provides several button stroke variations to avoid Press/Release calls for quick interactions.
    
    myController.Stroke(Button.A);
    myController.Stroke(Button.A, 42); // Will press the button 42 times.
    myController.Stroke(new []{ Button.A, Button.B, Button.X });
    myController.Stroke(Button.LeftTrigger, Button.A); // The first parameter acts as a modifier which is pressed first and released last.
    myController.Stroke(Button.LeftTrigger, new []{ Button.A, Button.B }); // Similar to above. The buttons get released in reverse order.
    
    myController.GetRumbleMotorUsage(); // A tuple in which the first item contains the utilization percentage of the low-frequency rumble motor and the second item the utilization percentage of the high-frequency rumble motor.
    
    myController.Exists(); // True if the virtual bus and controller exists in the managed slot index.
    myController.Acquire(bool force = false); // If the controller wasn't acquired on construction you can manually try again with this call.
    myController.Release(bool force = false); // Disconnects from the device. (Un-Plug)
}
```
Note that the ``VirtualXboxController`` implements ``IDisposable``.   
``Dispose`` resets and releases the device if it's acquired by the calling application.

# Fields

```csharp
public const int AXIS_MAX; // Highest value an axis can be set to.
public const int AXIS_MIN; // Lowest value an axis can be set to.
public const int VIBRATION_MAX; // Highest value a rumble motor frequency can be.
public bool Acquired; // Indicates if the device is owned by and connected to the calling application.
public readonly uint SlotIndex; // The slot index that is set on construction and that is managed by this object.
```
