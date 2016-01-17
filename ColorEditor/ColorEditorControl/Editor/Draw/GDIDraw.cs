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

        public void DrawChar(string txt, int color, DrawFont font, float x, float y, int angle, IDrawEffect[] effects)
        {
            this.m_graphics.DrawString(
                txt,
                this.DrawFontToSharpFont(font),
                new SolidBrush(Color.FromArgb(color)),
                new PointF(x, y)
                );

            //if(effects!= null)
            //{
            //    foreach(IDrawEffect effect in effects)
            //    {
            //        effect.DrawEffect(null);
            //    }
            //}
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
