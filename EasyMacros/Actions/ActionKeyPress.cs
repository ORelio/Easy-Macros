using EasyMacros.Macros;
using EasyMacros.Utilities;

namespace EasyMacros.Actions
{
    public class ActionKeyPress : MacroAction
    {
        public byte Key;

        public ActionKeyPress(byte K)
        {
            Key = K;
        }

        public override void Do()
        {
            KeySender.KeyPress(Key);
        }
    }
}
