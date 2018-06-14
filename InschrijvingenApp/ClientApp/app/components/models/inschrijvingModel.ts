export class InschrijvingModel {

    //Medisch
    public huisArtsNaam: string = '';
    public huisArtsTelefoon: string = '';
    public ziekteIngreep: string = '';
    public suikerZiekte: boolean = false;
    public astma: boolean = false;
    public hartkwaal: boolean = false;
    public huidaandoening: boolean = false;
    public epilepsie: boolean = false;
    public allergieen: string = '';
    public andereAandoeningen: string = '';

    public aanpakKind: string = '';
    public vaccinatieKindEnGezin: boolean = false;
    public kanZwemmen: boolean = true;
    public kanSporten: boolean = true;
    public belemmeringenSport: string = '';

    public geneesmiddelen: boolean = false;
    public geneesmiddelenLijst: string = '';
    public pijnstillersAllowed: boolean = false;
    public fotosAllowed: boolean = true;

    //Kind
    public voornaamKind: string = '';
    public naamKind: string = '';
    public geboortedatum: Date = new Date("2014-01-01");
    public broersZussen: string = '';
    public zelfNaarHuis: boolean = false;
    public afhaalPersoon: string = '';

    //Ouders
    public telefoon1: string = '';
    public telefoon2: string = '';
    public noodtelefoon: string = '';
    public email1: string = '';
    public email2: string = '';
    public voornaamOuder1: string = '';
    public naamOuder1: string = '';
    public voornaamOuder2: string = '';
    public naamOuder2: string = '';
    public straat: string = '';
    public huisnummer: string = '';
    public bus: string = '';
    public postcode: string = '';
    public gemeente: string = '';

    //overige info
    public overigeInfo: string = '';

}