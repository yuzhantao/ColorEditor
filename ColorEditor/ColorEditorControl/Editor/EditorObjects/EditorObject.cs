﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects
{
    abstract class EditorObject
    {
        /// <summary>
        /// 编辑器对象的矩形区域
        /// </summary>
        public EditorObjectRectangle Rectangle { get; set; }

        /// <summary>
        /// 绘制编辑器对象
        /// </summary>
        public abstract void Draw();
    }
}