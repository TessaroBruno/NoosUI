using Noos.UI.Themes;
using System.ComponentModel;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosListBox : ListBox
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosListBox()
        {
            Cursor = Cursors.Hand;
            BackColor = SkinManager.ColorScheme.SecondaryColorLight;
            ForeColor = SkinManager.ColorScheme.PrimaryTextColor;
            Font = SkinManager.HpSimpl_Reg_12;
            BorderStyle = BorderStyle.None;
            Margin = new Padding(5);
        }
    }
}