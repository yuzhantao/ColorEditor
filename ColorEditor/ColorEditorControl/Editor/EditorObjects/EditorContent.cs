using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects
{
    /// <summary>
    /// 编辑区域的内容类
    /// </summary>
    public abstract class EditorContent : EditorObject
    {
        /// <summary>
        /// 获取编辑的文本内容
        /// </summary>
        /// <returns></returns>
        public abstract string getText();
    }
}
