using DataAccess.Entities;

namespace InschrijvingPietieterken.Entities
{
    public class Adres : EntityBase
    {
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Bus { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }

    }
}