using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using ColorEditorControl.Editor.EditorObjects;

namespace ColorEditorControl.Code
{
    /// <summary>
    /// 词法分析器
    /// </summary>
    class Lexer
    {
        public static string RegexPat = "[章]";
        private List<Token> m_queue = new List<Token>();
        private bool m_hasMore;
        private List<EditorContent> m_contentList;

        private int m_speek = 0;
        private Regex m_regex;

        public Lexer(List<EditorContent> list)
        {
            this.m_hasMore = true;
            this.m_contentList = list;
            this.m_regex = new Regex(RegexPat);
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
            StringBuilder sb = new StringBuilder();
            
            for(int i = this.m_speek; i < this.m_contentList.Count(); i++)
            {
                if(this.m_contentList[i].getText()=="\r" ||
                    this.m_contentList[i].GetType()!=typeof(EditorChar) ||
                    i == this.m_contentList.Count() - 1)
                {
                    break;
                }

                sb.Append(this.m_contentList[i].getText());
            }

            Match match = this.m_regex.Match(sb.ToString());
            if (match.Success)
            {
                this.AddToken(match.Index, match.Index+match.Length);
                this.m_speek = match.Index + match.Length;
            }
            else
            {

            }
        }

        private void AddToken(int start,int end)
        {

        }
    }
}
