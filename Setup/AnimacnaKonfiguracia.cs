using System;
using System.Collections.Generic;

namespace LGR_Futbal.Setup
{
    [Serializable]
    public class AnimacnaKonfiguracia
    {
        public bool ZobrazitAnimaciuDomaci { get; set; }
        public bool ZobrazitAnimaciuHostia { get; set; }
        public List<string> AnimacieDomaci { get; set; }
        public List<string> AnimacieHostia { get; set; }
        public string ZltaKartaAnimacia { get; set; }
        public string CervenaKartaAnimacia { get; set; }
        public AnimacnaKonfiguracia()
        {
            ZobrazitAnimaciuDomaci = true;
            ZobrazitAnimaciuHostia = true;
            AnimacieDomaci = new List<string>();
            AnimacieHostia = new List<string>();
            ZltaKartaAnimacia = "";
            CervenaKartaAnimacia = "";
        }
    }
}
