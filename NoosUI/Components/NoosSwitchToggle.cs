using Noos.UI.Themes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosSwitchToggle : CheckBox
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
                Invalidate();
            }
        }

        public NoosSwitchToggle()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            AutoSize = false;
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.Clear(Parent.BackColor);

            if (Checked)
            {
                g.FillPath(SkinManager.ColorScheme.ComplementaryBrush,
                    RoundRectangle.Create(0, Height / 2 - 8, 28, 16, 8));
                g.FillEllipse(SkinManager.ColorScheme.PrimaryBrush,
                    new Rectangle(15, Height / 2 - 5, 10, 10));
            }
            else
            {
                g.FillPath(SkinManager.ColorScheme.SecondaryLightBrush,
                    RoundRectangle.Create(0, Height / 2 - 8, 28, 16, 8));
                g.FillEllipse(SkinManager.ColorScheme.PrimaryBrush,
                    new Rectangle(3, Height / 2 - 5, 10, 10));
            }

            g.DrawString(
                Text,
                SkinManager.HpSimpl_Reg_12,
                SkinManager.ColorScheme.PrimaryTextBrush,
                new Point(30, (Height / 2) - 9)
                );
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            Invalidate();
        }
    }
}