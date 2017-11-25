using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EasyMacros.Macros;

namespace EasyMacros
{
    /// <summary>
    /// Easy Macros - by ORelio - (c) 2013.
    /// Allows creating macros for Windows without buying a specific keyboard
    /// This source code is released under the CDDL 1.0 License.
    /// </summary>
    static class Program
    {
        public const string Name = "Easy Macros";
        public const string Version = "1.3.1";
        public const string Year = "2013";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Macro macro = MacroFiles.LoadMacroFile(System.IO.File.ReadAllLines(args[0]));
                if (macro != null)
                    macro.Run();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
        }
    }
}
