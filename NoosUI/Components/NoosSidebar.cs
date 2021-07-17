using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosSidebar : Panel
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosSidebar()
        {
            BackColor = SkinManager.ColorScheme.PrimaryColor;
            Dock = DockStyle.Left;
            Location = new Point(0, 0);
            Size = new Size(300, 768);
        }
    }
}