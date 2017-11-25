using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using EasyMacros.Macros;

namespace EasyMacros.Actions
{
    public class ActionRun : MacroAction
    {
        [DllImport("shell32.dll", SetLastError = true)]
        private static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

        private static string[] CommandLineToArgs(string commandLine)
        {
            int argc;
            var argv = CommandLineToArgvW(commandLine, out argc);
            if (argv == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception();
            try
            {
                var args = new string[argc];
                for (var i = 0; i < args.Length; i++)
                {
                    var p = Marshal.ReadIntPtr(argv, i * IntPtr.Size);
                    args[i] = Marshal.PtrToStringUni(p);
                }

                return args;
            }
            finally
            {
                Marshal.FreeHGlobal(argv);
            }
        }

        public string command;

        public ActionRun(string command)
        {
            this.command = command;
        }

        public override void Do()
        {
            string[] args = CommandLineToArgs(command);
            string program = args[0];
            string arguments = "";
            for (int i = 1; i < args.Length; i++)
                arguments += '"' + args[i] + '"' + ' ';
            Process.Start(program, arguments);
        }
    }
}
