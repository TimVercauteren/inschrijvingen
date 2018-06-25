namespace InschrijvingPietieterken.Controllers
{
    public class InschrijvingModel
    {
        public KindModel Kind { get; set; }
        public OudersModel Ouders { get; set; }
        public MedischModel Medisch { get; set; }
        public string OverigeInfo { get; set; }
        public string HeeftMaandAbonnement { get; set; }
    }
}