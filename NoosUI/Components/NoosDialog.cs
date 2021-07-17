using Noos.UI.Themes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosDialog : Form
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosDialog()
        {
            StartPosition = FormStartPosition.CenterParent;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SkinManager.ColorScheme.ComplementaryColor;
            FormBorderStyle = FormBorderStyle.None;
            Padding = new Padding(8);
            TopMost = true;
        }

        public void ShowNoosDialog()
        {
            Form coverform = new Form();
            try
            {
                // Cover full screen
                coverform.StartPosition = FormStartPosition.Manual;
                coverform.WindowState = FormWindowState.Maximized;
                coverform.FormBorderStyle = FormBorderStyle.None;
                coverform.Opacity = .70d;
                coverform.BackColor = Color.Black;
                coverform.TopMost = true;
                coverform.ShowInTaskbar = false;
                coverform.Show();

                Owner = coverform;
                ShowDialog();
                coverform.Dispose();
            }
            catch (Exception ex) { }
            finally { coverform.Dispose(); }
        }
    }
}