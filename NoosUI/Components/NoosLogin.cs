using Noos.UI.Themes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosLogin : Form
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        private Button LoginBtn;
        private TextBox PwdTextBox;
        private TextBox UserNameTextBox;
        private Label ForgetPwdLabel;
        private Label SignupLabel;
        private PictureBox Logo;
        private Button ExitButton;
        private Timer FadeTimer;

        public NoosLogin()
        {
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SkinManager.ColorScheme.SecondaryColor;
            ClientSize = new Size(288, 450);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";

            FadeTimer = new Timer();
            FadeTimer.Tick += FadeTimer_Tick;
            FadeTimer.Interval = 100;

            Logo = new PictureBox
            {
                Location = new Point(86, 78),
                Size = new Size(110, 76),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Controls.Add(Logo);

            ExitButton = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Image = global::Noos.UI.Properties.Resources.exit,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Location = new Point(250, 6),
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

            SignupLabel = new Label
            {
                AutoSize = false,
                Font = SkinManager.HpSimpl_Bold_16,
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                Location = new Point(105, 400),
                Size = new Size(85, 30),
                Text = "Signup"
            };
            Controls.Add(SignupLabel);

            ForgetPwdLabel = new Label
            {
                AutoSize = false,
                Font = SkinManager.HpSimpl_Bold_12,
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                Location = new Point(85, 270),
                Size = new Size(200, 25),
                Text = "Forget password?"
            };
            Controls.Add(ForgetPwdLabel);

            UserNameTextBox = new TextBox
            {
                Font = SkinManager.HpSimpl_Bold_12,
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                Location = new Point(45, 187),
                Size = new Size(200, 26),
                Text = "Username"
            };
            UserNameTextBox.Enter += UserNameTextBox_Enter;
            UserNameTextBox.Leave += UserNameTextBox_Leave;
            Controls.Add(UserNameTextBox);

            PwdTextBox = new TextBox
            {
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                Location = new Point(45, 247),
                Size = new Size(200, 26),
                UseSystemPasswordChar = true
            };
            Controls.Add(PwdTextBox);

            LoginBtn = new Button
            {
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                Location = new Point(45, 333),
                Size = new Size(200, 60),
                Text = "Login",
                UseVisualStyleBackColor = true
            };
            LoginBtn.Click += LoginBtn_Click;
            Controls.Add(LoginBtn);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            ExitButton.Image = global::Noos.UI.Properties.Resources.exit_hover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = global::Noos.UI.Properties.Resources.exit;
        }

        private void UserNameTextBox_Enter(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text == "Username")
            {
                UserNameTextBox.Text = "";
                UserNameTextBox.ForeColor = Color.Black;
            }
        }

        private void UserNameTextBox_Leave(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text?.Length == 0)
            {
                UserNameTextBox.Text = "Username";
                UserNameTextBox.ForeColor = Color.Silver;
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            FadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
                this.Opacity -= 0.025;
            else
            {
                FadeTimer.Stop();
                this.Close();
            }
        }

        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }
    }
}