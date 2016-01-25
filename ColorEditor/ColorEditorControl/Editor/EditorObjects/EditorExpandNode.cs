using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    class EditorExpandNode : EditorContent
    {
        private int Color { get; set; }
        public bool Expand { get; set; }

        public override void Draw(IDraw draw)
        {
            draw.DrawRectangleLine(1, this.Color, this.Rectangle.Left, this.Rectangle.Top,
                this.Rectangle.Width,
                this.Rectangle.Height,
                DrawLineStyle.Solid,
                null);                      // 绘制矩形

            draw.DrawLine(
                1, 
                this.Color, 
                this.Rectangle.Left,
                this.Rectangle.Top+this.Rectangle.Height/2,
                1,
                1,
                DrawLineStyle.Solid,
                null);                      // 绘制横线

            if (!this.Expand)
            {
                draw.DrawLine(1, this.Color, this.Rectangle.Left + this.Rectangle.Width / 2,
                    this.Rectangle.Top,
                    1,
                    1,
                    DrawLineStyle.Solid,
                    null);                  // 绘制竖线
            }
        }

        public override string getText()
        {
            return string.Empty;
        }
    }
}
