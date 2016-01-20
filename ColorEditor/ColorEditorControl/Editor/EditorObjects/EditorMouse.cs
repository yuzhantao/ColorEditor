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
                case MouseKeyType.Left:
                    retText = "MouseLeft";
                    break;
                case MouseKeyType.Middle:
                    retText = "MouseMiddle";
                    break;
                case MouseKeyType.Right:
                    retText = "MouseRight";
                    break;
            }

            return retText;
        }

        /// <summary>
        /// 鼠标按键类型
        /// </summary>
        public enum MouseKeyType
        {
            Left,
            Middle,
            Right
        }
    }
}
