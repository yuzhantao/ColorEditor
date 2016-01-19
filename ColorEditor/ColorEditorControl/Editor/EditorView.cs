using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using ColorEditorControl.Editor.Draw;
using ColorEditorControl.Editor.EditorObjects;

namespace ColorEditorControl.Editor
{
    public class EditorView:EditorObject
    {
        /// <summary>
        /// 编辑区域
        /// </summary>
        public EditorEditArea EditorArea { set; get; }
        
        /// <summary>
        /// 编辑器视图的构造函数
        /// </summary>
        /// <param name="hand">窗体句柄</param>
        /// <param name="caretBitmap">光标图片</param>
        public EditorView(IntPtr hand,Bitmap caretBitmap)
        {
            this.EditorArea = new EditorEditArea(hand, caretBitmap);        // 初始化编辑器内容区域
        }

        /// <summary>
        /// get view area text
        /// </summary>
        /// <returns></returns>
        public string getText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.EditorArea.getText());
            return sb.ToString();
        }

        public override void Draw(IDraw draw)
        {
            this.EditorArea.Draw(draw);
        }
    }
}
