

namespace LGR_Futbal.Model
{
    public class Offside : Udalost
    {
        public int IdOut { get; set; }
        public int IdUdalost { get; set; }
        public Hrac Hrac { get; set; }

        public Offside()
        {
            Hrac = new Hrac();
        }
    }
}
