import { Component } from '@angular/core';
import { AdminService } from '../services/adminservices';
import { Inschrijving } from '../models/inschrijving';
import { SearchModel } from '../models/searchModel';
import { Kind } from '../models/Kind';
import { Adres } from '../models/Adres';


@Component({
    selector: 'admin',
    templateUrl: './admin.component.html'
})
export class AdminComponent {

    constructor(private adminService: AdminService) {

    }

    private loggedIn: boolean = false;
    private hasSearched: boolean = false;
    private hasClickedName: boolean = false;

    private password: string = "";
    private zoekNaam: string = "";

    private inschrijving = new Inschrijving();
    private kind = this.inschrijving.kind;
    private ouders = this.inschrijving.ouders;
    private medisch = this.inschrijving.medisch;

    private searchList = this.populateSearchList();

    populateSearchList() {
        let v1 = new SearchModel();
        v1.id = 1;
        v1.naam = "vercauteren";
        v1.voornaam = "tim"
        let v2 = new SearchModel();
        v2.id = 2;
        v2.naam = "vercauteren";
        v2.voornaam = "jannick";
        return [v1, v2];
    }

    mockData() {
        this.kind = new Kind();
        this.kind.persoon.voornaam = "Tim";
        this.kind.persoon.naam = "Vercauteren";
        this.kind.geboortedatum = new Date("2014-01-01");
        this.kind.broersZussen = "Astrid, Jannick";
        this.kind.afhaalPersoon = "Hilde";
        this.kind.zelfNaarHuis = true;

        let adres = new Adres();
        adres.bus = "a";
        adres.gemeente = "Zele";
        adres.huisnummer = "30";
        adres.postcode = "9240";
        adres.straat = "Zuidlaan"

        this.ouders.adres = adres;
        this.ouders.ouder1.voornaam = "Philip";
        this.ouders.ouder1.naam = "Vercauteren";
        this.ouders.ouder2.voornaam = "Hilde";
        this.ouders.ouder2.naam = "Daneels";
        this.ouders.telefoon1 = "052/44 91 72";
        this.ouders.email1 = "philip.vercauteren@gmail.com";
        this.ouders.noodtelefoon = "052/44 91 72";
    }

    displayChild(id: number) {
        console.log(id);
        this.hasClickedName = true;

        this.mockData();
    }

    login() {
        console.log("ingelogd");
        var response = this.adminService.authenticate(this.password)
            .subscribe((jsondata) => {
                console.log(jsondata)
            },
                (error) => console.log(error),
                () => console.log("observable complete"));

        this.loggedIn = true;
    }

    zoekKind() {
        console.log(this.zoekNaam);
        this.hasSearched = true;
    }

    afdrukkenKleuters() {
        console.log("afdrukken kleuters");
        //call admdin service
    }

    afdrukkenJongsten() {
        console.log("afdrukken jongsten");
        //call admdin service
    }

    afdrukkenMidden() {
        console.log("afdrukken midden");
        //call admdin service
    }

    afdrukkenOudsten() {
        console.log("afdrukken oudsten");
        //call admdin service
    }
}
