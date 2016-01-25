using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Code
{
    public class Token
    {
        public static Token EOF = new Token(-1,-1);
        public static string EOL = "\n";

        private int m_startPos,m_endPos;

        protected Token(int start,int end)
        {
            this.m_startPos = start;
            this.m_endPos = end;
        }

        public bool IsIdentifier() { return false; }
        public bool IsString() { return false; }
        public string GetText() { return string.Empty; }
    }
}
