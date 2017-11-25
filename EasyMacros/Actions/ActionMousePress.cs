using System.Drawing;
using EasyMacros.Utilities;
using EasyMacros.Macros;

namespace EasyMacros.Actions
{
    public class ActionMousePress : MacroAction
    {
        public KeySender.MouseButton Button;
        public Point ClickPos = Point.Empty;
        public bool CustomPos = false;

        public ActionMousePress(KeySender.MouseButton B, Point Coordinates)
        {
            Button = B;
            CustomPos = true;
            ClickPos = Coordinates;
        }

        public ActionMousePress(KeySender.MouseButton B)
        {
            Button = B;
            CustomPos = false;
        }

        public override void Do()
        {
            if (CustomPos)
            {
                KeySender.MousePress(Button, ClickPos);
            }
            else KeySender.MousePress(Button);
        }
    }
}
