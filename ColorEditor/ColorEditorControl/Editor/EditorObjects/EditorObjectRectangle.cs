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
    class EditorObjectRectangle
    {
        /// <summary>
        /// 编辑器对象的左边距坐标
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// 编辑器对象上边距的坐标
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// 编辑器对象右边距地坐标
        /// </summary>
        public double Right { get; set; }

        /// <summary>
        /// 编辑器对象下边距的坐标
        /// </summary>
        public double Bottom { get; set; }

        /// <summary>
        /// 编辑器对象的层索引
        /// </summary>
        public double LayerIndex { get; set; }

        /// <summary>
        /// 获取编辑器对象的宽度
        /// </summary>
        /// <returns></returns>
        public double getWidth()
        {
            return Math.Abs(this.Left - this.Right);
        }

        /// <summary>
        /// 获取编辑器对象的高度
        /// </summary>
        /// <returns></returns>
        public double getHeight()
        {
            return Math.Abs(this.Top - this.Bottom);
        }
    }
}
