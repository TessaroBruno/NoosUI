using Noos.UI.Themes;
using System.ComponentModel;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosDialogPanel : Panel
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosDialogPanel()
        {
            BackColor = SkinManager.ColorScheme.Background;
            Dock = DockStyle.Fill;
            Padding = new Padding(8);
        }
    }
}