using InschrijvenPietieterken.Entities;

namespace InschrijvingPietieterken.Entities
{
    public class Medisch : EntityBase
    {
        public string HuisArtsNaam { get; set; }
        public string HuisArtsTelefoon { get; set; }
        public string ZiekteIngreep { get; set; }
        public bool Suikerziekte { get; set; }
        public bool Astma { get; set; }
        public bool Hartkwaal { get; set; }
        public bool Huidaandoening { get; set; }
        public bool Epilepsie { get; set; }
        public string Allergieen { get; set; } // ; seperated
        public string AndereAandodeningen { get; set; } // ; seperated
        public string AanpakKind { get; set; }
        public bool VaccinatieKindEnGezin { get; set; }
        public bool KanZwemmen { get; set; }
        public bool KanSporten { get; set; }
        public string BelemmeringenSport { get; set; }
        public bool Geneesmiddelen { get; set; }
        public string GeneesmiddelenLijst { get; set; }
        public bool PijnStillersAllowed { get; set; }
        public bool FotosAllowed { get; set; }
    }
}