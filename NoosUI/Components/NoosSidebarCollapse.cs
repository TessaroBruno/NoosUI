using Noos.UI.Themes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosSidebarCollapse : Button
    {
        private bool collapsed;

        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosSidebarCollapse()
        {
            Name = "Collapse";
            FlatStyle = FlatStyle.Flat;
            Image = global::Noos.UI.Properties.Resources.bars;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            Font = SkinManager.HpSimpl_Bold_12;
            ForeColor = SkinManager.ColorScheme.SecondaryTextColor;
            Location = new Point(976, 15);
            Dock = DockStyle.Bottom;
            Padding = new Padding(8, 0, 0, 8);
            Size = new Size(300, 40);
            UseVisualStyleBackColor = true;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = SkinManager.ColorScheme.PrimaryColor;
            FlatAppearance.MouseDownBackColor = SkinManager.ColorScheme.PrimaryColor;
            Cursor = Cursors.Hand;
            Click += CollapseButton_Click;
            collapsed = false;
        }

        private void CollapseButton_Click(object sender, EventArgs e)
        {
            if (collapsed)
            {
                Parent.Size = new Size(300, 768);
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor;
                collapsed = false;

                foreach (Control c in Parent.Controls)
                    if (c.GetType() == typeof(NoosSidebarButton))
                        c.Visible = true;
            }
            else
            {
                Parent.Size = new Size(50, 768);
                ForeColor = SkinManager.ColorScheme.PrimaryColor;
                collapsed = true;

                foreach (Control c in Parent.Controls)
                    if (c.GetType() == typeof(NoosSidebarButton))
                        c.Visible = false;
            }
        }
    }
}