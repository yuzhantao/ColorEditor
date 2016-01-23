using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    /// <summary>
    ///  鼠标点下
    /// </summary>
    class MouseDownHandle : IContentHandle
    {
        public bool Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content.GetType() != typeof(EditorMouse)) return false;

            EditorMouse mouse = (EditorMouse)content;

            if (mouse.KeyType != EditorMouse.MouseKeyType.LeftDown && mouse.KeyType != EditorMouse.MouseKeyType.RightDown) return false;

            this.SetCaretPos(area, mouse.Rectangle.Left, mouse.Rectangle.Top);        // 设置光标位置

            return false;
        }

        /// <summary>
        /// 根据给定的x,y坐标设置光标位置
        /// </summary>
        /// <param name="area"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetCaretPos(EditorEditArea area, float x, float y)
        {
            int index = 0;
            foreach (EditorContent content in area.ContentList)
            {
                if (content.Rectangle.IsCross(x, y, 1, 1))
                {
                    area.SelectIndex = index + 1;
                    break;
                }
                index++;
            }
        }
    }
}
