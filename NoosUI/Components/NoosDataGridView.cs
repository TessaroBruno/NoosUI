using Noos.UI.Themes;
using System.ComponentModel;
using System.Windows.Forms;

namespace Noos.UI.Components
{
    public class NoosDataGridView : DataGridView
    {
        [Browsable(false)]
        public ThemeManager SkinManager => ThemeManager.Instance;

        public NoosDataGridView()
        {
            BackgroundColor = SkinManager.ColorScheme.Background;
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            EnableHeadersVisualStyles = false;
            ColumnHeadersHeight = 36;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowTemplate.Height = 36;
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SkinManager.ColorScheme.SecondaryColor,
                ForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                SelectionBackColor = SkinManager.ColorScheme.ComplementaryColorLight,
                SelectionForeColor = SkinManager.ColorScheme.SecondaryTextColor,
                WrapMode = DataGridViewTriState.True,
                Font = SkinManager.HpSimpl_Bold_12
            };
            AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SkinManager.ColorScheme.SecondaryColorLight
            };
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SkinManager.ColorScheme.Background,
                ForeColor = SkinManager.ColorScheme.PrimaryTextColor,
                SelectionBackColor = SkinManager.ColorScheme.ComplementaryColorLight,
                SelectionForeColor = SkinManager.ColorScheme.PrimaryTextColor,
                WrapMode = DataGridViewTriState.False,
                Font = SkinManager.HpSimpl_Reg_12
            };
        }
    }
}