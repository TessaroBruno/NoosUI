using Noos.UI.Themes;
using System.ComponentModel;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosLabel: Label
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

        public NoosLabel()
        {
            FlatStyle = FlatStyle.Flat;
            Font = SkinManager.HpSimpl_Reg_12;
            ForeColor = SkinManager.ColorScheme.PrimaryTextColor;
            Margin = new Padding(8);
        }
    }
}