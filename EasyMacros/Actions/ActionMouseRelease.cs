using System.Drawing;
using EasyMacros.Utilities;
using EasyMacros.Macros;

namespace EasyMacros.Actions
{
    public class ActionMouseRelease : MacroAction
    {
        public KeySender.MouseButton Button;
        public Point ClickPos = Point.Empty;
        public bool CustomPos = false;

        public ActionMouseRelease(KeySender.MouseButton B, Point Coordinates)
        {
            Button = B;
            CustomPos = true;
            ClickPos = Coordinates;
        }

        public ActionMouseRelease(KeySender.MouseButton B)
        {
            Button = B;
            CustomPos = false;
        }

        public override void Do()
        {
            if (CustomPos)
            {
                KeySender.MouseRelease(Button, ClickPos);
            }
            else KeySender.MouseRelease(Button);
        }
    }
}
