using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    /// <summary>
    /// 退个按键的处理
    /// </summary>
    class BackspaceKeyHandle : IContentHandle
    {
        public bool Insert(EditorEditArea area, int pos, EditorContent content)
        {
            if (pos <= 0) return false;
            if (content == null || content.getText() != "\b") return false;

            area.Remove(pos - 1, pos);
            area.SelectIndex = pos - 1;
            return true;
        }
    }
}
