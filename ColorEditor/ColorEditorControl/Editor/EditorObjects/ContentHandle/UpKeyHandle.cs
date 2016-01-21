using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    class UpKeyHandle : IContentHandle
    {
        public void Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content == null || content.getText() != ((char)38).ToString()) return;

            this.EditorSelectIndexUpMove(area, content);        // 当按向上按钮时，编辑器的选择索引上移一行。
        }

        /// <summary>
        /// 根据当前编辑器的索引位置，计算索引向上移动的位置，并移动
        /// </summary>
        /// <param name="area"></param>
        /// <param name="content"></param>
        private void EditorSelectIndexUpMove(EditorEditArea area, EditorContent content)
        {
            bool isInUpLine = false;                            // 是否检测到了上一行
            int lineEnterIndex = -1;                            // 换行对象
            for (int i = area.SelectIndex; i > 0; i--)
            {
                EditorContent cnt = area.ContentList[i - 1];
                if (cnt.getText() == "\r" || i==1)
                {
                    if (!isInUpLine)
                    {
                        // 如果进入了上一行
                        lineEnterIndex = i;          // 获取上一行换行符对象的索引
                        isInUpLine = true;           // 如果检查到了换行符，就代表是上一行
                    }
                    else
                    {
                        // 如果上一行尺寸小于光标在当前行的宽度，就将光标移动到换行符前面
                        if (lineEnterIndex > 0)
                        {
                            area.SelectIndex = lineEnterIndex - 1;
                        }
                        break;
                    }

                    continue;
                }

                if (cnt.Rectangle.IsCross(area.Caret.Rectangle.Left, cnt.Rectangle.Top+cnt.Rectangle.Height, 1, 1))
                {
                    area.SelectIndex = i - 1;
                    break;
                }
            }
        }
    }
}
