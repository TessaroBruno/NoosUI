using Noos.UI.Themes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosFormHeader : Panel
    {
        private bool mouseDown;
        private Point lastLocation;
        private Button ExitButton;
        private Button MinimizeButton;
        private Label Title;

        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        [Browsable(true)]
        [Description("The title of the form")]
        public string TitleText
        {
            get { return Title.Text; }
            set
            {
                Title.Text = value;
                Invalidate();
            }
        }

        public NoosFormHeader()
        {
            BackColor = SkinManager.ColorScheme.SecondaryColor;
            Dock = DockStyle.Top;
            Location = new Point(300, 0);
            Size = new Size(1066, 60);
            MouseDown += HeaderPanel_MouseDown;
            MouseMove += HeaderPanel_MouseMove;
            MouseUp += HeaderPanel_MouseUp;

            ExitButton = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Image = global::Noos.UI.Properties.Resources.exit,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Location = new Point(1021, 15),
                Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Right),
                Size = new Size(30, 30),
                UseVisualStyleBackColor = true
            };
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.FlatAppearance.MouseOverBackColor = SkinManager.ColorScheme.SecondaryColor;
            ExitButton.FlatAppearance.MouseDownBackColor = SkinManager.ColorScheme.SecondaryColor;
            ExitButton.Click += ExitButton_Click;
            ExitButton.MouseHover += ExitButton_MouseHover;
            ExitButton.MouseLeave += ExitButton_MouseLeave;
            Controls.Add(ExitButton);

            MinimizeButton = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Image = global::Noos.UI.Properties.Resources.minus,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Location = new Point(976, 15),
                Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Right),
                Size = new Size(30, 30),
                UseVisualStyleBackColor = true
            };
            MinimizeButton.FlatAppearance.BorderSize = 0;
            MinimizeButton.FlatAppearance.MouseOverBackColor = SkinManager.ColorScheme.SecondaryColor;
            MinimizeButton.FlatAppearance.MouseDownBackColor = SkinManager.ColorScheme.SecondaryColor;
            MinimizeButton.Click += MinimizeButton_Click;
            MinimizeButton.MouseHover += MinimizeButton_MouseHover;
            MinimizeButton.MouseLeave += MinimizeButton_MouseLeave;
            Controls.Add(MinimizeButton);

            Title = new Label
            {
                AutoSize = true,
                Font = SkinManager.HpSimpl_Bold_16,
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                Location = new Point(30, 13),
                Size = new Size(300, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(Title);
        }

        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void HeaderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void HeaderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Parent.Location = new Point((Parent.Location.X - lastLocation.X) + e.X,
                    (Parent.Location.Y - lastLocation.Y) + e.Y);
                Parent.Update();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ((Form)TopLevelControl).Close();
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            ExitButton.Image = global::Noos.UI.Properties.Resources.exit_hover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = global::Noos.UI.Properties.Resources.exit;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            ((Form)TopLevelControl).WindowState = FormWindowState.Minimized;
        }

        private void MinimizeButton_MouseHover(object sender, EventArgs e)
        {
            MinimizeButton.Image = global::Noos.UI.Properties.Resources.minus_hover;
        }

        private void MinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeButton.Image = global::Noos.UI.Properties.Resources.minus;
        }
    }
}