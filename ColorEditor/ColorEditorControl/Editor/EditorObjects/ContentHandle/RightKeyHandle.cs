using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    class RightKeyHandle : IContentHandle
    {
        public bool Insert(EditorEditArea area, int pos, EditorContent content)
        {
            if (content == null || content.getText() != ((char)39).ToString()) return false;

            area.SelectIndex = Math.Min(area.ContentList.Count(), pos + 1);
            return true;
        }
    }
}
