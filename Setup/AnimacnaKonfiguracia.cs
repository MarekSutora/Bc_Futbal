using System;
using System.Collections.Generic;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class AnimacnaKonfiguracia
    {

        public AnimacnaKonfiguracia()
        {
            ZobrazitPreddefinovanuAnimaciuDomaci = true;
            ZobrazitPreddefinovanuAnimaciuHostia = true;
            AnimacieDomaci = new List<string>();
            AnimacieHostia = new List<string>();
        }

        public bool ZobrazitPreddefinovanuAnimaciuDomaci { get; set; }
        
        public bool ZobrazitPreddefinovanuAnimaciuHostia { get; set; }
        
        public List<string> AnimacieDomaci { get; set; }
        
        public List<string> AnimacieHostia { get; set; }
    }
}
