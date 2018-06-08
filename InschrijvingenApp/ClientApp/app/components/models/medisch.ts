export class Medisch {
    constructor() {
        this.huisArtsNaam = "";
        this.huisArtsTelefoon = "";
        this.ziekteIngreep = "";
        this.suikerZiekte = false;
        this.astma = false;
        this.hartkwaal = false;
        this.huidaandoening = false;
        this.epilepsie = false;
        this.allergieen = new Array<string>();
        this.andereAandoeningen = new Array<string>();
        this.aanpakKind = "";
        this.vaccinatieKindEnGezin = false;
        this.kanZwemmen = false;
        this.kanSporten = false;
        this.belemmeringenSport = "";
        this.geneesmiddelen = false;
        this.geneesmiddelenLijst = "";
        this.pijnstillersAllowed = false;
        this.fotosAllowed = false;
    }

    public huisArtsNaam: string;
    public huisArtsTelefoon: string;
    public ziekteIngreep: string;
    public suikerZiekte: boolean;
    public astma: boolean;
    public hartkwaal: boolean;
    public huidaandoening: boolean;
    public epilepsie: boolean;
    public allergieen: Array<string>;
    public andereAandoeningen: Array<string>;
    public aanpakKind: string;
    public vaccinatieKindEnGezin: boolean;
    public kanZwemmen: boolean;
    public kanSporten: boolean;
    public belemmeringenSport: string;
    public geneesmiddelen: boolean;
    public geneesmiddelenLijst: string;
    public pijnstillersAllowed: boolean;
    public fotosAllowed: boolean;
}