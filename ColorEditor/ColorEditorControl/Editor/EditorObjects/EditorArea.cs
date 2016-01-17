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
    }
}
