using Noos.UI.Themes;
using System.ComponentModel;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosTextBox : TextBox
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        [Browsable(true)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Font = SkinManager.HpSimpl_Reg_12;
                Invalidate();
            }
        }

        public NoosTextBox()
        {
            BackColor = SkinManager.ColorScheme.SecondaryColorLight;
            ForeColor = SkinManager.ColorScheme.PrimaryTextColor;
            Font = SkinManager.HpSimpl_Reg_12;
            BorderStyle = BorderStyle.None;
            Margin = new Padding(5);
        }
    }
}