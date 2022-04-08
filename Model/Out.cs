
namespace LGR_Futbal.Model
{
    public class Out : Udalost
    {
        public int IdOut { get; set; }
        public int IdUdalost { get; set; }
        public Hrac Hrac { get; set; }

        public Out()
        {
            Hrac = new Hrac();
        }
    }
}
