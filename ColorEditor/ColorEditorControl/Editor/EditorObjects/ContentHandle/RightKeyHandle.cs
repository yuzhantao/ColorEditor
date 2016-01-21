using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    class RightKeyHandle : IContentHandle
    {
        public void Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content == null || content.getText() != ((char)39).ToString()) return;

            area.SelectIndex = Math.Min(area.ContentList.Count(), pos + 1);
        }
    }
}
