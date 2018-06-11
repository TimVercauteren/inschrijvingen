using InschrijvenPietieterken.Entities;

namespace InschrijvingPietieterken.Entities
{
    public class Ouders : EntityBase
    {
        public Ouders()
        {
            Ouder1 = new Persoon();
            Ouder2 = new Persoon();
            Adres = new Adres();
        }

        public Persoon Ouder1 { get; set; }
        public Persoon Ouder2 { get; set; }
        public Adres Adres { get; set; }
        public string Telefoon1 { get; set; }
        public string Telefoon2 { get; set; }
        public string NoodTelefoon { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
    }
}