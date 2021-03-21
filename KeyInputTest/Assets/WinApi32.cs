using System;
using System.Runtime.InteropServices;

public class WinApi32
{
    [DllImport("user32.dll")]
    public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
}
