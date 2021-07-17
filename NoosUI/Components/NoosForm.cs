using Noos.UI.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosForm : Form
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1366, 768);
            BackColor = SkinManager.ColorScheme.Background;
            // TransparencyKey = Color.Maroon;
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