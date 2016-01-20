using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    class DownKeyHandle : IContentHandle
    {
        public bool Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content == null || content.getText() != ((char)40).ToString()) return false;

            this.EditorSelectIndexDownMove(area, content);        // 当按向下按钮时，编辑器的选择索引下移一行。

            return true;
        }

        /// <summary>
        /// 根据当前编辑器的索引位置，计算索引向下移动的位置，并移动
        /// </summary>
        /// <param name="area"></param>
        /// <param name="content"></param>
        private void EditorSelectIndexDownMove(EditorEditArea area, EditorContent content)
        {
            bool isInDownLine = false;                          // 是否检测到了下一行

            for (int i = area.SelectIndex; i < area.ContentList.Count(); i++)
            {
                EditorContent cnt = area.ContentList[i - 1];
                if (cnt.getText() == "\r")
                {
                    if (!isInDownLine)
                    {
                        // 如果进入了下一行
                        isInDownLine = true;                    // 如果检查到了换行符，就代表是上一行
                    }
                    else
                    {
                        // 如果上一行尺寸小于光标在当前行的宽度，就将光标移动到换行符前面
                        area.SelectIndex = i-1;
                        break;
                    }

                    continue;
                }

                if (!isInDownLine) continue;

                if (cnt.Rectangle.IsCross(area.Caret.Rectangle.Left, cnt.Rectangle.Bottom, 1, 1))
                {
                    area.SelectIndex = i-1;
                    break;
                }else if (i == area.ContentList.Count() - 1)
                {
                    area.SelectIndex = i + 1;
                }
            }
        }
    }
}
