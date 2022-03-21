using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace LGR_Futbal.Model
{
    public class FutbalovyTim
    {
        private string nazov;
        private string logo;
        private List<Hrac> zoznamHracov;
        public string NazovTimu { get => nazov; set => nazov = value; }
        public string Logo { get => logo; set => logo = value; }
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
