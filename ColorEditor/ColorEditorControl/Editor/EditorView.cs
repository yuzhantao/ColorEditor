using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ColorEditorControl.Editor.Draw;
using ColorEditorControl.Editor.EditorObjects;

namespace ColorEditorControl.Editor
{
    public class EditorView
    {
        public List<EditorContent> ContentList { get; set; }
        public IDraw DrawGraphic { get; set; }
        
        public EditorView()
        {
            this.ContentList = new List<EditorContent>();
        }

        /// <summary>
        /// get view area text
        /// </summary>
        /// <returns></returns>
        public string getText()
        {
            StringBuilder sb = new StringBuilder();
            foreach(EditorContent obj in this.ContentList)
            { 
                sb.Append(obj.getText());
            }
            return sb.ToString();
        }

        public void UpdateDraw()
        {
            if (this.DrawGraphic == null) return;

            foreach (EditorContent obj in this.ContentList)
            {
                obj.Draw(this.DrawGraphic);
            }
        }

        public void UpdateDraw(float x, float y)
        {
            this.UpdateDraw(x, y, x + 1, y + 1);
        }

        public void UpdateDraw(float x,float y,float right,float bottom)
        {
            foreach (EditorContent obj in this.ContentList)
            {
                if(obj.Rectangle.IsCross(x,y,right,bottom)) obj.Draw(this.DrawGraphic);
            }
        }
    }
}
