using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorEditorControl.Editor.EditorObjects
{
    /// <summary>
    /// 编辑器对象区域
    /// </summary>
    public class EditorObjectRectangle
    {
        /// <summary>
        /// 编辑器对象的左边距坐标
        /// </summary>
        public float Left { get; set; }

        /// <summary>
        /// 编辑器对象上边距的坐标
        /// </summary>
        public float Top { get; set; }

        /// <summary>
        /// 编辑器对象右边距地坐标
        /// </summary>
        //public float Right { get; set; }

        ///// <summary>
        ///// 编辑器对象下边距的坐标
        ///// </summary>
        //public float Bottom { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float MarginLeft { get; set; }
        public float MarginTop { get; set; }
        public float MarginRight { get; set; }
        public float MarginBottom { get; set; }

        public float PaddingLeft { get; set; }
        public float PaddingTop { get; set; }
        public float PaddingRight { get; set; }
        public float PaddingBottom { get; set; }

        /// <summary>
        /// 编辑器对象的层索引
        /// </summary>
        public float LayerIndex { get; set; }

        /// <summary>
        /// 获取编辑器对象的宽度
        /// </summary>
        /// <returns></returns>
        //public float GetWidth()
        //{
        //    return Math.Abs(this.Left - this.Right);
        //}

        ///// <summary>
        ///// 获取编辑器对象的高度
        ///// </summary>
        ///// <returns></returns>
        //public float GetHeight()
        //{
        //    return Math.Abs(this.Top - this.Bottom);
        //}

        /// <summary>
        /// 矩形区域与形参中的区域是否重叠交叉
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <returns></returns>
        public bool IsCross(float x,float y,float right,float bottom)
        {
            bool isCoross = false;

            System.Drawing.RectangleF srcRect = new System.Drawing.RectangleF(this.Left, this.Top, this.Width, this.Height);
            System.Drawing.RectangleF destRect = new System.Drawing.RectangleF(x, y, right, bottom);
            if (srcRect.IntersectsWith(destRect)) isCoross = true;

            return isCoross;
        }
    }
}
