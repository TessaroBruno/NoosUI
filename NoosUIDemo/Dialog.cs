using Noos.UI.Components;
using Noos.UI.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoosUIDemo
{
    public partial class Dialog : NoosDialog
    {
        private readonly ThemeManager noosTheme;
        public Dialog()
        {
            InitializeComponent();
        }

        private void noosComplementaryButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
