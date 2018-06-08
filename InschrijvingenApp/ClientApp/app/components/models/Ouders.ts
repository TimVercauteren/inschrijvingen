import { Persoon } from "./persoon";
import { Adres } from "./Adres";

export class Ouders {
    constructor() {
        this.ouder1 = new Persoon();
        this.ouder2 = new Persoon();
        this.adres = new Adres();
        this.telefoon1 = "";
        this.telefoon2 = "";
        this.noodtelefoon = "";
        this.email1 = "";
        this.email2 = "";
    }

    public ouder1: Persoon;
    public ouder2: Persoon;
    public adres: Adres;
    public telefoon1: string;
    public telefoon2: string;
    public noodtelefoon: string;
    public email1: string;
    public email2: string;
}