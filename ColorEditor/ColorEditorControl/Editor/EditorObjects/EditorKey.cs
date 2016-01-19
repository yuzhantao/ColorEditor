using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    class EditorKey : EditorContent
    {
        public string KeyText { get; set; }

        public EditorKey(string text)
        {
            this.KeyText = text;
        }

        public override void Draw(IDraw draw)
        {
            return;
        }

        public override string getText()
        {
            return this.KeyText;
        }
    }
}
