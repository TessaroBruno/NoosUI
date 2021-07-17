using Noos.UI.Themes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosComboBox : ComboBox
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        [DefaultValue(DrawMode.OwnerDrawFixed)]
        [Browsable(false)]
        public new DrawMode DrawMode
        {
            get { return DrawMode.OwnerDrawFixed; }
            set { base.DrawMode = DrawMode.OwnerDrawFixed; }
        }

        [DefaultValue(ComboBoxStyle.DropDownList)]
        [Browsable(false)]
        public new ComboBoxStyle DropDownStyle
        {
            get { return ComboBoxStyle.DropDownList; }
            set { base.DropDownStyle = ComboBoxStyle.DropDownList; }
        }

        private string promptText = "";
        [Browsable(true)]
        [DefaultValue("")]
        public string PromptText
        {
            get { return promptText; }
            set { promptText = value ?? String.Empty; Invalidate(); }
        }

        private bool drawPrompt;

        public NoosComboBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            base.DrawMode = DrawMode.OwnerDrawFixed;
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle = FlatStyle.Flat;
            BackColor = SkinManager.ColorScheme.SecondaryColorLight;
            Size = new Size(200, 36);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ItemHeight = GetPreferredSize(Size.Empty).Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillPolygon(SkinManager.ColorScheme.SecondaryLightBrush, new[]
            {
                new Point(Width - 20, (Height / 2) - 2),
                new Point(Width - 9, (Height / 2) - 2),
                new Point(Width - 15,  (Height / 2) + 4)
            });
            TextRenderer.DrawText(e.Graphics, Text, SkinManager.HpSimpl_Reg_12,
                new Rectangle(2, 2, Width - 20, Height - 4), SkinManager.ColorScheme.SecondaryColorLight,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            if (drawPrompt)
                DrawTextPrompt(e.Graphics);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                base.OnDrawItem(e);
                return;
            }
            bool normal = e.State == (DrawItemState.NoAccelerator |
                DrawItemState.NoFocusRect) || e.State == DrawItemState.None;
            e.Graphics.FillRectangle(SkinManager.ColorScheme.SecondaryLightBrush, e.Bounds);
            TextRenderer.DrawText(e.Graphics, GetItemText(Items[e.Index]), SkinManager.HpSimpl_Reg_12,
                e.Bounds, SkinManager.ColorScheme.PrimaryTextColor, SkinManager.ColorScheme.SecondaryColorLight,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        private void DrawTextPrompt(Graphics g)
        {
            TextRenderer.DrawText(g, promptText, SkinManager.HpSimpl_Reg_12,
                new Rectangle(2, 2, Width - 20, Height - 4), SkinManager.ColorScheme.SecondaryColorLight,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            using (var g = CreateGraphics())
            {
                string measureText = Text.Length > 0 ? Text : "MeasureText";
                proposedSize = new Size(int.MaxValue, int.MaxValue);
                Size preferredSize = TextRenderer.MeasureText(g, measureText, SkinManager.HpSimpl_Reg_12,
                    proposedSize, TextFormatFlags.LeftAndRightPadding);
                preferredSize.Height += 4;
                return preferredSize;
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            drawPrompt = (SelectedIndex == -1);
            Invalidate();
        }
    }
}