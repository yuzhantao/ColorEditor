using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects
{
    /// <summary>
    /// 编辑器的编辑区域
    /// </summary>
    class EditArea : EditContent
    {
        /// <summary>
        /// 编辑区域的内容
        /// </summary>
        public List<EditContent> ContentList;

        public override void Draw()
        {
            foreach (EditContent ojb in this.ContentList)
            {
                ojb.Draw();
            }
        }

        public override string getText()
        {
            StringBuilder sb = new StringBuilder();
            foreach(EditContent content in this.ContentList)
            {
                sb.Append(content.getText());
            }


            return sb.ToString();
        }
    }
}
