using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    class ImageHandle : IContentHandle
    {
        public bool Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content == null || content.GetType() != typeof(EditorImage)) return false;

            area.ContentList.Insert(area.SelectIndex, content);
            area.SelectIndex = pos + 1;

            return false;
        }
    }
}
