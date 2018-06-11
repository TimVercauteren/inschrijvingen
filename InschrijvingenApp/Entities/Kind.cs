using InschrijvenPietieterken.Entities;
using System;

namespace InschrijvingPietieterken.Entities
{
    public class Kind : EntityBase
    {
        public Kind()
        {
            Persoon = new Persoon();
        }

        public Persoon Persoon { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string BroersZussen { get; set; } //seperate sibligs with ;
        public bool ZelfNaarHuis { get; set; }
        public string AfhaalPersoon { get; set; }

    }
}