using System.Drawing;

namespace Noos.UI.Themes
{
    public class ColorScheme
    {
        public readonly Color PrimaryColor, PrimaryColorLight,
            SecondaryColor, SecondaryColorLight, ComplementaryColor,
            ComplementaryColorLight, Background, PrimaryTextColor, SecondaryTextColor;
        public readonly Pen PrimaryPen, PrimaryLightPen,
            SecondaryPen, SecondaryLightPen, ComplementaryPen,
            ComplementaryLightPen, BackgroundPen, PrimaryTextPen, SecondaryTextPen;
        public readonly Brush PrimaryBrush, PrimaryLightBrush,
            SecondaryBrush, SecondaryLightBrush, ComplementaryBrush,
            ComplementaryLightBrush, BackgroundBrush, PrimaryTextBrush, SecondaryTextBrush;

        public ColorScheme(string theme)
        {
            switch (theme)
            {
                case "themeblu":
                    break;
                case "themegray":
                default:
                    //Color
                    PrimaryColor = Color.FromArgb(33, 37, 41);
                    PrimaryColorLight = Color.FromArgb(93, 97, 101);
                    SecondaryColor = Color.FromArgb(52, 58, 64);
                    SecondaryColorLight = Color.FromArgb(202, 208, 224);
                    ComplementaryColor = Color.FromArgb(0, 123, 255);
                    ComplementaryColorLight = Color.FromArgb(40, 153, 255);
                    Background = Color.FromArgb(255, 255, 255);
                    PrimaryTextColor = Color.FromArgb(33, 37, 41);
                    SecondaryTextColor = Color.FromArgb(144, 146, 148);
                    break;
            }

            //Pen
            PrimaryPen = new Pen(PrimaryColor, 3);
            PrimaryLightPen = new Pen(PrimaryColorLight, 3);
            SecondaryPen = new Pen(SecondaryColor, 3);
            SecondaryLightPen = new Pen(SecondaryColorLight, 3);
            ComplementaryPen = new Pen(ComplementaryColor, 3);
            ComplementaryLightPen = new Pen(ComplementaryColorLight, 3);
            BackgroundPen = new Pen(Background, 3);
            PrimaryTextPen = new Pen(PrimaryTextColor, 3);
            SecondaryTextPen = new Pen(SecondaryTextColor, 3);

            //Brush
            PrimaryBrush = new SolidBrush(PrimaryColor);
            PrimaryLightBrush = new SolidBrush(PrimaryColorLight);
            SecondaryBrush = new SolidBrush(SecondaryColor);
            SecondaryLightBrush = new SolidBrush(SecondaryColorLight);
            ComplementaryBrush = new SolidBrush(ComplementaryColor);
            ComplementaryLightBrush = new SolidBrush(ComplementaryColorLight);
            BackgroundBrush = new SolidBrush(Background);
            PrimaryTextBrush = new SolidBrush(PrimaryTextColor);
            SecondaryTextBrush = new SolidBrush(SecondaryTextColor);
        }
    }
}