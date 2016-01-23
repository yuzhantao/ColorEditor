using System;
using System.Drawing;

namespace ColorEditorControl.Editor.Draw
{
    public interface IDraw:ICloneable
    {
        SizeF GetDrawStringSize(string str,DrawFont font);

        void DrawImage(Image img, 
            float srcX, 
            float srcY, 
            float srcWidth, 
            float srcHeight, 
            float destX, 
            float destY, 
            float destWidth, 
            float destHeight, 
            int angle, 
            IDrawEffect[] effects);

        void DrawChar(
            string txt,
            int color,
            DrawFont font,
            float x,
            float y,
            int angle,
            IDrawEffect[] effects);

        void DrawLine(
            int width,
            int color,
            float x1,
            float y1,
            float x2,
            float y2,
            DrawLineStyle lineStyle,
            IDrawEffect[] effects);

        void DrawRectangleLine(
            int width,
            int color,
            float x1,
            float y1,
            float x2,
            float y2,
            DrawLineStyle lineStyle,
            IDrawEffect[] effects);

        void FillRectangle(
            int color, 
            float x, 
            float y, 
            float width, 
            float height,
            IDrawEffect[] effects);
    }
}
