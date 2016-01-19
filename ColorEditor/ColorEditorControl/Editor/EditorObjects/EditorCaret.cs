using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

using ColorEditorControl.Editor.Draw;

namespace ColorEditorControl.Editor.EditorObjects
{
    /// <summary>
    /// 编辑区的插入光标
    /// </summary>
    public class EditorCaret:EditorObject
    {
        #region Win API

        [DllImport("user32.dll")]
        private static extern bool CreateCaret(
            IntPtr hWnd,
            IntPtr hBitmap,
            int nWidth,
            int nHeight
        );

        [DllImport("user32.dll")]
        private static extern bool SetCaretPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern bool ShowCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        #endregion

        /// <summary>
        /// 光标图案
        /// </summary>
        public Bitmap CaretBimap { set; get; }

        /// <summary>
        /// 显示光标的窗口句柄
        /// </summary>
        public IntPtr WindowHandle { set; get; }

        public EditorCaret(IntPtr handle,Bitmap bmp)
        {
            this.CaretBimap = bmp;
            this.WindowHandle = handle;
            CreateCaret(this.WindowHandle, IntPtr.Zero, 5, 20);
        }

        public void Show()
        {
            ShowCaret(this.WindowHandle);
        }

        public void Hide()
        {
            ShowCaret(this.WindowHandle);
        }

        public override void Draw(IDraw draw) { SetCaretPos((int)this.Rectangle.Left, (int)this.Rectangle.Top); }
    }
}
