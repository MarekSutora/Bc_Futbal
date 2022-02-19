using System;
using System.Collections.Generic;

namespace LGR_Futbal.Triedy
{
    [Serializable]
    public class AnimacnaKonfiguracia
    {
        private bool zobrazitPreddefinovanuAnimaciuDomaci;
        private bool zobrazitPreddefinovanuAnimaciuHostia;
        private List<string> animacieDomaci;
        private List<string> animacieHostia;

        public AnimacnaKonfiguracia()
        {
            ZobrazitPreddefinovanuAnimaciuDomaci = true;
            ZobrazitPreddefinovanuAnimaciuHostia = true;
            AnimacieDomaci = new List<string>();
            AnimacieHostia = new List<string>();
        }

        public bool ZobrazitPreddefinovanuAnimaciuDomaci { get => zobrazitPreddefinovanuAnimaciuDomaci; set => zobrazitPreddefinovanuAnimaciuDomaci = value; }
        
        public bool ZobrazitPreddefinovanuAnimaciuHostia { get => zobrazitPreddefinovanuAnimaciuHostia; set => zobrazitPreddefinovanuAnimaciuHostia = value; }
        
        public List<string> AnimacieDomaci { get => animacieDomaci; set => animacieDomaci = value; }
        
        public List<string> AnimacieHostia { get => animacieHostia; set => animacieHostia = value; }
    }
}
