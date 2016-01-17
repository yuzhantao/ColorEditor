using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.Draw
{
    /// <summary>
    /// 绘制字体的线段风格
    /// </summary>
    enum DrawFontLineStyle
    {
        /// <summary>
        /// 空线段
        /// </summary>
        NullLine,

        /// <summary>
        /// 上画线
        /// </summary>
        OverLine,

        /// <summary>
        /// 中间线
        /// </summary>
        MiddleLine,

        /// <summary>
        /// 下划线
        /// </summary>
        UnderLine,

        /// <summary>
        /// 左斜线
        /// </summary>
        LeftObliqueLine,

        /// <summary>
        /// 右斜线
        /// </summary>
        RightObliqueLine
    }
}
