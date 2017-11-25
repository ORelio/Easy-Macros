using System.Windows.Forms;
using EasyMacros.Macros;
using EasyMacros.Utilities;

namespace EasyMacros.Actions
{
    public class ActionPaste : MacroAction
    {
        public string topaste;
        public ActionPaste(string textToPaste)
        {
            topaste = textToPaste;
        }
        public override void Do()
        {
            string previous_clipboard = Clipboard.GetText();
            Clipboard.SetText(topaste);
            System.Threading.Thread.Sleep(50);
            KeySender.KeyPress(KeyConverter.Name2Key(KeyConverter.WinFormKey2Name(Keys.LControlKey)));
            KeySender.KeyStroke(KeyConverter.Name2Key(KeyConverter.WinFormKey2Name(Keys.V)));
            KeySender.KeyRelease(KeyConverter.Name2Key(KeyConverter.WinFormKey2Name(Keys.LControlKey)));
            System.Threading.Thread.Sleep(50);
            try
            {
                Clipboard.SetText(previous_clipboard);
            }
            catch
            {
                try
                {
                    Clipboard.SetText("");
                }
                catch { }
            }
        }
    }
}
