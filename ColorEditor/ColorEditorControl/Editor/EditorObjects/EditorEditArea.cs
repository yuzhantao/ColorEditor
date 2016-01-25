using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using ColorEditorControl.Editor.Draw;
using ColorEditorControl.Editor.EditorObjects.ContentHandle;

namespace ColorEditorControl.Editor.EditorObjects
{
    /// <summary>
    /// 编辑器的编辑区域
    /// </summary>
    public class EditorEditArea : EditorContent
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
        /// 选择的背景色
        /// </summary>
        public int SelectBackgroundColor { get; set; }

        /// <summary>
        /// 首行缩进的距离
        /// </summary>
        public float FirstLineIndentSpace { get; set; }

        #endregion

        private IDraw TempDraw;

        public EditorEditArea(IntPtr handle,Bitmap caretBitmap)
        {
            this.ContentList = new List<EditorContent>();       // 初始化区域内容
            this.Caret = new EditorCaret(handle, caretBitmap);          // 设置光标
            this.Caret.Show();
            this.SelectBackgroundColor = Color.FromArgb(150,Color.Gray).ToArgb();
            this.FirstLineIndentSpace = 20;
        }

        public override void Draw(IDraw draw)
        {
            if(TempDraw == null)
            {
                TempDraw = (IDraw)draw.Clone();
                this.SortContent();
            }

            int curIndex = -1;
            foreach (EditorContent content in this.ContentList)
            {
                curIndex++;

                // 此判断是判断需要绘制的内容对象是否被选中
                if (curIndex >= Math.Min(this.SelectStart, this.SelectEnd) && 
                    curIndex < Math.Max(this.SelectStart, this.SelectEnd))
                {
                    if (content.GetType() == typeof(EditorImage))
                    {
                        // 如果是图片，在选择状态下先画图片，再画选择的阴影
                        content.Draw(draw);
                        this.DrawBackground(draw, content, this.SelectBackgroundColor);
                    }
                    else
                    {
                        // 默认选中状态是先画背景阴影，再画内容
                        this.DrawBackground(draw, content, this.SelectBackgroundColor);
                        content.Draw(draw);
                    }
                }
                else
                {
                    // 如果是没被选中的内容，则直接绘制对象。
                    content.Draw(draw);
                }
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

        #region 内容的增删查改

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
            ContentHandleContext content = new ContentHandleContext();
            content.Input(this,pos, obj);
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
                this.ContentList.Insert(pos, newChar);                              // 添加字符到列表
                this.SelectIndex = pos;
            }

            this.SortContent();
        }

        #endregion

        #region 移除
        public void Remove(int start,int end)
        {
            this.ContentList.RemoveRange(start, end - start);
            this.SelectIndex = start;
            this.SelectStart = start;
            this.SelectEnd = start;
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

        #endregion

        /// <summary>
        /// 排序编辑区域中的内容及光标位置
        /// </summary>
        private void SortContent()
        {
            this.SetEditorContentsPos();                // 设置编辑内容的位置

            this.SetCaretPos();                         // 设置光标位置
        }

        /// <summary>
        /// 设置编辑内容的配置
        /// </summary>
        private void SetEditorContentsPos()
        {
            float minLeft = this.Rectangle.Left + this.Rectangle.MarginLeft;
            float minTop = this.Rectangle.Top + this.Rectangle.MarginTop;

            float curLeft = minLeft + this.FirstLineIndentSpace;
            float curTop = minTop;
            float curLineMaxHeight = 0;                  // 当前行最大高度

            int currentIndex = -1;
            // 设置每个编辑内容的位置
            foreach (EditorContent content in this.ContentList)
            {
                currentIndex++;                                             // 当前索引

                // 计算当前行的最大高度
                if (curLineMaxHeight == 0)
                {
                    curLeft = minLeft+this.FirstLineIndentSpace;
                    curTop += curLineMaxHeight;

                    curLineMaxHeight = 0;
                    for (int i = currentIndex; i < this.ContentList.Count(); i++)
                    {
                        curLineMaxHeight = Math.Max(curLineMaxHeight, this.ContentList[i].Rectangle.Height);
                        
                        if(i==this.ContentList.Count()-1 || this.ContentList[i].getText() == "\r")
                        {
                            break;
                        }
                    }
                }

                

                if (content.GetType() == typeof(EditorChar))
                {
                    EditorChar charContent = (EditorChar)content;
                    SizeF size = TempDraw.GetDrawStringSize(charContent.getText(), charContent.Font);
                    content.Rectangle.Width = size.Width;
                    content.Rectangle.Height = size.Height;
                }

                content.Rectangle.Left = curLeft;
                content.Rectangle.Top = curTop+curLineMaxHeight-content.Rectangle.Height;               // 设置每行字符底端对齐

                curLeft += content.Rectangle.Width;

                if ("\r" == content.getText())
                {
                    curLeft = minLeft+this.FirstLineIndentSpace;        // 计算换行后最左边的坐标
                    curTop += curLineMaxHeight;                         // 计算回车换行后的top坐标值
                    curLineMaxHeight = 0;
                }
            }
        }

        /// <summary>
        /// 绘制选择区域的背景色
        /// </summary>
        /// <param name="draw">用来绘制图像的设备</param>
        /// <param name="content">内容</param>
        /// <param name="color">背景颜色</param>
        private void DrawBackground(IDraw draw,EditorContent content,int color)
        {
            draw.FillRectangle(
                        color,
                        content.Rectangle.Left,
                        content.Rectangle.Top,
                        content.Rectangle.Width,
                        content.Rectangle.Height,
                        null);
        }

        /// <summary>
        /// 设置光标位置
        /// </summary>
        private void SetCaretPos()
        {
            float minLeft = this.Rectangle.Left + this.Rectangle.MarginLeft;
            if (this.SelectIndex > 0)
            {
                EditorContent curContent = this.ContentList[this.SelectIndex - 1];
                if ("\r" == curContent.getText())
                {
                    this.Caret.Rectangle.Left = minLeft+this.FirstLineIndentSpace;
                    this.Caret.Rectangle.Top = curContent.Rectangle.Top + curContent.Rectangle.Height;
                }
                else
                {
                    this.Caret.Rectangle.Left = curContent.Rectangle.Left + curContent.Rectangle.Width;
                    this.Caret.Rectangle.Top = curContent.Rectangle.Top;
                }

                this.Caret.Rectangle.Height = curContent.Rectangle.Height;
                this.Caret.Draw(null);
                this.Caret.Show();
            }
            else if (this.SelectIndex <= 0)
            {
                this.Caret.Rectangle.Left = this.Rectangle.Left + this.Rectangle.PaddingLeft;
                this.Caret.Rectangle.Top = this.Rectangle.Top + this.Rectangle.MarginTop;
                if (this.ContentList.Count > 0)
                {
                    this.Caret.Rectangle.Height = this.ContentList[0].Rectangle.Height;
                }
                else
                {
                    this.Caret.Rectangle.Height = 20;
                }
                this.Caret.Draw(null);
                this.Caret.Show();
            }
        }
    }
}
