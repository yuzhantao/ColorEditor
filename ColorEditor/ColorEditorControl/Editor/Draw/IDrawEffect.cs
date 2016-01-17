using System.Drawing;

namespace ColorEditorControl.Editor.Draw
{
    interface IDrawEffect
    {
        /// <summary>
        /// 滤镜绘制效果
        /// </summary>
        /// <param name="img"></param>
        void DrawEffect(Image img);
    }
}
