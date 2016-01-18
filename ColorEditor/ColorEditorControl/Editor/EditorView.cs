using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ColorEditorControl.Editor.Draw;
using ColorEditorControl.Editor.EditorObjects;

namespace ColorEditorControl.Editor
{
    public class EditorView:EditorObject
    {
        /// <summary>
        /// 编辑区域
        /// </summary>
        public EditorArea EditorArea { set; get; }
        
        public EditorView()
        {
            this.EditorArea = new EditorArea();
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
