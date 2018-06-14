import { Persoon } from "./persoon";

export class Kind {

    constructor() {
        this.persoon = new Persoon();
        this.geboortedatum = new Date("2014-01-01");
    }

    public persoon: Persoon;
    public geboortedatum: Date;
    public broersZussen: string = '';
    public zelfNaarHuis: boolean = false;
    public afhaalPersoon: string = '';

}