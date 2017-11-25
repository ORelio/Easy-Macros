using System.Collections.Generic;
using System.Windows.Forms;

namespace EasyMacros.Macros
{
    /// <summary>
    /// Represents a set of macros
    /// </summary>
    public class MacroSet
    {
        private List<Macro> MacroList = new List<Macro>();

        public List<Macro> getMacros(Keys key, MacroType type)
        {
            List<Macro> Result = new List<Macro>();
            foreach (Macro macro in MacroList)
            {
                if (macro.Type == MacroType.Keyboard || macro.Type == MacroType.Mouse)
                {
                    if (macro.Type == type && macro.TriggerKey == key)
                    {
                        Result.Add(macro);
                    }
                }
                else
                {
                    if (macro.Type == type)
                    {
                        Result.Add(macro);
                    }
                }
            }
            return Result;
        }

        public void Add(Macro m)
        {
            lock (MacroList)
            {
                MacroList.Add(m);
            }
        }
    }
}
