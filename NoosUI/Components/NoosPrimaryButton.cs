using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosPrimaryButton : Button
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
                Font = SkinManager.HpSimpl_Bold_12;
                Invalidate();
            }
        }

        public NoosPrimaryButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            Margin = new Padding(8);
            TextAlign = ContentAlignment.MiddleCenter;
            Size = new Size(200, 52);
            BackColor = SkinManager.ColorScheme.PrimaryColor;
            Font = SkinManager.HpSimpl_Bold_12;
            ForeColor = SkinManager.ColorScheme.SecondaryTextColor;
            Cursor = Cursors.Hand;
        }
    }
}