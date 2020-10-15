using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace vXboxInterfaceWrap {
    /// <summary>
    /// PInvoke for vXboxInterface.dll
    /// </summary>
    internal static class VirtualXboxInterface
    {
        // The following functions are used to Plug-in/Unplug and communicate with vXbox devices installed on ScpVBus.
        #region Status Functions
        /// <summary>
        /// Use this function to verify that the bus exists. You can plug-in vXbox devices only if the bus exists.
        /// </summary>
        /// <returns>TRUE if  ScpVBus exists. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool isVBusExists();

        /// <summary>
        /// Virtual bus ScpVBus has 4 slots for vXbox devices. Use this function to query the number of slots that it is possible to plug-in new device into.
        /// </summary>
        /// <param name="nSlots">Pointer to number of empty slots. Range: 0 to 4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool GetNumEmptyBusSlots(IntPtr nSlots);

        /// <summary>
        /// Check if a specified slot is occupied by a vXbox device (Controller).
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if controller plugged-in. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool isControllerExists(uint UserIndex);

        /// <summary>
        /// Check if a vXbox device (Controller) is owned by the calling application.
        /// Owned means Exists (=was plugged in) and the ID of the plugging process is the same as that of the current process.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if controller owned by application. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool isControllerOwned(uint UserIndex);
        #endregion

        #region Plugged-in/Unplug Functions
        /// <summary>
        /// Plug-in a vXbox device in a specified slot.
        /// The operation will fail unless the bus exists and the slot is free.
        /// </summary>
        /// <param name="idx">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if  function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool PlugIn(uint UserIndex);

        /// <summary>
        /// Unplug a vXbox device from a specified slot.
        /// The operation will fail unless the bus exists and the slot is occupied by an owned device.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool UnPlug(uint UserIndex);

        /// <summary>
        /// Unplug a vXbox device from a specified slot.
        /// The operation will fail unless the bus exists and the slot is occupied by a device.
        /// Warning: This function may remove a vXbox device that is owned by another process.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool UnPlugForce(uint UserIndex);
        #endregion

        #region Data Feeding Functions
        // The following functions are used for feeding the vXbox device with data such as button press/release, axis position or trigger pressure.

        /// <summary>
        /// Button A Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnA(uint UserIndex, bool Press);

        /// <summary>
        /// Button B Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnB(uint UserIndex, bool Press);

        /// <summary>
        /// Button X Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnX(uint UserIndex, bool Press);

        /// <summary>
        /// Button Y Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnY(uint UserIndex, bool Press);

        /// <summary>
        /// Button Start Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnStart(uint UserIndex, bool Press);

        /// <summary>
        /// Button Back Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnBack(uint UserIndex, bool Press);

        /// <summary>
        /// Left Stick (Left Thumb) Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnLT(uint UserIndex, bool Press);

        /// <summary>
        /// Right Stick (Right Thumb) Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnRT(uint UserIndex, bool Press);

        /// <summary>
        /// Left Bumper Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnLB(uint UserIndex, bool Press);

        /// <summary>
        /// Right Bumper Pressed/Released
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnRB(uint UserIndex, bool Press);

        /// <summary>
        /// Set Left Trigger Value
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Value">Press trigger value. Range: 0 to 255</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetTriggerL(uint UserIndex, byte Value);

        /// <summary>
        /// Set Right Trigger Value
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Value">Press trigger value. Range: 0 to 255</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetTriggerR(uint UserIndex, byte Value);

        /// <summary>
        /// Set Value of the left thumb stick X position
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Value">Stick Position. Range: -32768 to 32767 (Neutral point is 0)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetAxisX(uint UserIndex, short Value);

        /// <summary>
        /// Set Value of the left thumb stick Y position
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Value">Stick Position. Range: -32768 to 32767 (Neutral point is 0)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetAxisY(uint UserIndex, short Value);

        /// <summary>
        /// Set Value of the Right thumb stick X position
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Value">Stick Position. Range: -32768 to 32767 (Neutral point is 0)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetAxisRx(uint UserIndex, short Value);

        /// <summary>
        /// Set Value of the Right thumb stick Y position
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Value">Stick Position. Range: -32768 to 32767 (Neutral point is 0)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetAxisRy(uint UserIndex, short Value);

        /// <summary>
        /// D-Pad pressed UP.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetDpadUp(uint UserIndex);

        /// <summary>
        /// D-Pad pressed DOWN.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetDpadDown(uint UserIndex);

        /// <summary>
        /// D-Pad pressed LEFT.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetDpadLeft(uint UserIndex);

        /// <summary>
        /// D-Pad pressed RIGHT.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetDpadRight(uint UserIndex);

        /// <summary>
        /// D-Pad is released.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetDpadOff(uint UserIndex);

        /// <summary>
        /// Button Guide Pressed/Released.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="Press">TRUE (Button Pressed) or FALSE (Button Released)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool SetBtnGD(uint UserIndex, bool Press);
        #endregion

        #region Feedback Functions
        // The following functions are used for getting feedback from the vXbox device. These functions poll the device.

        /// <summary>
        /// Get the serial number of the LED that should light on the vXbox controller.<para/>
        /// Note that this is not the slot number. Rather, it is a arbitrary number in
        /// the range 1 to 4 that the system attach to the device.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="pLed">The serial number of the LED. Range: 1-4</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool GetLedNumber(uint UserIndex, uint pLed);

        /// <summary>
        /// The left motor is the low-frequency rumble motor. The right motor is the high-frequency rumble motor.<para/>
        /// The two motors are not the same, and they create different vibration effects.
        /// </summary>
        internal struct PXINPUT_VIBRATION {
            /// <summary>
            /// Speed of the left motor.<para/>
            /// Valid values are in the range 0 to 65,535. Zero signifies no motor use; 65,535 signifies 100 percent motor use.
            /// </summary>
            internal ushort wLeftMotorSpeed;
            /// <summary>
            /// Speed of the right motor.<para/>
            /// Valid values are in the range 0 to 65,535. Zero signifies no motor use; 65,535 signifies 100 percent motor use.
            /// </summary>
            internal ushort wRightMotorSpeed;
        }
        /// <summary>
        /// Get the vibration intensity of each of the two vibrating motors.
        /// </summary>
        /// <param name="UserIndex">Slot Index. Range: 1 to 4</param>
        /// <param name="pVib">Structure holding the output data. (See description)</param>
        /// <returns>TRUE if function succeeded. Otherwise FALSE.</returns>
        [DllImport("vXboxInterface.dll")]
        internal static extern bool GetVibration(uint UserIndex, ref PXINPUT_VIBRATION pVib);

        #endregion
    }

    #region _Enumerations
    public enum Button
    {
        A,
        B,
        X,
        Y,
        Start,
        Back,
        LeftStick,
        RightStick,
        LeftBumper,
        RightBumper,
        LeftTrigger,
        RightTrigger,
        DpadUp,
        DpadDown,
        DpadLeft,
        DpadRight,
        Guide
    }
    #endregion

    /// <summary>
    /// Wrapper for vXboxInterface.dll
    /// </summary>
    public class VirtualXboxController : IDisposable
    {
        /// <summary>
        /// The highest value an axis can be set to.
        /// </summary>
        public const int AXIS_MAX = 32767;


        /// <summary>
        /// The lowest value an axis can be set to.
        /// </summary>
        public const int AXIS_MIN = -32768;


        /// <summary>
        /// Indicates whether this device is owned by and connected to the calling application.
        /// </summary>
        public bool Acquired => VirtualXboxInterface.isControllerOwned(SlotIndex);


        /// <summary>
        /// The index of the slot this device is plugged into.
        /// </summary>
        public uint SlotIndex { get; }


        /// <exception cref="ArgumentException">When the slot index is outside the range 1 to 4.</exception>
        /// <param name="index">Slot index of the vXbox device that this object should manage. Range: 1 to 4.</param>
        /// <param name="forceOwnership">If true, forces an un-plug before trying to acquire the device. Warning: This parameter may remove a vXbox device that is owned by another process.</param>
        public VirtualXboxController(uint index, bool forceOwnership = false)
        {
            if (index < 1 || index > 4) 
                throw new ArgumentException($"Invalid slot index. Range: 1 to 4 but was {index}.");

            SlotIndex = index;

#if DEBUG
            System.Diagnostics.Debug.WriteLine("###################");
            System.Diagnostics.Debug.WriteLine($"# Virtual Bus exists?: {VirtualXboxInterface.isVBusExists()}");
            System.Diagnostics.Debug.WriteLine($"# Controller {SlotIndex} exists?: {VirtualXboxInterface.isControllerExists(SlotIndex)}");
#endif

            Acquire(forceOwnership);

#if DEBUG
            System.Diagnostics.Debug.WriteLine($"# Controller {SlotIndex} acquired?: {Acquired}");
            System.Diagnostics.Debug.WriteLine("###################");
#endif
            Reset();
        }


        /// <summary>
        /// Connect to the virtual controller.
        /// </summary>
        /// <returns>TRUE if operation succeeds. Otherwise FALSE.</returns>
        /// <exception cref="InvalidOperationException">When the virtual bus was not found.</exception>
        /// <param name="force">If true, forces an un-plug before trying to acquire the device. Warning: This parameter may remove a vXbox device that is owned by another process.</param>
        public bool Acquire(bool force = false)
        {
            if (!VirtualXboxInterface.isVBusExists())
                throw new InvalidOperationException("The virtual bus was not found. You can plug-in vXbox devices only if the bus exists.");
            Release(force);
            return VirtualXboxInterface.PlugIn(SlotIndex);
        }


        /// <summary>
        /// Disconnect from the virtual controller.
        /// </summary>
        /// <returns>TRUE if operation succeeds. Otherwise FALSE.</returns>
        /// <exception cref="InvalidOperationException">When the virtual bus was not found.</exception>
        /// <param name="force">If true, forces an un-plug of the device. Warning: This parameter may remove a vXbox device that is owned by another process.</param>
        public bool Release(bool force = false)
        {
            if (!VirtualXboxInterface.isVBusExists())
                throw new InvalidOperationException("The virtual bus was not found. You can un-plug vXbox devices only if the bus exists.");
            return force ? VirtualXboxInterface.UnPlugForce(SlotIndex) : VirtualXboxInterface.UnPlug(SlotIndex);
        }


        /// <summary>
        /// Resets the device and unplugs it.
        /// </summary>
        public void Dispose()
        {
            Reset();
            Release(Acquired);
        }


        /// <summary>
        /// Checks if the vXbox device is ready and functional.
        /// </summary>
        /// <returns>TRUE if the virtual bus and the controller exists. Otherwise FALSE.</returns>
        public bool Exists()
        {
            return VirtualXboxInterface.isVBusExists() && VirtualXboxInterface.isControllerExists(SlotIndex);
        }


        /// <summary>
        /// Centers all axis of both - left and right - virtual sticks.
        /// </summary>
        /// <returns>TRUE if every axis were successfully reset. Otherwise FALSE.</returns>
        public bool ResetAxis()
        {
            return SetAxisX(0) && SetAxisY(0)
                               && SetAxisRx(0)
                               && SetAxisRy(0);
        }


        /// <summary>
        /// Releases all buttons.
        /// </summary>
        /// <returns>TRUE if all buttons were successfully released. Otherwise FALSE.</returns>
        public bool ResetButtons()
        {
            var success = true;
            foreach (Button btn in Enum.GetValues(typeof(Button)))
                success = success && Release(btn);
            return success;
        }


        /// <summary>
        /// Resets this virtual device to its neutral state, resetting every axis and all buttons.
        /// </summary>
        /// <returns>TRUE if everything was successfully reset. Otherwise FALSE.</returns>
        public bool Reset()
        {
            return ResetAxis() && ResetButtons();
        }


        #region Feeding Data
        /// <summary>
        /// Sets the <c>X</c>-axis of the left stick.
        /// </summary>
        /// <returns>TRUE if operation succeeds. Otherwise FALSE.</returns>
        public bool SetAxisX(int value)
        {
            return VirtualXboxInterface.SetAxisX(SlotIndex, (short)value.Clamp(AXIS_MIN, AXIS_MAX));
        }


        /// <summary>
        /// Sets the <c>Y</c>-axis of the left stick.
        /// </summary>
        /// <returns>TRUE if operation succeeds. Otherwise FALSE.</returns>
        public bool SetAxisY(int value)
        {
            return VirtualXboxInterface.SetAxisY(SlotIndex, (short)value.Clamp(AXIS_MIN, AXIS_MAX));
        }


        /// <summary>
        /// Sets the <c>X</c>-axis of the right stick.
        /// </summary>
        /// <returns>TRUE if operation succeeds. Otherwise FALSE.</returns>
        public bool SetAxisRx(int value)
        {
            return VirtualXboxInterface.SetAxisRx(SlotIndex, (short)value.Clamp(AXIS_MIN, AXIS_MAX));
        }


        /// <summary>
        /// Sets the <c>Y</c>-axis of the right stick.
        /// </summary>
        /// <returns>TRUE if operation succeeds. Otherwise FALSE.</returns>
        public bool SetAxisRy(int value)
        {
            return VirtualXboxInterface.SetAxisRy(SlotIndex, (short)value.Clamp(AXIS_MIN, AXIS_MAX));
        }


        /// <summary>
        /// Presses a button.
        /// </summary>
        /// <param name="button">The button that you want pressed.</param>
        /// <param name="pressure">Pressure amount if <c>button</c> is the <c>Left</c>- or <c>RightTrigger</c>. Range: 0-255.
        /// A value of 0 means the trigger will be released.
        /// </param>
        /// <returns>TRUE if operation succeeds. Otherwise FALSE.</returns>
        public bool Press(Button button, byte pressure = 255)
        {
            if (pressure == 0) Release(button);
            switch (button)
            {
                case Button.LeftTrigger: return VirtualXboxInterface.SetTriggerL(SlotIndex, pressure);
                case Button.RightTrigger: return VirtualXboxInterface.SetTriggerR(SlotIndex, pressure);
                case Button.A: return VirtualXboxInterface.SetBtnA(SlotIndex, true);
                case Button.B: return VirtualXboxInterface.SetBtnB(SlotIndex, true);
                case Button.X: return VirtualXboxInterface.SetBtnX(SlotIndex, true);
                case Button.Y: return VirtualXboxInterface.SetBtnY(SlotIndex, true);
                case Button.Start: return VirtualXboxInterface.SetBtnStart(SlotIndex, true);
                case Button.Back: return VirtualXboxInterface.SetBtnBack(SlotIndex, true);
                case Button.LeftStick: return VirtualXboxInterface.SetBtnLT(SlotIndex, true);
                case Button.RightStick: return VirtualXboxInterface.SetBtnRT(SlotIndex, true);
                case Button.LeftBumper: return VirtualXboxInterface.SetBtnLB(SlotIndex, true);
                case Button.RightBumper: return VirtualXboxInterface.SetBtnRB(SlotIndex, true);
                case Button.DpadLeft: return VirtualXboxInterface.SetDpadLeft(SlotIndex);
                case Button.DpadRight: return VirtualXboxInterface.SetDpadRight(SlotIndex);
                case Button.DpadUp: return VirtualXboxInterface.SetDpadUp(SlotIndex);
                case Button.DpadDown: return VirtualXboxInterface.SetDpadDown(SlotIndex);
                case Button.Guide: return VirtualXboxInterface.SetBtnGD(SlotIndex, true);
                default: return false;
            }
        }


        /// <summary>
        /// Releases a button.
        /// </summary>
        /// <param name="button">The button that you want released.</param>
        /// <param name="delay">Delay in milliseconds before the button is released.</param>
        /// <returns>TRUE if operation succeeds. Otherwise FALSE.</returns>
        public bool Release(Button button, int delay = 100)
        {
            if (delay > 0) Thread.Sleep(delay);
            switch (button)
            {
                case Button.LeftTrigger: return VirtualXboxInterface.SetTriggerL(SlotIndex,0);
                case Button.RightTrigger: return VirtualXboxInterface.SetTriggerR(SlotIndex, 0);
                case Button.A: return VirtualXboxInterface.SetBtnA(SlotIndex, false);
                case Button.B: return VirtualXboxInterface.SetBtnB(SlotIndex, false);
                case Button.X: return VirtualXboxInterface.SetBtnX(SlotIndex, false);
                case Button.Y: return VirtualXboxInterface.SetBtnY(SlotIndex, false);
                case Button.Start: return VirtualXboxInterface.SetBtnStart(SlotIndex, false);
                case Button.Back: return VirtualXboxInterface.SetBtnBack(SlotIndex, false);
                case Button.LeftStick: return VirtualXboxInterface.SetBtnLT(SlotIndex, false);
                case Button.RightStick: return VirtualXboxInterface.SetBtnRT(SlotIndex, false);
                case Button.LeftBumper: return VirtualXboxInterface.SetBtnLB(SlotIndex, false);
                case Button.RightBumper: return VirtualXboxInterface.SetBtnRB(SlotIndex, false);
                case Button.DpadLeft: return VirtualXboxInterface.SetDpadOff(SlotIndex);
                case Button.DpadRight: return VirtualXboxInterface.SetDpadOff(SlotIndex);
                case Button.DpadUp: return VirtualXboxInterface.SetDpadOff(SlotIndex);
                case Button.DpadDown: return VirtualXboxInterface.SetDpadOff(SlotIndex);
                case Button.Guide: return VirtualXboxInterface.SetBtnGD(SlotIndex, false);
                default: return false;
            }
        }

        #region Button Stroke Variants


        /// <summary>
        /// Presses and then immediately releases a button once.
        /// </summary>
        /// <returns>TRUE if the button was successfully pressed and released. Otherwise FALSE.</returns>
        public bool Stroke(Button button)
        {
            var success = Press(button);
            return success && Release(button);
        }


        /// <summary>
        /// Presses and then immediately releases a button given the specified times.
        /// </summary>
        /// <returns>TRUE if the button was successfully pressed and released in every iteration. Otherwise FALSE.</returns>
        public bool Stroke(Button button, int times)
        {
            var success = true;
            for (int i = 0; i < times; i++)
                success = success && Stroke(button);
            return success;
        }


        /// <summary>
        /// Presses and then immediately releases multiple buttons.
        /// </summary>
        /// <returns>TRUE if all buttons were successfully pressed and released. Otherwise FALSE.</returns>
        public bool Stroke(Button[] buttons)
        {
            var success = true;
            foreach (var button in buttons)
                success = Press(button) && Release(button);
            return success;
        }


        /// <summary>
        /// Presses and then immediately releases multiple buttons using a leading button as modifier which is released last.</para>
        /// The buttons are released in reverse order.
        /// </summary>
        /// <returns>TRUE if all buttons were successfully pressed and released. Otherwise FALSE.</returns>
        public bool Stroke(Button modifier, Button[] buttons)
        {
            var success = Press(modifier);
            foreach (var button in buttons)
                success = Press(button) && success;
            foreach (var button in buttons.Reverse())
                success = Release(button) && success;
            return success && Release(modifier);
        }


        /// <summary>
        /// Presses and then immediately releases a button using a leading button as modifier which is released last.
        /// </summary>
        /// <returns>TRUE if all buttons were successfully pressed and released. Otherwise FALSE.</returns>
        public bool Stroke(Button modifier, Button button)
        {
            var success = Press(modifier);
            success = success && Stroke(button);
            return success && Release(modifier);
        }
        #endregion

        #endregion


        /// <summary>
        /// Gets the current vibration values of the left and right rumble motors.<para/>
        /// </summary>
        /// <exception cref="InvalidOperationException">When the vibration values weren't retrievable.</exception>
        /// <returns>A tuple in which the first item contains the value of the low-frequency rumble motor and<para/>
        /// the second item the value of the high-frequency rumble motor.
        /// </returns>
        public (ushort, ushort) GetRumbleMotorFrequencies() {
            var pxInput = new VirtualXboxInterface.PXINPUT_VIBRATION();
            if (!VirtualXboxInterface.GetVibration(SlotIndex, ref pxInput))
                throw new InvalidOperationException("Unable to get the vibration values of the rumble motors.");
            return (pxInput.wLeftMotorSpeed, pxInput.wRightMotorSpeed);
        }
    }
}
