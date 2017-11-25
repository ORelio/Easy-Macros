using System;
using System.Collections.Generic;
using System.IO;

namespace EasyMacros.Utilities
{
    /// <summary>
    /// Utility class for loading/saving app settings
    /// </summary>
    public static class SettingsFile
    {
        public const string SaveFile = "Macros.ini";

        public static void Load(ref int ActivateKey)
        {
            try
            {
                string[] settings = File.ReadAllLines(SaveFile);
                if (settings[0] == "Macros Settings")
                {
                    for (int i = 1; i < settings.Length; i++)
                    {
                        string[] setting = settings[i].Split('=');
                        if (setting.Length >= 2)
                        {
                            switch (setting[0].ToLower())
                            {
                                case "activatekey":
                                    try { ActivateKey = Int32.Parse(setting[1]); }
                                    catch { }
                                    break;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public static void Save(int ActivateKey)
        {
            List<String> lines = new List<string>();
            lines.Add("Macros Settings");
            lines.Add("ActivateKey=" + ActivateKey);
            File.WriteAllLines(SaveFile, lines);
        }
    }
}
