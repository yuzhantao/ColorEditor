using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    class EditorLine : EditorContent
    {
        public List<EditorContent> ContentList { get; set; }

        public override void Draw(IDraw draw)
        {
            foreach(EditorContent content in this.ContentList)
            {
                content.Draw(draw);
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
