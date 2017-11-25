using System.Diagnostics;
using EasyMacros.Macros;

namespace EasyMacros.Actions
{
    public class ActionKill : MacroAction
    {
        public string process;

        public ActionKill(string name)
        {
            process = name;
        }

        public override void Do()
        {
            ProcessStartInfo P = new ProcessStartInfo("taskkill", "/f /im " + process);
            P.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(P).WaitForExit();
        }
    }
}
