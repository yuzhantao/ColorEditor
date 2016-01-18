using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ColorEditorControl.Editor.Draw;
using ColorEditorControl.Editor.EditorObjects;

namespace ColorEditorControl.Editor
{
    public partial class ColorEditor : UserControl
    {
        public EditorView View { get; set; }

        public ColorEditor() : this(new EditorView()) { }

        public ColorEditor(EditorView view)
        {

            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.View = view;
            this.InsterChar("克路德机器人\n人之初，性本善", 0);
        }
        
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.View.Draw(new GDIDraw(e.Graphics));
        }

        private void InsterChar(string txt,int pos)
        {
            DrawFont defFont = new DrawFont(this.Font.FontFamily.Name);
            EditorChar editorChar = new EditorChar(txt, defFont);
            editorChar.Rectangle = new EditorObjectRectangle();
            this.View.EditorArea.Insert(pos, editorChar);
        }
    }
}
