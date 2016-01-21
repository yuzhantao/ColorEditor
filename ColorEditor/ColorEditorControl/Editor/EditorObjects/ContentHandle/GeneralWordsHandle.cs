﻿using System.Text.RegularExpressions;

namespace ColorEditorControl.Editor.EditorObjects.ContentHandle
{
    class GeneralWordsHandle : IContentHandle
    {
        public void Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (content == null || content.GetType() != typeof(EditorChar)) return;

            Regex regex = new Regex("[\u4e00-\u9fa5_a-zA-Z0-9_\r,.;:\"'`~!@#$%^&*(){}\\| ]{1}");
            if (!regex.IsMatch(content.getText())) return;            // 如果不是数字英文中文等普通字符，则返回false

            area.ContentList.Insert(pos, content);

            area.SelectIndex = pos+1;
        }
    }
}
