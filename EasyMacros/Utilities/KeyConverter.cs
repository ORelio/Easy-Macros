using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EasyMacros.Utilities
{
    /// <summary>
    /// Utility class mapping key names, key codes, and Keys enumeration
    /// </summary>
    public static class KeyConverter
    {
        private class KeyData
        {
            private string Name_value;
            private Keys KeyCode_value;
            private byte SystemCode_value;

            public string Name { get { return Name_value; } }
            public Keys KeyCode { get { return KeyCode_value; } }
            public byte SystemCode { get { return SystemCode_value; } }

            public KeyData(string name, Keys keycode, byte systemcode)
            {
                Name_value = name;
                KeyCode_value = keycode;
                SystemCode_value = systemcode;
            }
        }

        private static List<KeyData> KeyDictionnary = new List<KeyData>();
        private static bool Dictionnary_Filled = false;
        private static void Init_KeyData()
        {
            KeyDictionnary.Clear();

            /* www.kbdedit.com/manual/low_level_vk_list.html */

            KeyDictionnary.Add(new KeyData("A", Keys.A, 0x41));
            KeyDictionnary.Add(new KeyData("B", Keys.B, 0x42));
            KeyDictionnary.Add(new KeyData("C", Keys.C, 0x43));
            KeyDictionnary.Add(new KeyData("D", Keys.D, 0x44));
            KeyDictionnary.Add(new KeyData("E", Keys.E, 0x45));
            KeyDictionnary.Add(new KeyData("F", Keys.F, 0x46));
            KeyDictionnary.Add(new KeyData("G", Keys.G, 0x47));
            KeyDictionnary.Add(new KeyData("H", Keys.H, 0x48));
            KeyDictionnary.Add(new KeyData("I", Keys.I, 0x49));
            KeyDictionnary.Add(new KeyData("J", Keys.J, 0x4A));
            KeyDictionnary.Add(new KeyData("K", Keys.K, 0x4B));
            KeyDictionnary.Add(new KeyData("L", Keys.L, 0x4C));
            KeyDictionnary.Add(new KeyData("M", Keys.M, 0x4D));
            KeyDictionnary.Add(new KeyData("N", Keys.N, 0x4E));
            KeyDictionnary.Add(new KeyData("O", Keys.O, 0x4F));
            KeyDictionnary.Add(new KeyData("P", Keys.P, 0x50));
            KeyDictionnary.Add(new KeyData("Q", Keys.Q, 0x51));
            KeyDictionnary.Add(new KeyData("R", Keys.R, 0x52));
            KeyDictionnary.Add(new KeyData("S", Keys.S, 0x53));
            KeyDictionnary.Add(new KeyData("T", Keys.T, 0x54));
            KeyDictionnary.Add(new KeyData("U", Keys.U, 0x55));
            KeyDictionnary.Add(new KeyData("V", Keys.V, 0x56));
            KeyDictionnary.Add(new KeyData("W", Keys.W, 0x57));
            KeyDictionnary.Add(new KeyData("X", Keys.X, 0x58));
            KeyDictionnary.Add(new KeyData("Y", Keys.Y, 0x59));
            KeyDictionnary.Add(new KeyData("Z", Keys.Z, 0x5A));

            KeyDictionnary.Add(new KeyData("D0", Keys.D0, 0x30));
            KeyDictionnary.Add(new KeyData("D1", Keys.D1, 0x31));
            KeyDictionnary.Add(new KeyData("D2", Keys.D2, 0x32));
            KeyDictionnary.Add(new KeyData("D3", Keys.D3, 0x33));
            KeyDictionnary.Add(new KeyData("D4", Keys.D4, 0x34));
            KeyDictionnary.Add(new KeyData("D5", Keys.D5, 0x35));
            KeyDictionnary.Add(new KeyData("D6", Keys.D6, 0x36));
            KeyDictionnary.Add(new KeyData("D7", Keys.D7, 0x37));
            KeyDictionnary.Add(new KeyData("D8", Keys.D8, 0x38));
            KeyDictionnary.Add(new KeyData("D9", Keys.D9, 0x39));

            KeyDictionnary.Add(new KeyData("0", Keys.NumPad0, 0x60));
            KeyDictionnary.Add(new KeyData("1", Keys.NumPad1, 0x61));
            KeyDictionnary.Add(new KeyData("2", Keys.NumPad2, 0x62));
            KeyDictionnary.Add(new KeyData("3", Keys.NumPad3, 0x63));
            KeyDictionnary.Add(new KeyData("4", Keys.NumPad4, 0x64));
            KeyDictionnary.Add(new KeyData("5", Keys.NumPad5, 0x65));
            KeyDictionnary.Add(new KeyData("6", Keys.NumPad6, 0x66));
            KeyDictionnary.Add(new KeyData("7", Keys.NumPad7, 0x67));
            KeyDictionnary.Add(new KeyData("8", Keys.NumPad8, 0x68));
            KeyDictionnary.Add(new KeyData("9", Keys.NumPad9, 0x69));

            KeyDictionnary.Add(new KeyData("F1", Keys.F1, 0x70));
            KeyDictionnary.Add(new KeyData("F2", Keys.F2, 0x71));
            KeyDictionnary.Add(new KeyData("F3", Keys.F3, 0x72));
            KeyDictionnary.Add(new KeyData("F4", Keys.F4, 0x73));
            KeyDictionnary.Add(new KeyData("F5", Keys.F5, 0x74));
            KeyDictionnary.Add(new KeyData("F6", Keys.F6, 0x75));
            KeyDictionnary.Add(new KeyData("F7", Keys.F7, 0x76));
            KeyDictionnary.Add(new KeyData("F8", Keys.F8, 0x77));
            KeyDictionnary.Add(new KeyData("F9", Keys.F9, 0x78));
            KeyDictionnary.Add(new KeyData("F10", Keys.F10, 0x79));
            KeyDictionnary.Add(new KeyData("F11", Keys.F11, 0x7A));
            KeyDictionnary.Add(new KeyData("F12", Keys.F12, 0x7B));
            KeyDictionnary.Add(new KeyData("F13", Keys.F13, 0x7C));
            KeyDictionnary.Add(new KeyData("F14", Keys.F14, 0x7D));
            KeyDictionnary.Add(new KeyData("F15", Keys.F15, 0x7E));
            KeyDictionnary.Add(new KeyData("F16", Keys.F16, 0x7F));
            KeyDictionnary.Add(new KeyData("F17", Keys.F17, 0x80));
            KeyDictionnary.Add(new KeyData("F18", Keys.F18, 0x81));
            KeyDictionnary.Add(new KeyData("F19", Keys.F19, 0x82));
            KeyDictionnary.Add(new KeyData("F20", Keys.F20, 0x83));
            KeyDictionnary.Add(new KeyData("F21", Keys.F21, 0x84));
            KeyDictionnary.Add(new KeyData("F22", Keys.F22, 0x85));
            KeyDictionnary.Add(new KeyData("F23", Keys.F23, 0x86));
            KeyDictionnary.Add(new KeyData("F24", Keys.F24, 0x87));

            KeyDictionnary.Add(new KeyData("*", Keys.Multiply, 0x6A));
            KeyDictionnary.Add(new KeyData("+", Keys.Add, 0x6B));
            KeyDictionnary.Add(new KeyData("\\", Keys.Separator, 0x6C));
            KeyDictionnary.Add(new KeyData("-", Keys.Subtract, 0x6D));
            KeyDictionnary.Add(new KeyData(".", Keys.Decimal, 0x6E));
            KeyDictionnary.Add(new KeyData("Dec", Keys.Decimal, 0x6E));
            KeyDictionnary.Add(new KeyData("/", Keys.Divide, 0x6F));
            KeyDictionnary.Add(new KeyData("NumLock", Keys.NumLock, 0x90));

            KeyDictionnary.Add(new KeyData("Scroll", Keys.Scroll, 0x91));
            KeyDictionnary.Add(new KeyData("LShift", Keys.LShiftKey, 0xA0));
            KeyDictionnary.Add(new KeyData("RShift", Keys.RShiftKey, 0xA1));
            KeyDictionnary.Add(new KeyData("LCtrl", Keys.LControlKey, 0xA2));
            KeyDictionnary.Add(new KeyData("RCtrl", Keys.RControlKey, 0xA3));
            KeyDictionnary.Add(new KeyData("LAlt", Keys.LMenu, 0xA4));
            KeyDictionnary.Add(new KeyData("LMenu", Keys.LMenu, 0xA4));
            KeyDictionnary.Add(new KeyData("RAlt", Keys.RMenu, 0xA5));
            KeyDictionnary.Add(new KeyData("RMenu", Keys.RMenu, 0xA5));
            KeyDictionnary.Add(new KeyData("Back", Keys.Back, 0x08));
            KeyDictionnary.Add(new KeyData("Tab", Keys.Tab, 0x09));
            KeyDictionnary.Add(new KeyData("Enter", Keys.Return, 0x0D));
            KeyDictionnary.Add(new KeyData("Return", Keys.Return, 0x0D));
            KeyDictionnary.Add(new KeyData("Shift", Keys.Shift, 0x10));
            KeyDictionnary.Add(new KeyData("Ctrl", Keys.Control, 0x11));
            KeyDictionnary.Add(new KeyData("Alt", Keys.Alt, 0x12));
            KeyDictionnary.Add(new KeyData("Menu", Keys.Alt, 0x12));
            KeyDictionnary.Add(new KeyData("Pause", Keys.Pause, 0x13));
            KeyDictionnary.Add(new KeyData("Caps", Keys.Capital, 0x14));
            KeyDictionnary.Add(new KeyData("Escape", Keys.Escape, 0x1B));
            KeyDictionnary.Add(new KeyData("Esc", Keys.Escape, 0x1B));
            KeyDictionnary.Add(new KeyData("Space", Keys.Space, 0x20));
            KeyDictionnary.Add(new KeyData("End", Keys.End, 0x23));
            KeyDictionnary.Add(new KeyData("Home", Keys.Home, 0x24));
            KeyDictionnary.Add(new KeyData("Left", Keys.Left, 0x25));
            KeyDictionnary.Add(new KeyData("Up", Keys.Up, 0x26));
            KeyDictionnary.Add(new KeyData("Right", Keys.Right, 0x27));
            KeyDictionnary.Add(new KeyData("Down", Keys.Down, 0x28));
            KeyDictionnary.Add(new KeyData("PrintScreen", Keys.PrintScreen, 0x2A));
            KeyDictionnary.Add(new KeyData("Snapshot", Keys.Snapshot, 0x2C));
            KeyDictionnary.Add(new KeyData("Insert", Keys.Insert, 0x2D));
            KeyDictionnary.Add(new KeyData("Delete", Keys.Delete, 0x2E));
            KeyDictionnary.Add(new KeyData("Del", Keys.Delete, 0x2E));
            KeyDictionnary.Add(new KeyData("Winleft", Keys.LWin, 0x5B));
            KeyDictionnary.Add(new KeyData("Winright", Keys.RWin, 0x5C));
            KeyDictionnary.Add(new KeyData("PlayPause", Keys.MediaPlayPause, 0xB3));
            KeyDictionnary.Add(new KeyData("MediaNext", Keys.MediaNextTrack, 0xB0));
            KeyDictionnary.Add(new KeyData("MediaPrevious", Keys.MediaPreviousTrack, 0xB1));
            KeyDictionnary.Add(new KeyData("MediaStop", Keys.MediaStop, 0xB2));
            KeyDictionnary.Add(new KeyData("PageUp", Keys.PageUp, 0x21));
            KeyDictionnary.Add(new KeyData("PageDown", Keys.PageDown, 0x22));
            KeyDictionnary.Add(new KeyData("Apps", Keys.Apps, 0x5D));
            KeyDictionnary.Add(new KeyData("VolumeUp", Keys.VolumeUp, 0xAF));
            KeyDictionnary.Add(new KeyData("VolumeDown", Keys.VolumeDown, 0xAE));
            KeyDictionnary.Add(new KeyData("VolumeMute", Keys.VolumeMute, 0xAD));
            KeyDictionnary.Add(new KeyData("BrowserHome", Keys.BrowserHome, 0xAC));
            KeyDictionnary.Add(new KeyData("LaunchMail", Keys.LaunchMail, 0xB4));
            KeyDictionnary.Add(new KeyData("BrowserSearch", Keys.BrowserSearch, 0xAA));

            KeyDictionnary.Add(new KeyData("Oem1", Keys.Oem1, 0xBA));
            KeyDictionnary.Add(new KeyData("Oem102", Keys.Oem102, 0xE2));
            KeyDictionnary.Add(new KeyData("Oem2", Keys.Oem2, 0xBF));
            KeyDictionnary.Add(new KeyData("Oem3", Keys.Oem3, 0xC0));
            KeyDictionnary.Add(new KeyData("Oem4", Keys.Oem4, 0xDB));
            KeyDictionnary.Add(new KeyData("Oem5", Keys.Oem5, 0xDC));
            KeyDictionnary.Add(new KeyData("Oem6", Keys.Oem6, 0xDD));
            KeyDictionnary.Add(new KeyData("Oem7", Keys.Oem7, 0xDE));
            KeyDictionnary.Add(new KeyData("Oem8", Keys.Oem8, 0xDF));
            KeyDictionnary.Add(new KeyData("OemPlus", Keys.Oemplus, 0xBB));
            KeyDictionnary.Add(new KeyData("OemComma", Keys.Oemcomma, 0xBC));
            KeyDictionnary.Add(new KeyData("OemPeriod", Keys.OemPeriod, 0xBE));

            KeyDictionnary.Add(new KeyData("$", Keys.Oem1, 0xBA));
            KeyDictionnary.Add(new KeyData(">", Keys.Oem102, 0xE2));
            KeyDictionnary.Add(new KeyData(":", Keys.Oem2, 0xBF));
            KeyDictionnary.Add(new KeyData("ù", Keys.Oem3, 0xC0));
            KeyDictionnary.Add(new KeyData(")", Keys.Oem4, 0xDB));
            KeyDictionnary.Add(new KeyData("µ", Keys.Oem5, 0xDC));
            KeyDictionnary.Add(new KeyData("^", Keys.Oem6, 0xDD));
            KeyDictionnary.Add(new KeyData("²", Keys.Oem7, 0xDE));
            KeyDictionnary.Add(new KeyData("!", Keys.Oem8, 0xDF));
            KeyDictionnary.Add(new KeyData("=", Keys.Oemplus, 0xBB));
            KeyDictionnary.Add(new KeyData(",", Keys.Oemcomma, 0xBC));
            KeyDictionnary.Add(new KeyData(";", Keys.OemPeriod, 0xBE));

            Dictionnary_Filled = true;
        }

        private static KeyData FindKeyData(string name)
        {
            if (!Dictionnary_Filled) { Init_KeyData(); }
            string namelow = name.ToLower();

            foreach (KeyData KD in KeyDictionnary)
            {
                if (KD.Name.ToLower() == namelow)
                {
                    return KD;
                }
            }

            return new KeyData(name, Keys.None, 0x00);
        }
        private static KeyData FindKeyData(Keys key)
        {
            if (!Dictionnary_Filled) { Init_KeyData(); }

            foreach (KeyData KD in KeyDictionnary)
            {
                if (KD.KeyCode == key)
                {
                    return KD;
                }
            }

            return new KeyData(String.Format("{0} ({1})", key.ToString(), Translations.Get("unsupported")), key, 0x00);
        }
        private static KeyData FindKeyData(byte systemcode)
        {
            if (!Dictionnary_Filled) { Init_KeyData(); }

            foreach (KeyData KD in KeyDictionnary)
            {
                if (KD.SystemCode == systemcode)
                {
                    return KD;
                }
            }

            return new KeyData("", Keys.None, systemcode);
        }

        public static byte Name2Key(string name) { return FindKeyData(name).SystemCode; }
        public static Keys Name2WinFormKey(string name) { return FindKeyData(name).KeyCode; }
        public static string WinFormKey2Name(Keys key) { return FindKeyData(key).Name; }

        public static KeySender.MouseButton Name2MouseKey(string name)
        {
            try
            {
                switch (name.ToLower()[0])
                {
                    case 'l': return KeySender.MouseButton.Left;
                    case 'r': return KeySender.MouseButton.Right;
                    case 'm': return KeySender.MouseButton.Middle;
                    case 'p': return KeySender.MouseButton.Previous;
                    case 'n': return KeySender.MouseButton.Next;
                }
            }
            catch { }
            return KeySender.MouseButton.Left;
        }
    }
}
