using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosSidebarLogo : PictureBox
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosSidebarLogo()
        {
            BackColor = Color.Transparent;
            Dock = DockStyle.Top;
            Location = new Point(10, 10);
            Size = new Size(128, 128);
            SizeMode = PictureBoxSizeMode.Zoom;
            TabStop = false;
        }
    }
}