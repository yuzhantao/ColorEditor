using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    class EditorImage : EditorContent
    {
        public Image Image { get; set; }

        public EditorImage(Image img)
        {
            this.Image = img;
            this.Rectangle.Width = img.Width;
            this.Rectangle.Height = img.Height;
        }

        public override void Draw(IDraw draw)
        {
            draw.DrawImage(this.Image, 0, 0, 
                this.Image.Width, 
                this.Image.Height,
                this.Rectangle.Left,
                this.Rectangle.Top,
                this.Rectangle.Width,
                this.Rectangle.Height,
                0,
                null);
        }

        public override string getText()
        {
            return "img";
        }
    }
}
