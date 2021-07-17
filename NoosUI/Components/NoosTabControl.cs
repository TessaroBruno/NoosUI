using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosTabControl : TabControl
    {

        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosTabControl()
        {
            BackColor = SkinManager.ColorScheme.Background;
            Appearance = TabAppearance.FlatButtons;
            ItemSize = new Size(0, 1);
            SizeMode = TabSizeMode.Fixed;
        }
    }
}