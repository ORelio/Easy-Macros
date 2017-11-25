using System.Drawing;
using EasyMacros.Utilities;
using EasyMacros.Macros;

namespace EasyMacros.Actions
{
    public class ActionMouseClick : MacroAction
    {
        public KeySender.MouseButton Button;
        public Point ClickPos = Point.Empty;
        public bool CustomPos = false;

        public ActionMouseClick(KeySender.MouseButton B, Point Coordinates)
        {
            Button = B;
            CustomPos = true;
            ClickPos = Coordinates;
        }

        public ActionMouseClick(KeySender.MouseButton B)
        {
            Button = B;
            CustomPos = false;
        }

        public override void Do()
        {
            if (CustomPos)
            {
                KeySender.MouseClick(Button, ClickPos);
            }
            else KeySender.MouseClick(Button);
        }
    }
}
