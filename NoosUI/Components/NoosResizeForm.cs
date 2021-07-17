using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosResizeForm : Panel
    {
        private bool mouseDown;

        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosResizeForm()
        {
            BackColor = SkinManager.ColorScheme.PrimaryColor;
            Dock = DockStyle.Right;
            Size = new Size(10, 10);
            Cursor = Cursors.SizeNWSE;
            MouseDown += Resize_MouseDown;
            MouseMove += Resize_MouseMove;
            MouseUp += Resize_MouseUp;
        }

        private void Resize_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Resize_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                ((Form)TopLevelControl).Size =
                    new Size(((Form)TopLevelControl).Size.Width + e.X,
                    ((Form)TopLevelControl).Size.Height + e.Y);
                ((Form)TopLevelControl).Update();
            }
        }
    }
}