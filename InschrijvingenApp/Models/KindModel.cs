using System;

namespace InschrijvingPietieterken.Controllers
{
    public class KindModel
    {
        public PersoonModel Persoon { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string BroersZussen { get; set; } //seperate sibligs with ;
        public bool ZelfNaarHuis { get; set; }
        public string AfhaalPersoon { get; set; }
    }
}