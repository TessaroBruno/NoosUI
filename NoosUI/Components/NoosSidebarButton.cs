using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosSidebarButton : Button
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

        [Browsable(true)]
        public Image Icon
        {
            get { return Image; }
            set
            {
                Image = value;
                Invalidate();
            }
        }

        public NoosSidebarButton()
        {
            Dock = DockStyle.Top;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            Margin = new Padding(8);
            Padding = new Padding(10, 0, 0, 0);
            Size = new Size(200, 52);
            TextImageRelation = TextImageRelation.ImageBeforeText;
            Image = global::Noos.UI.Properties.Resources.plus;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextAlign = ContentAlignment.MiddleRight;
            BackColor = SkinManager.ColorScheme.PrimaryColor;
            Font = SkinManager.HpSimpl_Bold_12;
            ForeColor = SkinManager.ColorScheme.SecondaryTextColor;
            Cursor = Cursors.Hand;
        }
    }
}