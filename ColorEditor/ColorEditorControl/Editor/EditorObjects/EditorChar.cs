using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    public class EditorChar : EditorContent
    {
        private string m_content;                   // 字符内容

        public int FontColor { get; set; }

        public DrawFont Font { get; set; }

        public EditorChar(string content,DrawFont font)
        {
            this.m_content = content;
            this.FontColor = 0x000000;
            this.Font = font;
        }

        public override void Draw(IDraw draw)
        {
            draw.DrawChar(this.m_content, this.FontColor, this.Font,
                this.Rectangle.Left,
                this.Rectangle.Top,
                0,
                null);
        }

        public override string getText()
        {
            return this.m_content;
        }
    }
}
