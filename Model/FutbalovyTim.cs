using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace LGR_Futbal.Model
{
    public class FutbalovyTim
    {
        private List<Hrac> zoznamHracov;
        public string NazovTimu { get; set; }
        public string Logo { get; set; }
        public byte[] LogoBlob { get; set; }
        public Image LogoImage { get; set; }
        public List<Hrac> ZoznamHracov { get => zoznamHracov; set => zoznamHracov = value; }
        public int Kategoria { get; set; }
        public int IdFutbalovyTim { get; set; }
        public FutbalovyTim()
        {
            LogoBlob = null;
            LogoImage = null;
            zoznamHracov = new List<Hrac>();
        }
    }
}
