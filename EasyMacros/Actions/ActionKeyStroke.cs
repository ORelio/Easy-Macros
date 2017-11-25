using EasyMacros.Macros;
using EasyMacros.Utilities;

namespace EasyMacros.Actions
{
    public class ActionKeyStroke : MacroAction
    {
        public byte Key;

        public ActionKeyStroke(byte K)
        {
            Key = K;
        }

        public override void Do()
        {
            KeySender.KeyStroke(Key);
        }
    }
}
