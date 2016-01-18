using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    /// <summary>
    /// 编辑器的编辑区域
    /// </summary>
    public class EditorArea : EditorContent
    {
        #region 属性
        /// <summary>
        /// 编辑区域的内容
        /// </summary>
        public List<EditorContent> ContentList;

        /// <summary>
        /// 编辑区的光标
        /// </summary>
        public EditorCaret Caret { get; set; }

        /// <summary>
        /// 选择的索引位置
        /// </summary>
        public int SelectIndex { get; set; }

        /// <summary>
        /// 选择的开始位置
        /// </summary>
        public int SelectStart { get; set; }

        /// <summary>
        /// 选择的结束位置
        /// </summary>
        public int SelectEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SelectBackgroundColor { get; set; }

        #endregion

        public EditorArea(IntPtr handle,Bitmap caretBitmap)
        {
            this.ContentList = new List<EditorContent>();       // 初始化区域内容
            this.Caret = new EditorCaret(handle, caretBitmap);          // 设置光标
            this.Caret.Show();
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

        #region 添加

        /// <summary>
        /// 添加编辑内容对象
        /// </summary>
        /// <param name="obj"></param>
        public void Add(EditorContent obj)
        {
            this.Insert(this.SelectIndex, obj);
        }

        /// <summary>
        /// 添加文字对象
        /// </summary>
        /// <param name="font"></param>
        /// <param name="s"></param>
        public void Add(DrawFont font, string s)
        {
            this.InsertText(this.SelectIndex, font, s);
        }

        /// <summary>
        /// 添加文字
        /// </summary>
        /// <param name="pos">添加的位置</param>
        /// <param name="obj">添加的对象</param>
        public void Insert(int pos, EditorContent obj)
        {
            if (!this.FilterBackKey(obj))
            {                           // 过滤退格键
                this.ContentList.Insert(pos, obj);
                this.SelectIndex = pos+1;

                if (Math.Abs(this.SelectStart - this.SelectEnd) > 0) this.Remove(this.SelectStart, this.SelectEnd);
                this.SelectStart = pos;
                this.SelectEnd = pos;
            }
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
                EditorChar newChar = new EditorChar(s.Substring(i, 1), font);       // 生成字符对象
                if(this.FilterBackKey(newChar)) continue;                           // 过滤退格键

                this.ContentList.Insert(pos, newChar);                              // 添加字符到列表
                this.SelectIndex = pos;
            }

            this.SortContent();
        }
        
        /// <summary>
        /// 过滤退格键
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private bool FilterBackKey(EditorContent content)
        {
            if (this.SelectIndex>0 && content.getText() == "\b")
            {
                if (this.SelectIndex > 0)
                {
                    this.Remove(this.SelectIndex-1, this.SelectIndex);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 移除
        public void Remove(int start,int end)
        {
            this.ContentList.RemoveRange(start, end - start);
            this.SelectStart = start;
            this.SelectEnd = start;
            this.SelectIndex = start;
            this.SortContent();
        }
        #endregion

        #region 查找
        public int[] Find(string s)
        {
            int[] findPos = new int[] { };
            //
            //      未实现
            //
            return findPos;
        }
        #endregion

        /// <summary>
        /// 排序编辑区域中的内容
        /// </summary>
        private void SortContent()
        {
            float minLeft = this.Rectangle.Left + this.Rectangle.MarginLeft;
            float minTop = this.Rectangle.Top + this.Rectangle.MarginTop;

            float curLeft = minLeft;
            float curTop = minTop;
            foreach (EditorContent content in this.ContentList)
            {
                content.Rectangle.Left = curLeft;
                content.Rectangle.Right = curLeft + 20;
                content.Rectangle.Top = curTop;
                content.Rectangle.Bottom = curTop + 20;

                curLeft += content.Rectangle.GetWidth();

                if ("\r"==content.getText())
                {
                    curLeft = minLeft;
                    curTop += content.Rectangle.GetHeight();
                }
            }
        }

    }
}
