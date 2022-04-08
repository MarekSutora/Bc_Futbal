

namespace LGR_Futbal.Model
{
    public class Kop : Udalost
    {
        public int IdKopu { get; set; }
        public int IdUdalost { get; set; }
        public Hrac Hrac { get; set; }
        public int IdTypKopu { get; set; }

        public Kop()
        {
            Hrac = new Hrac();
        }
    }
}
