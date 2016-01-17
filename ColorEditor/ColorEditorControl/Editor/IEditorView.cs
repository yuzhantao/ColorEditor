using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorEditorControl.Editor
{
    interface IEditorView
    {
        Control getEditorControl();

        Menu getEditorMenu();

        string getText();

        void Draw();
    }
}
