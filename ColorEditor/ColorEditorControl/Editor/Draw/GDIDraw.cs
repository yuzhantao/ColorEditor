using System;
using System.Drawing;

namespace ColorEditorControl.Editor.Draw
{
    /// <summary>
    /// 通过windows gdi+方式绘图
    /// </summary>
    class GDIDraw : IDraw
    {
        private Graphics m_graphics;

        public GDIDraw(Graphics gh)
        {
            this.m_graphics = gh;
        }

        public object Clone()
        {
            Graphics gs = Graphics.FromImage(new Bitmap(999, 999));
            IDraw draw = new GDIDraw(gs);
            return draw;
        }

        public void DrawChar(string txt, int color, DrawFont font, float x, float y, int angle, IDrawEffect[] effects)
        {
            Brush br = new SolidBrush(Color.FromArgb(color));
            Font sysFont = this.DrawFontToSharpFont(font);
            this.m_graphics.DrawString(
                txt,
                sysFont,
                br,
                new PointF(x, y)
                );

#if DEBUG
            SizeF size = this.GetDrawStringSize(txt, font);
            this.m_graphics.DrawRectangle(new Pen(Color.Red), x, y, size.Width, size.Height);
#endif
        }

        public void DrawImage(Image img, float srcLeft, float srcTop, float srcRight, float srcBottom, float destWidth, float destHeight, int angle, IDrawEffect[] effects)
        {
            throw new NotImplementedException();
        }

        public void DrawLine(int width, int color, float x1, float y1, float x2, float y2, DrawLineStyle lineStyle, IDrawEffect[] effects)
        {
            throw new NotImplementedException();
        }

        public void DrawRectangleLine(int width, int color, float x1, float y1, float x2, float y2, DrawLineStyle lineStyle, IDrawEffect[] effects)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(int color, float x1, float y1, float x2, float y2, IDrawEffect[] effects)
        {
            throw new NotImplementedException();
        }

        public SizeF GetDrawStringSize(string str, DrawFont font)
        {
            SizeF retSize = this.m_graphics.MeasureString(str,  this.DrawFontToSharpFont(font));
            return retSize;
        }

        /// <summary>
        /// 绘制字体类转c# font类
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        private Font DrawFontToSharpFont(DrawFont font)
        {
            Font sharpFont = new Font(font.FontName, font.Size);

            return sharpFont;
        }
    }
}
