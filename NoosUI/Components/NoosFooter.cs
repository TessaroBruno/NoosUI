using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosFooter : Panel
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosFooter()
        {
            BackColor = SkinManager.ColorScheme.SecondaryColorLight;
            Dock = DockStyle.Bottom;
            Location = new Point(300, 0);
            Size = new Size(1066, 60);
        }
    }
}