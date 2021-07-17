using Noos.UI.Themes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public partial class NoosSplashScreen : Form
    {
        public PictureBox AppLogo;
        public Label AppName;
        private Panel LoadingSlider;
        private Panel PanelSlide;
        private Timer LoadingTimer;

        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosSplashScreen(string appName, Bitmap logo)
        {
            SuspendLayout();
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(400, 500);
            BackColor = SkinManager.ColorScheme.PrimaryColor;

            LoadingTimer = new Timer
            {
                Interval = 10
            };
            LoadingTimer.Tick += LoadingTimer_Tick;
            LoadingTimer.Start();

            AppLogo = new PictureBox
            {
                Location = new Point(136, 40),
                Size = new Size(128, 128),
                SizeMode = PictureBoxSizeMode.Zoom,
                TabStop = false,
                Image = logo
            };
            Controls.Add(AppLogo);

            AppName = new Label
            {
                AutoSize = false,
                Font = SkinManager.HpSimpl_Bold_16,
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                Location = new Point(50, 230),
                Size = new Size(300, 25),
                Text = appName,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(AppName);

            LoadingSlider = new Panel
            {
                BackColor = SkinManager.ColorScheme.Background,
                Location = new Point(40, 440),
                Size = new Size(320, 20)
            };
            Controls.Add(LoadingSlider);

            PanelSlide = new Panel
            {
                BackColor = SkinManager.ColorScheme.ComplementaryColor,
                Location = new Point(-80, 0),
                Size = new Size(80, 20)
            };
            LoadingSlider.Controls.Add(PanelSlide);
            ResumeLayout(false);
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            PanelSlide.Left += 2;
            if (PanelSlide.Left > 420) PanelSlide.Left = -80;
        }
    }
}