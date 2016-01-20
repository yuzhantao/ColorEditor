using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    /// <summary>
    /// 左键处理
    /// </summary>
    class LeftKeyHandle : IContentHandle
    {
        public bool Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content == null || content.getText() != ((char)37).ToString()) return false;

            area.SelectIndex = Math.Max(0,pos - 1);
            return true;
        }
    }
}
