using System;
using System.Diagnostics;
using EasyMacros.Macros;

namespace EasyMacros.Actions
{
    public class ActionClose : MacroAction
    {
        public string toclose;
        public ActionClose(string windowtoclose)
        {
            toclose = windowtoclose;
        }
        public override void Do()
        {
            Process[] procs = Process.GetProcesses();
            for (int i = 0; i < procs.Length; i++)
            {
                if (procs[i].ProcessName.ToLower() + ".exe" == toclose.ToLower())
                {
                    procs[i].CloseMainWindow();
                }
                else if (procs[i].ProcessName.ToLower().Contains(toclose.ToLower()))
                {
                    procs[i].CloseMainWindow();
                }
                else if (procs[i].MainWindowHandle != IntPtr.Zero && procs[i].MainWindowTitle.ToLower().Contains(toclose.ToLower()))
                {
                    procs[i].CloseMainWindow();
                }
            }
        }
    }
}
