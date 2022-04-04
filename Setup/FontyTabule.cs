using System;
using System.ComponentModel;
using System.Drawing;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class FontyTabule
    {

        public string SkoreFont { get; set; }
        public string NazvyFont { get; set; }
        public string CasFont { get; set; }
        public string PolcasFont { get; set; }
        public string StriedaniaFont { get; set; }
        public string NazvyPrezentaciaFont { get; set; }
        public string PodnadpisPrezentaciaFont { get; set; }
        public string UdajePrezentaciaFont { get; set; }
        public string CisloMenoPrezentaciaFont { get; set; }
        public FontyTabule()
        {
            Font font = new Font("Arial", 12, FontStyle.Bold);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            SkoreFont = converter.ConvertToString(font);
            NazvyFont = converter.ConvertToString(font);
            CasFont = converter.ConvertToString(font);
            PolcasFont = converter.ConvertToString(font);
            StriedaniaFont = converter.ConvertToString(font);
            NazvyPrezentaciaFont = converter.ConvertToString(font);
            PodnadpisPrezentaciaFont = converter.ConvertToString(font);
            UdajePrezentaciaFont = converter.ConvertToString(font);
            CisloMenoPrezentaciaFont = converter.ConvertToString(font);
        }

        public Font CreateSkoreFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(SkoreFont);
        }

        public Font CreateNazvyFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(NazvyFont);
        }

        public Font CreateCasFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(CasFont);
        }

        public Font CreatePolcasFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(PolcasFont);
        }

        public Font CreateStriedaniaFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(StriedaniaFont);
        }

        public Font CreateNazvyPrezentaciaFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(NazvyPrezentaciaFont);
        }

        public Font CreatePodnadpisPrezentaciaFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(PodnadpisPrezentaciaFont);
        }

        public Font CreateUdajePrezentaciaFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(UdajePrezentaciaFont);
        }

        public Font CreateCisloMenoPrezentaciaFont()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(CisloMenoPrezentaciaFont);
        }
    }
}
