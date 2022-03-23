using System;
using System.ComponentModel;
using System.Drawing;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class FontyTabule
    {
        private string skoreFont;
        private string nazvyFont;
        private string casFont;
        private string polcasFont;
        private string striedaniaFont;

        public FontyTabule()
        {
            Font font = new Font("Arial", 12, FontStyle.Bold);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            SkoreFont = converter.ConvertToString(font);
            NazvyFont = converter.ConvertToString(font);
            CasFont = converter.ConvertToString(font);
            PolcasFont = converter.ConvertToString(font);
            StriedaniaFont = converter.ConvertToString(font);
        }

        public string SkoreFont { get => skoreFont; set => skoreFont = value; }
        public string NazvyFont { get => nazvyFont; set => nazvyFont = value; }
        public string CasFont { get => casFont; set => casFont = value; }
        public string PolcasFont { get => polcasFont; set => polcasFont = value; }
        public string StriedaniaFont { get => striedaniaFont; set => striedaniaFont = value; }

        public Font CreateSkoreFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(skoreFont);
        }

        public Font CreateNazvyFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(nazvyFont);
        }

        public Font CreateCasFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(casFont);
        }

        public Font CreatePolcasFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(polcasFont);
        }

        public Font CreateStriedaniaFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(striedaniaFont);
        }

        public void convertSkoreFont(Font font)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            SkoreFont = converter.ConvertToString(font);
        }

        public void convertNazvyFont(Font font)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            NazvyFont = converter.ConvertToString(font);
        }

        public void convertCasFont(Font font)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            CasFont = converter.ConvertToString(font);
        }

        public void convertPolcasFont(Font font)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            PolcasFont = converter.ConvertToString(font);
        }

        public void convertStriedaniaFont(Font font)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            StriedaniaFont = converter.ConvertToString(font);
        }
    }
}
