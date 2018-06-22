import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Kind } from '../models/kind';
import { Ouders } from '../models/ouders';
import { Medisch } from '../models/medisch';
import { Inschrijving } from '../models/inschrijving';
import { InschrijvingModel } from '../models/inschrijvingModel';
import { AdminService } from '../services/adminservices';

@Component({
    selector: 'inschrijving',
    templateUrl: './inschrijving.component.html'
})
export class InschrijvingComponent {

    public inschrijving: Inschrijving;
    public model: InschrijvingModel

    constructor(private adminService: AdminService) {
        this.inschrijving = new Inschrijving();
        this.model = new InschrijvingModel();
    }

    onSubmit() {
        console.log(this.model);
        this.inschrijving = this.vulInschrijvingIn(this.model)
        this.adminService.postInschrijving(this.inschrijving)
            .subscribe(
                (res) => console.log('inschrijving Ok'),
                (error) => console.log(error)
            );
    }

    vulInschrijvingIn(model: InschrijvingModel): Inschrijving {
        let inschrijvingIngevulud = new Inschrijving();

        inschrijvingIngevulud.kind = this.vulKindIn(model);
        inschrijvingIngevulud.ouders = this.vulOudersIn(model);
        inschrijvingIngevulud.medisch = this.vulMedischIn(model);
        inschrijvingIngevulud.overigeInfo = model.overigeInfo;

        return inschrijvingIngevulud;
    }

    vulMedischIn(model: InschrijvingModel): Medisch {
        let medisch = new Medisch();

        medisch.aanpakKind = model.aanpakKind;
        medisch.allergieen = model.allergieen;
        medisch.andereAandoeningen = model.andereAandoeningen;
        medisch.astma = model.astma;
        medisch.belemmeringenSport = model.belemmeringenSport;
        medisch.epilepsie = model.epilepsie;
        medisch.fotosAllowed = model.fotosAllowed;
        medisch.geneesmiddelen = model.geneesmiddelen;
        medisch.geneesmiddelenLijst = model.geneesmiddelenLijst;
        medisch.hartkwaal = model.hartkwaal;
        medisch.huidaandoening = model.huidaandoening;
        medisch.huisArtsNaam = model.huisArtsNaam;
        medisch.huisArtsTelefoon = model.huisArtsTelefoon;
        medisch.kanSporten = model.kanSporten;
        medisch.kanZwemmen = model.kanZwemmen;
        medisch.pijnstillersAllowed = model.pijnstillersAllowed;
        medisch.suikerZiekte = model.suikerZiekte;
        medisch.vaccinatieKindEnGezin = model.vaccinatieKindEnGezin;
        medisch.ziekteIngreep = model.ziekteIngreep;

        return medisch;
    }

    vulOudersIn(model: InschrijvingModel): Ouders {
        let ouders = new Ouders();

        ouders.adres.bus = model.bus;
        ouders.adres.gemeente = model.gemeente;
        ouders.adres.huisnummer = model.huisnummer;
        ouders.adres.postcode = model.postcode;
        ouders.adres.straat = model.straat;

        ouders.email1 = model.email1;
        ouders.email2 = model.email2;
        ouders.telefoon1 = model.telefoon1;
        ouders.telefoon2 = model.telefoon2;
        ouders.noodtelefoon = model.noodtelefoon;

        ouders.ouder1.naam = model.naamOuder1;
        ouders.ouder1.voornaam = model.voornaamOuder1;
        ouders.ouder2.naam = model.naamOuder2;
        ouders.ouder2.voornaam = model.voornaamOuder2;

        return ouders;
    }

    vulKindIn(model: InschrijvingModel): Kind {
        let kind = new Kind();

        kind.afhaalPersoon = model.afhaalPersoon;
        kind.broersZussen = model.broersZussen;
        kind.geboortedatum = model.geboortedatum;
        kind.zelfNaarHuis = model.zelfNaarHuis;
        kind.persoon.naam = model.naamKind;
        kind.persoon.voornaam = model.voornaamKind;

        return kind;
    }
}
