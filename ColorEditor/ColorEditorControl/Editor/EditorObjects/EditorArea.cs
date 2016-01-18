using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    /// <summary>
    /// 编辑器的编辑区域
    /// </summary>
    public class EditorArea : EditorContent
    {
        /// <summary>
        /// 编辑区域的内容
        /// </summary>
        public List<EditorContent> ContentList;

        public EditorArea()
        {
            this.ContentList = new List<EditorContent>();
        }

        public override void Draw(IDraw draw)
        {
            foreach (EditorContent ojb in this.ContentList)
            {
                ojb.Draw(draw);
            }
        }

        public override string getText()
        {
            StringBuilder sb = new StringBuilder();
            foreach(EditorContent content in this.ContentList)
            {
                sb.Append(content.getText());
            }


            return sb.ToString();
        }

        /// <summary>
        /// 添加文字
        /// </summary>
        /// <param name="pos">添加的位置</param>
        /// <param name="obj">添加的对象</param>
        public void Insert(int pos, EditorContent obj)
        {
            this.ContentList.Insert(pos, obj);
            this.SortContent();
        }

        /// <summary>
        /// 添加文字
        /// </summary>
        /// <param name="pos">添加的位置</param>
        /// <param name="font">添加的字体</param>
        /// <param name="s">添加的内容</param>
        public void InsertText(int pos, DrawFont font, string s)
        {
            if (String.IsNullOrEmpty(s)) return;

            for (int i = 0; i < s.Length; i++)
            {
                this.Insert(pos, new EditorChar(s.Substring(i,1), font));
            }
        }

        /// <summary>
        /// 排序编辑区域中的内容
        /// </summary>
        private void SortContent()
        {
            float minLeft = this.Rectangle.Left + this.Rectangle.MarginLeft;
            float minTop = this.Rectangle.Top + this.Rectangle.MarginTop;

            float curLeft = minLeft;
            float curTop = minTop;
            foreach(EditorContent content in this.ContentList)
            {
                content.Rectangle.Left = curLeft;
                content.Rectangle.Right = curLeft + 20;
                content.Rectangle.Top = curTop;
                content.Rectangle.Bottom = curTop + 20;

                curLeft += content.Rectangle.GetWidth();

                if (content.ToString() == "\n")
                {
                    curLeft = minLeft;
                    curTop += content.Rectangle.GetHeight();
                }
            }
        }
    }
}
