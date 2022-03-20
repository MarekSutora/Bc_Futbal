using System;

namespace LGR_Futbal.Triedy
{
    [Serializable]
    public class PriebehZapasu
    {
        private int minuta;
        private int polcas;
        private int dlzka;
        private int nadstavenie;
        private int skoreD;
        private int skoreH;

        public PriebehZapasu()
        {
            Minuta = 0;
            Polcas = 0;
            Dlzka = 45;
            Nadstavenie = 0;
            SkoreD = 0;
            SkoreH = 0;
        }

        public int Minuta { get => minuta; set => minuta = value; }
        public int Polcas { get => polcas; set => polcas = value; }
        public int Dlzka { get => dlzka; set => dlzka = value; }
        public int Nadstavenie { get => nadstavenie; set => nadstavenie = value; }
        public int SkoreD { get => skoreD; set => skoreD = value; }
        public int SkoreH { get => skoreH; set => skoreH = value; }
    }
}
