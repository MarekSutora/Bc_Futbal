

namespace BC_Futbal.Model
{
    public class Striedanie : Udalost
    {
        public int IdStriedania { get; set; }
        public Hrac Striedajuci { get; set; }
        public Hrac Striedany { get; set; }

        public Striedanie()
        {
            Striedajuci = new Hrac();
            Striedany = new Hrac();
        }
    }
}
