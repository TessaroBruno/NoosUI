using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosNumericUpDown : NumericUpDown
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

        public NoosNumericUpDown()
        {
            Cursor = Cursors.Hand;
            BackColor = SkinManager.ColorScheme.SecondaryColorLight;
            ForeColor = SkinManager.ColorScheme.PrimaryTextColor;
            Font = SkinManager.HpSimpl_Reg_12;
            Margin = new Padding(5);
            Size = new Size(200, 26);
            BorderStyle = BorderStyle.None;
            TextAlign = HorizontalAlignment.Right;
        }
    }
}