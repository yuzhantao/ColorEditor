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
        public void Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content.GetType() == typeof(EditorMouse))
            {
                this.SetCaretPos(area,content.Rectangle.Left, content.Rectangle.Top);        // 设置光标位置
            }
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
