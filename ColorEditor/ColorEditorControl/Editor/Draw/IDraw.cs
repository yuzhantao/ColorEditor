using System;
using System.Drawing;

namespace ColorEditorControl.Editor.Draw
{
    interface IDraw
    {
        void DrawImage(Image img,
            float srcLeft,
            float srcTop,
            float srcRight, 
            float srcBottom, 
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
            float x1,
            float y1,
            float x2,
            float y2,
            IDrawEffect[] effects);
    }
}
