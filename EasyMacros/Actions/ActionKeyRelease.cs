using EasyMacros.Macros;
using EasyMacros.Utilities;

namespace EasyMacros.Actions
{
    public class ActionKeyRelease : MacroAction
    {
        public byte Key;

        public ActionKeyRelease(byte K)
        {
            Key = K;
        }

        public override void Do()
        {
            KeySender.KeyRelease(Key);
        }
    }
}
