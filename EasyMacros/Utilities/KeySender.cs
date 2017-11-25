using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace EasyMacros.Utilities
{
    /// <summary>
    /// Utility class for generating keyboard/mouse events
    /// </summary>
    public static class KeySender
    {
        [DllImport("user32.dll")]
        public static extern byte VkKeyScan(char ch);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        public static void KeyPress(byte key)
        {
            keybd_event(key, (byte)0x02, 0, UIntPtr.Zero);
        }

        public static void KeyRelease(byte key)
        {
            keybd_event(key, (byte)0x82, (uint)0x2, UIntPtr.Zero);
        }

        public static void KeyStroke(byte key)
        {
            KeyPress(key); KeyRelease(key);
        }

        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        public enum MouseButton { Left, Middle, Right, Previous, Next }

        private enum MouseEvent : uint
        {
            LEFTDOWN = 0x02,
            LEFTUP = 0x04,
            MIDDLEDOWN = 0x20,
            MIDDLEUP = 0x40,
            RIGHTDOWN = 0x08,
            RIGHTUP = 0x10,
            XDOWN = 0x80,
            XUP = 0x100,
            XFLAGPREVIOUS = 0x01,
            XFLAGNEXT = 0x02
        }

        public static void MousePress(MouseButton B)
        {
            MousePress(B, Cursor.Position);
        }

        public static void MousePress(MouseButton B, Point P)
        {
            Cursor.Position = P;
            uint buttoncode = 0;
            uint clicdata = 0;

            switch (B)
            {
                case MouseButton.Left: buttoncode = (uint)MouseEvent.LEFTDOWN; break;
                case MouseButton.Middle: buttoncode = (uint)MouseEvent.MIDDLEDOWN; break;
                case MouseButton.Right: buttoncode = (uint)MouseEvent.RIGHTDOWN; break;
                case MouseButton.Previous: buttoncode = (uint)MouseEvent.XDOWN; clicdata = (uint)MouseEvent.XFLAGPREVIOUS; break;
                case MouseButton.Next: buttoncode = (uint)MouseEvent.XDOWN; clicdata = (uint)MouseEvent.XFLAGNEXT; break;
            }

            mouse_event(buttoncode, (uint)P.X, (uint)P.Y, clicdata, UIntPtr.Zero);
        }

        public static void MouseRelease(MouseButton B)
        {
            MouseRelease(B, Cursor.Position);
        }

        public static void MouseRelease(MouseButton B, Point P)
        {
            Cursor.Position = P;
            uint buttoncode = 0;
            uint clicdata = 0;

            switch (B)
            {
                case MouseButton.Left: buttoncode = (uint)MouseEvent.LEFTUP; break;
                case MouseButton.Middle: buttoncode = (uint)MouseEvent.MIDDLEUP; break;
                case MouseButton.Right: buttoncode = (uint)MouseEvent.RIGHTUP; break;
                case MouseButton.Previous: buttoncode = (uint)MouseEvent.XUP; clicdata = (uint)MouseEvent.XFLAGPREVIOUS; break;
                case MouseButton.Next: buttoncode = (uint)MouseEvent.XUP; clicdata = (uint)MouseEvent.XFLAGNEXT; break;
            }

            mouse_event(buttoncode, (uint)P.X, (uint)P.Y, clicdata, UIntPtr.Zero);
        }

        public static void MouseClick(MouseButton B)
        {
            MouseClick(B, Cursor.Position);
        }

        public static void MouseClick(MouseButton B, Point P)
        {
            MousePress(B, P);
            MouseRelease(B, P);
        }
    }
}
