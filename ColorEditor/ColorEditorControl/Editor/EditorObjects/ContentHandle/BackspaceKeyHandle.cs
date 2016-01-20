﻿using System;
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
        public bool Input(EditorEditArea area, int pos, EditorContent content)
        {
            if (pos <= 0) return false;                                         // 如果插入位置在0位，就不处理。
            if (content == null || content.getText() != "\b") return false;     // 如果不是退格键，返回false
            if (content.GetType() != typeof(EditorKey)) return true;            // 如果没当作按键，返回true，但不处理操作。

            area.Remove(pos - 1, pos);

            return true;
        }
    }
}
