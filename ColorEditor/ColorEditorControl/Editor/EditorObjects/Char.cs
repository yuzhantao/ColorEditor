using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects
{
    class Char : EditContent
    {
        private string m_content;                   // 字符内容

        public override void Draw()
        {
            
        }

        public override string getText()
        {
            return this.m_content;
        }
    }
}
