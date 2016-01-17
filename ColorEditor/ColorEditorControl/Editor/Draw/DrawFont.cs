using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.Draw
{
    class DrawFont
    {
        #region 构造函数
        public DrawFont() :
            this("宋体")
        { }

        public DrawFont(string fontName) :
            this(12, fontName)
        { }

        public DrawFont(int size, string fontName):
            this(size,fontName,false,false,DrawFontLineStyle.NullLine)
        { }

        public DrawFont(int size,string fontName,bool isBold,bool isItalic,
            DrawFontLineStyle fontLineStyle)
        {
            this.Size = size;
            this.FontName = fontName;
            this.IsBold = isBold;
            this.IsItalic = isItalic;
            this.FontLineStyle = fontLineStyle;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 字体尺寸
        /// </summary>
        public int Size { set; get; }

        /// <summary>
        /// 字体名
        /// </summary>
        public string FontName { set; get; }

        /// <summary>
        /// 是否是粗体
        /// </summary>
        public bool IsBold { set; get; }

        /// <summary>
        /// 是否是斜体
        /// </summary>
        public bool IsItalic { set; get; }

        /// <summary>
        /// 字体线段风格
        /// </summary>
        public DrawFontLineStyle FontLineStyle { get; set; }
        #endregion
    }
}
