

namespace LGR_Futbal.Model
{

    public class Gol : Udalost
    {
        public int IdGol { get; set; }
        public Hrac Strielajuci { get; set; }
        public Hrac Asistujuci { get; set; }
        public int TypGolu { get; set; }

        public Gol()
        {
            Asistujuci = new Hrac();
            Strielajuci = new Hrac();
        }
    }
}
