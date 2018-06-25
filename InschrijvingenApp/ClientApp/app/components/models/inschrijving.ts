import { Kind } from "./kind";
import { Ouders } from "./ouders";
import { Medisch } from "./medisch";

export class Inschrijving {

    constructor() {
        this.kind = new Kind();
        this.ouders = new Ouders();
        this.medisch = new Medisch();
    }

    public kind: Kind;
    public ouders: Ouders;
    public medisch: Medisch;
    public overigeInfo: string = "";
    public heeftMaandAbonnement: boolean = false;
}