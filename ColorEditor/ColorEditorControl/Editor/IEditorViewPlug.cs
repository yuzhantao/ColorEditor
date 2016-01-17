using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor
{
    /// <summary>
    /// 编辑器视图插件
    /// </summary>
    interface IEditorViewPlug
    {
        /// <summary>
        /// 注册插件
        /// </summary>
        /// <param name="view"></param>
        void Register(EditorView view);

        /// <summary>
        /// 注销插件
        /// </summary>
        /// <param name="view"></param>
        void Unregister(EditorView view);
    }
}
