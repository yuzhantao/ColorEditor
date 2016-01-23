using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    class EditorMouse : EditorContent
    {
        /// <summary>
        /// 鼠标按键的类型
        /// </summary>
        public MouseKeyType KeyType { get; set; }

        public EditorMouse(MouseKeyType type,float x,float y)
        {
            this.KeyType = type;
            this.Rectangle.Left = x;
            this.Rectangle.Top = y;
        }
        public override void Draw(IDraw draw)
        {
            return;
        }

        public override string getText()
        {
            string retText = string.Empty;
            switch (this.KeyType)
            {
                case MouseKeyType.LeftUp:
                    retText = "MouseLeftUp";
                    break;
                case MouseKeyType.LeftDown:
                    retText = "MouseLeftDown";
                    break;
                case MouseKeyType.Middle:
                    retText = "MouseMiddle";
                    break;
                case MouseKeyType.RightUp:
                    retText = "MouseRightUp";
                    break;
                case MouseKeyType.RightDown:
                    retText = "MouseRightDown";
                    break;
            }

            return retText;
        }

        /// <summary>
        /// 鼠标按键类型
        /// </summary>
        public enum MouseKeyType
        {
            Move,
            LeftUp,
            LeftDown,
            Middle,
            RightUp,
            RightDown
        }
    }
}
