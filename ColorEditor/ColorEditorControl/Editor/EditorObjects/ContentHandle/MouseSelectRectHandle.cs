using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    /// <summary>
    /// 鼠标选择了一个区域的处理效果
    /// </summary>
    class MouseSelectRectHandle : IContentHandle
    {
        private bool m_isMouseDown = false;             // 鼠标是否点下
        private int m_selectStartIndex = -1;            // 旋转开始的索引位置
            
        public bool Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content.GetType() != typeof(EditorMouse)) return false;

            EditorMouse mouse = (EditorMouse)content;
            switch (mouse.KeyType)
            {
                case EditorMouse.MouseKeyType.LeftDown:         // 鼠标左键按下
                    this.m_isMouseDown = true;
                    m_selectStartIndex = this.Pos2Index(area, content.Rectangle.Left, content.Rectangle.Top);
                    area.SelectStart = m_selectStartIndex;
                    area.SelectEnd = m_selectStartIndex;
                    break;
                case EditorMouse.MouseKeyType.LeftUp:           // 鼠标左键抬起
                    this.m_isMouseDown = false;
                    break;
                case EditorMouse.MouseKeyType.Move:             // 鼠标移动
                    if (!this.m_isMouseDown) break;             // 如果鼠标没点下，不执行已下代码

                    int endIndex = this.Pos2Index(area, content.Rectangle.Left, content.Rectangle.Top);

                    if (this.m_selectStartIndex < endIndex)
                    {
                        area.SelectStart = this.m_selectStartIndex;
                        area.SelectEnd = endIndex + 1;
                    }else if(this.m_selectStartIndex > endIndex)
                    {
                        area.SelectEnd = this.m_selectStartIndex + 1;
                        area.SelectStart = endIndex;
                    }else if (this.m_selectStartIndex == endIndex)
                    {
                        area.SelectStart = this.m_selectStartIndex;
                        area.SelectEnd = this.m_selectStartIndex;
                    }
                    
                    area.Caret.Hide();                           // 隐藏光标
#if DEBUG
                    Console.WriteLine(string.Format("select editor index:start={0}    end={1}", area.SelectStart, area.SelectEnd));
#endif
                    break;
            }

            return false;
        }

        /// <summary>
        /// 通过指定坐标转为编辑器中内容的索引值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int Pos2Index(EditorEditArea area, float x,float y)
        {
            int retIndex = -1;
            int index = -1;

            foreach(EditorContent content in area.ContentList)
            {
                index++;
                if (content.Rectangle.IsCross(x, y, 1, 1))
                {
                    retIndex = index;
                }
            }
            return retIndex;
        }
    }
}
