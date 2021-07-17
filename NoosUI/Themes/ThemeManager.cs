using Noos.UI.Components;
using Noos.UI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Noos.UI.Themes
{
    public class ThemeManager
    {
        private static ThemeManager instance;
        private readonly List<NoosForm> formsToManage = new List<NoosForm>();

        private readonly PrivateFontCollection
            privateFontCollection = new PrivateFontCollection();
        public Font HpSimpl_Reg_12;
        public Font HpSimpl_Reg_16;
        public Font HpSimpl_Bold_12;
        public Font HpSimpl_Bold_16;
        public Font Nunito_Reg_12;
        public Font Nunito_Reg_16;

        private ColorScheme colorScheme;
        public ColorScheme ColorScheme
        {
            get { return colorScheme; }
            set
            {
                colorScheme = value;
                UpdateForm();
            }
        }

        public static ThemeManager Instance => instance ?? (instance = new ThemeManager());

        private ThemeManager()
        {
            HpSimpl_Reg_12 = new Font(LoadFont(Resources.hp_simplified), 12f);
            HpSimpl_Reg_16 = new Font(LoadFont(Resources.hp_simplified), 16f);
            HpSimpl_Bold_12 = new Font(LoadFont(Resources.hp_simplified_bold), 12f);
            HpSimpl_Bold_16 = new Font(LoadFont(Resources.hp_simplified_bold), 16f);
            Nunito_Reg_12 = new Font(LoadFont(Resources.Nunito_Regular), 12f);
            Nunito_Reg_16 = new Font(LoadFont(Resources.Nunito_Regular), 16f);

            ColorScheme = new ColorScheme("themegray");
        }

        // Fonts
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(
            IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        private FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }

        // Forms managed list
        public void AddFormToManage(NoosForm noosForm)
        {
            formsToManage.Add(noosForm);
            UpdateForm();
        }

        public void RemoveFormToManage(NoosForm noosForm)
        {
            formsToManage.Remove(noosForm);
        }

        // Update Forms
        private void UpdateForm()
        {
            foreach (var noosForm in formsToManage)
                UpdateControl(noosForm);
        }

        // Update Control elements
        private void UpdateControl(Control controlToUpdate)
        {
            if (controlToUpdate == null) return;
            // Recursive call
            foreach (Control control in controlToUpdate.Controls)
                UpdateControl(control);
            controlToUpdate.Invalidate();
        }
    }
}