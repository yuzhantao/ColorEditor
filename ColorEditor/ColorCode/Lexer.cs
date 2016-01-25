using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCode
{
    /// <summary>
    /// 词法分析器
    /// </summary>
    class Lexer
    {
        public static string RegexPat = "";
        private List<Token> m_queue = new List<Token>();
        private bool m_hasMore;
        
        public Lexer()
        {
            this.m_hasMore = true;
        }

        public Token Read()
        {
            return Token.EOF;
        }

        public Token Peek(int pos)
        {
            return Token.EOF;
        }

        private bool FillQueue(int pos)
        {
            while (pos >= this.m_queue.Count())
            {
                if (this.m_hasMore)
                    this.ReadLine();
                else
                    return false;
            }

            return true;
        }

        protected void ReadLine()
        {
            string line;

        }
    }
}
