using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using EasyMacros.Utilities;
using EasyMacros.Actions;

namespace EasyMacros.Macros
{
    /// <summary>
    /// Macro file save/load utility
    /// </summary>
    public static class MacroFiles
    {
        public const string MacrosDir = "Macros";
        public const string MacrosExt = ".macro";
        public const string DisablePrefix = "[OFF] ";

        public static MacroSet Load()
        {
            MacroSet macroSet = new MacroSet();

            if (Directory.Exists(MacrosDir))
            {
                string[] files = Directory.GetFiles(MacrosDir, "*" + MacrosExt);
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Length < 13 || files[i].Substring((MacrosDir + Path.DirectorySeparatorChar).Length, DisablePrefix.Length) != DisablePrefix)
                    {
                        Macro macro = LoadMacroFile(File.ReadAllLines(files[i]));
                        if (macro != null) { macroSet.Add(macro); }
                    }
                }
            }

            return macroSet;
        }

        public static Macro LoadMacroFile(string[] file)
        {
            if (file.Length > 0)
            {
                string[] args = file[0].Split(' ');

                if (args.Length <= 1) { args = new string[2] { args[0], "ÿ" }; }
                if (args[0].ToLower().Contains("macro"))
                {
                    Macro macro = new Macro(KeyConverter.Name2WinFormKey(args[1]));

                    if (args[0].ToLower().Contains("mouse"))
                    {
                        macro.Type = MacroType.Mouse;
                        macro.TriggerKey = KeyConverter.Name2WinFormKey("" + args[1][0]);
                    }
                    else if (args[0].ToLower().Contains("winopen"))
                    {
                        macro.Type = MacroType.WinOpen;
                    }
                    else if (args[0].ToLower().Contains("startup"))
                    {
                        macro.Type = MacroType.Startup;
                    }
                    else if (args[0].ToLower().Contains("idle"))
                    {
                        macro.Type = MacroType.IDLE;
                        try { macro.idletime = Int32.Parse(args[1]); }
                        catch { }
                    }
                    else if (args[0].ToLower().Contains("rewrite"))
                    {
                        macro.Type = MacroType.RewriteKeyboard;
                        string[] tmp = args[1].Split("+".ToCharArray());
                        foreach (string k in tmp)
                        {
                            Keys result = KeyConverter.Name2WinFormKey(k);
                            if (result != Keys.None)
                            {
                                macro.TriggerKeys.Add(result);
                            }
                        }
                    }

                    if (args[0].ToLower().Contains("super"))
                    {
                        macro.Override = true;
                    }

                    if (args.Length >= 3)
                    {
                        macro.targetapp = args[2];
                    }

                    for (int i = 1; i < file.Length; i++)
                    {
                        args = file[i].Split(' ');
                        if (args.Length >= 2)
                        {
                            int time = 0;
                            byte code = 0;
                            Point P = Point.Empty;
                            KeySender.MouseButton button;
                            switch (args[0].ToLower())
                            {
                                case "key":
                                    code = KeyConverter.Name2Key(args[1]);
                                    if (code != 0) { macro.Add(new ActionKeyStroke(code)); }
                                    break;

                                case "keydown":
                                    code = KeyConverter.Name2Key(args[1]);
                                    if (code != 0) { macro.Add(new ActionKeyPress(code)); }
                                    break;

                                case "keyup":
                                    code = KeyConverter.Name2Key(args[1]);
                                    if (code != 0) { macro.Add(new ActionKeyRelease(code)); }
                                    break;

                                case "mouse":
                                    button = KeyConverter.Name2MouseKey(args[1]);
                                    if (args.Length >= 3 && ParsePoint(args[2], ref P))
                                    { macro.Add(new ActionMouseClick(button, P)); }
                                    else macro.Add(new ActionMouseClick(button));
                                    break;

                                case "mousedown":
                                    button = KeyConverter.Name2MouseKey(args[1]);
                                    if (args.Length >= 3 && ParsePoint(args[2], ref P))
                                    { macro.Add(new ActionMousePress(button, P)); }
                                    else macro.Add(new ActionMousePress(button));
                                    break;

                                case "mouseup":
                                    button = KeyConverter.Name2MouseKey(args[1]);
                                    if (args.Length >= 3 && ParsePoint(args[2], ref P))
                                    { macro.Add(new ActionMouseRelease(button, P)); }
                                    else macro.Add(new ActionMouseRelease(button));
                                    break;

                                case "sleep":
                                    try { time = Int32.Parse(args[1]); }
                                    catch { }
                                    if (time != 0) { macro.Add(new ActionSleep(time)); }
                                    break;

                                case "run":
                                    try { macro.Add(new ActionRun(file[i].Substring(4))); }
                                    catch { }
                                    break;

                                case "paste":
                                    try { macro.Add(new ActionPaste(file[i].Substring(6))); }
                                    catch { }
                                    break;

                                case "close":
                                    try { macro.Add(new ActionClose(file[i].Substring(6))); }
                                    catch { }
                                    break;

                                case "kill":
                                    macro.Add(new ActionKill(args[1]));
                                    break;
                            }
                        }
                    }

                    return macro;
                }
                else return null;
            }
            else return null;
        }

        private static bool ParsePoint(string toparse, ref Point P)
        {
            int posX; int posY;
            string[] coords = toparse.Split(',');
            if (coords.Length == 2 && Int32.TryParse(coords[0], out posX) && Int32.TryParse(coords[1], out posY))
            {
                P.X = posX;
                P.Y = posY;
                return true;
            }
            else return false;
        }
    }
}
