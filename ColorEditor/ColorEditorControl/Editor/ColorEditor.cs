using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using ColorEditorControl.Editor.Draw;
using ColorEditorControl.Editor.EditorObjects;

namespace ColorEditorControl.Editor
{
    public partial class ColorEditor : UserControl
    {
        #region Win API
        private const int WM_IME_CHAR = 0x0286;
        private const int WM_CHAR = 0x0102;
        private const int WM_IME_SETCONTEXT = 0x0281;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int SB_ENDSCROLL = 0x8;
        private const int GCS_COMPSTR = 0x0008;
        private int GCS_RESULTSTR = 0x0800;
        private const int PM_REMOVE = 0x0001;

        [DllImport("Imm32.dll")]
        private static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("Imm32.dll")]
        private static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("Imm32.dll")]
        private static extern int ImmGetCompositionString(IntPtr hIMC, int dwIndex, StringBuilder lPBuf, int dwBufLen);

        #endregion

        #region 属性
        public EditorView View { get; set; }
        #endregion

        private IntPtr m_pImmGetContext;
        
        public ColorEditor()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_pImmGetContext = ImmGetContext(this.Handle);                  // 创建输入法
            this.View = new EditorView(this.Handle, null);                  // 初始化编辑器
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
                if (m.WParam.ToInt32() != SB_ENDSCROLL)
                    Invalidate();
            
            if (m.Msg == WM_IME_SETCONTEXT && m.WParam.ToInt32() == 1)
            {
                ImmAssociateContext(Handle, m_pImmGetContext);
            }
            switch (m.Msg)
            {
                case WM_CHAR:
                    KeyEventArgs e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);
                    char a = (char)e.KeyData; //英文 

                    this.AddChar(a.ToString());
                    this.Invalidate();
                    break;
                case WM_IME_CHAR:
                    if (m.WParam.ToInt32() == PM_REMOVE) //如果不做这个判断.会打印出重复的中文 
                    {
                        StringBuilder str = new StringBuilder();
                        int size = ImmGetCompositionString(m_pImmGetContext, GCS_COMPSTR, null, 0);
                        size += sizeof(Char);
                        ImmGetCompositionString(m_pImmGetContext, GCS_RESULTSTR, str, size);
                        this.AddChar(str.ToString());
                        this.Invalidate();
                    }
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.View.Draw(new GDIDraw(e.Graphics));
        }

        private void AddChar(string txt)
        {
            DrawFont defFont = new DrawFont(this.Font.FontFamily.Name);
            EditorChar editorChar = new EditorChar(txt, defFont);
            editorChar.Rectangle = new EditorObjectRectangle();
            this.View.EditorArea.Add(editorChar);
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
