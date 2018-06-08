using DataAccess.Entities;

namespace InschrijvingPietieterken.Entities
{
    public class Inschrijving : EntityBase
    {
        public Inschrijving()
        {
            Kind = new Kind();
            Ouders = new Ouders();
            Medisch = new Medisch();
        }

        public int KindId { get; set; }
        public Kind Kind { get; set; }

        public int OudersId { get; set; }
        public Ouders Ouders { get; set; }

        public int MedischId { get; set; }
        public Medisch Medisch { get; set; }

        public string OverigeInfo { get; set; }
    }
}
