using System.Collections.Generic;
using System.Windows.Forms;

namespace EasyMacros.Macros
{
    /// <summary>
    /// Represents a single macro
    /// </summary>
    public class Macro
    {
        private static object MacroRunLock = new object();
        public List<Keys> TriggerKeys = new List<Keys>();
        public MacroType Type = MacroType.Keyboard;
        public int idletime = 0;
        public Keys TriggerKey;
        public string targetapp = "";
        public bool Override = false;
        public List<MacroAction> script;

        public Macro(Keys triggerkey)
        {
            TriggerKey = triggerkey;
            script = new List<MacroAction>();
        }

        public Macro(Keys triggerkey, List<MacroAction> actions)
        {
            TriggerKey = triggerkey;
            script = actions;
        }

        public void Add(MacroAction a)
        {
            script.Add(a);
        }

        public void Run()
        {
            lock (MacroRunLock)
            {
                foreach (MacroAction a in script)
                {
                    a.Do();
                }
            }
        }
    }
}
