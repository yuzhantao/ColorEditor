using System.Text.RegularExpressions;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    interface IContentHandle
    {
        /// <summary>
        /// 插入指定内容的处理
        /// </summary>
        /// <param name="area"></param>
        /// <param name="pos"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        bool Insert(EditorEditArea area,int pos,EditorContent content);
    }
}
