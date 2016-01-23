using System.Text.RegularExpressions;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    interface IContentHandle
    {
        /// <summary>
        /// 内容的输入操作处理函数
        /// </summary>
        /// <param name="area"></param>
        /// <param name="pos"></param>
        /// <param name="content"></param>
        /// <returns>如果返回true，则不检查之后继承此接口的其他类</returns>
        bool Input(EditorEditArea area,int pos,EditorContent content);
    }
}
