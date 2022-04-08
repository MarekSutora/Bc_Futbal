

namespace LGR_Futbal.Model
{
    public class Karta : Udalost
    {
        public Hrac Hrac { get; set; }
        public char TypKarty { get; set; }

        public Karta()
        {
            Hrac = new Hrac();
        }
    }
}
