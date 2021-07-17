using Noos.UI.Themes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosNotification : Form
    {
        public enum enumAction { wait, start, close }
        private NoosNotification.enumAction action;
        private int x, y;

        private Label Message;
        private Button ExitBtn;
        private PictureBox MsgIcon;
        private Timer ShowTimer;

        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosNotification()
        {
            AutoScaleMode = AutoScaleMode.None;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = SkinManager.ColorScheme.ComplementaryColor;
            ClientSize = new Size(403, 85);

            ShowTimer = new Timer();
            ShowTimer.Tick += ShowTimer_Tick;

            MsgIcon = new PictureBox
            {
                Image = global::Noos.UI.Properties.Resources.plus,
                Location = new Point(12, 12),
                Size = new Size(65, 65),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Controls.Add(MsgIcon);

            ExitBtn = new Button
            {
                FlatStyle = FlatStyle.Flat,
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                Image = global::Noos.UI.Properties.Resources.exit,
                Location = new Point(355, 32),
                Size = new Size(24, 24),
                UseVisualStyleBackColor = true
            };
            ExitBtn.FlatAppearance.BorderSize = 0;
            ExitBtn.FlatAppearance.MouseOverBackColor = SkinManager.ColorScheme.ComplementaryColor;
            ExitBtn.FlatAppearance.MouseDownBackColor = SkinManager.ColorScheme.ComplementaryColor;
            ExitBtn.Click += ExitBtn_Click;
            Controls.Add(ExitBtn);

            Message = new Label
            {
                AutoSize = true,
                Font = SkinManager.HpSimpl_Reg_12,
                ForeColor = SkinManager.ColorScheme.PrimaryTextColor,
                Location = new Point(129, 32),
                Size = new Size(82, 23)
            };
            Controls.Add(Message);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.ShowTimer.Interval = 1;
            action = enumAction.close;
        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enumAction.wait:
                    ShowTimer.Interval = 5000;
                    action = enumAction.close;
                    break;

                case enumAction.start:
                    ShowTimer.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                        this.Left--;
                    else
                        if (this.Opacity == 1.0)
                        action = enumAction.wait;
                    break;

                case enumAction.close:
                    ShowTimer.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                        base.Close();
                    break;
            }
        }

        public void ShowNotification(string msg)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                NoosNotification frm = (NoosNotification)Application.OpenForms[fname];
                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            this.Message.Text = msg;
            this.Message.Font = SkinManager.HpSimpl_Reg_12;
            this.Show();
            this.action = enumAction.start;
            this.ShowTimer.Interval = 1;
            this.ShowTimer.Start();
        }
    }
}