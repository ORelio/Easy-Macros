using System.Threading;
using EasyMacros.Macros;

namespace EasyMacros.Actions
{
    public class ActionSleep : MacroAction
    {
        public int duration;
        public ActionSleep(int dur)
        {
            duration = dur;
        }

        public override void Do()
        {
            Thread.Sleep(duration);
        }
    }
}
