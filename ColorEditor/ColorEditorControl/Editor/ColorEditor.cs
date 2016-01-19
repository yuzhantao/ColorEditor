using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using ColorEditorControl.Editor.Draw;
using ColorEditorControl.Editor.EditorObjects;

namespace ColorEditorControl.Editor
{
    /// <summary>
    /// 类似word的编辑器，编辑器中的每个成员均继承自EditorObject对象
    /// </summary>
    public partial class ColorEditor : UserControl
    {
        #region Win API
        private const int WM_IME_CHAR = 0x0286;                         // 输入法中的内容
        private const int WM_CHAR = 0x0102;                             // 字符内容
        private const int WM_IME_SETCONTEXT = 0x0281;                   // 输入法的上下文
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int SB_ENDSCROLL = 0x8;
        private const int GCS_COMPSTR = 0x0008;
        private int GCS_RESULTSTR = 0x0800;
        private const int PM_REMOVE = 0x0001;                   
        private const int WM_SYSCOMMAND = 0x0112;                       // 系统按键
        private const int WM_KEYDOWN = 0x100;                           // 按键点下
        private const int WM_KEYUP = 0x101;                             // 按键抬起

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

        #region 变量

        private IntPtr m_pImmGetContext;        // 输入法句柄

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ColorEditor()
        {
            InitializeComponent();

            // 设置控件为自定义绘制风格
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #endregion

        #region 继承
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_pImmGetContext = ImmGetContext(this.Handle);                  // 创建输入法
            this.View = new EditorView(this.Handle, null);                  // 初始化编辑器
        }

        /// <summary>
        /// 处理windows消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
                if (m.WParam.ToInt32() != SB_ENDSCROLL)
                    Invalidate();
            
            //switch (m.Msg)
            //{
            //    // 设置handle窗口可以接收输入法的消息
            //    case WM_IME_SETCONTEXT:                     
            //        if (m.WParam.ToInt32() == 1) ImmAssociateContext(Handle, m_pImmGetContext);
            //        break;
            //    case WM_KEYUP:
            //        KeyEventArgs keyE = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys); 
            //        this.AddKey((char)keyE.KeyData);        // 添加按键到编辑器
            //        break;
            //    // 处理接收到的字符
            //    case WM_CHAR:                               
            //        KeyEventArgs charE = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);
            //        char charData = (char)charE.KeyData;    // 获取英文或数字
            //        this.AddChar(charData.ToString());      // 添加字符到编辑器
            //        this.Invalidate();
            //        break;
            //    // 处理接收到的输入法传过来的字符
            //    case WM_IME_CHAR:                           
            //        if (m.WParam.ToInt32() == PM_REMOVE)    //如果不做这个判断.会打印出重复的中文 
            //        {
            //            this.AddImmToEditorArea();          // 添加字符到编辑器
            //        }
            //        break;
            //}
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            switch (msg.Msg)
            {
                // 设置handle窗口可以接收输入法的消息
                case WM_IME_SETCONTEXT:
                    if (msg.WParam.ToInt32() == 1) ImmAssociateContext(Handle, m_pImmGetContext);
                    break;
                case WM_KEYUP:
                    KeyEventArgs keyE = new KeyEventArgs(((Keys)((int)((long)msg.WParam))) | ModifierKeys);
                    this.AddKey((char)keyE.KeyData);        // 添加按键到编辑器
                    break;
                // 处理接收到的字符
                case WM_CHAR:
                    KeyEventArgs charE = new KeyEventArgs(((Keys)((int)((long)msg.WParam))) | ModifierKeys);
                    char charData = (char)charE.KeyData;    // 获取英文或数字
                    this.AddChar(charData.ToString());      // 添加字符到编辑器
                    this.Invalidate();
                    break;
                // 处理接收到的输入法传过来的字符
                case WM_IME_CHAR:
                    if (msg.WParam.ToInt32() == PM_REMOVE)    //如果不做这个判断.会打印出重复的中文 
                    {
                        this.AddImmToEditorArea();          // 添加字符到编辑器
                    }
                    break;
            }

            return base.PreProcessMessage(ref msg);
        }

        /// <summary>
        /// 绘制窗体图像
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.View.Draw(new GDIDraw(e.Graphics));
        }
        #endregion

        #region 私有函数

        /// <summary>
        /// 添加输入法获取到的字符到编辑器区域
        /// </summary>
        private void AddImmToEditorArea()
        {
            StringBuilder str = new StringBuilder();
            int size = ImmGetCompositionString(m_pImmGetContext, GCS_COMPSTR, null, 0);
            size += sizeof(Char);
            ImmGetCompositionString(m_pImmGetContext, GCS_RESULTSTR, str, size);
            this.AddChar(str.ToString());
            this.Invalidate();
        }

        private void AddChar(string txt)
        {
            DrawFont defFont = new DrawFont(this.Font.FontFamily.Name);
            EditorChar editorChar = new EditorChar(txt, defFont);
            this.View.EditorArea.Add(editorChar);
        }

        /// <summary>
        /// 添加快捷键
        /// </summary>
        /// <param name="key"></param>
        private void AddKey(char key)
        {
            EditorKey editorKey = new EditorKey(key.ToString());
            this.View.EditorArea.Add(editorKey);
        }

        private void InsterChar(string txt,int pos)
        {
            DrawFont defFont = new DrawFont(this.Font.FontFamily.Name);
            EditorChar editorChar = new EditorChar(txt, defFont);
            editorChar.Rectangle = new EditorObjectRectangle();
            this.View.EditorArea.Insert(pos, editorChar);
        }

        #endregion
    }
}
