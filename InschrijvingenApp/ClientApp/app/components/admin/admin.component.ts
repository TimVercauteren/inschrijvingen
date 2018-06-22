import { Component, OnInit } from '@angular/core';
import { AdminService } from '../services/adminservices';
import { Inschrijving } from '../models/inschrijving';
import { SearchModel } from '../models/searchModel';
import { Kind } from '../models/Kind';
import { Adres } from '../models/Adres';
import { Router, Route, ActivatedRoute } from '@angular/router';
import { ResponseType, ResponseContentType } from '@angular/http';


@Component({
    selector: 'admin',
    templateUrl: './admin.component.html',
})
export class AdminComponent implements OnInit {

    constructor(private adminService: AdminService, private router: Router, private route: ActivatedRoute) {

    }

    public errors: string = "";
    public hasErrors: boolean = false;

    public loggedIn: boolean = false;
    public hasSearched: boolean = false;
    public hasClickedName: boolean = false;

    public password: string = "";
    public zoekNaam: string = "";
    public childId: number = 0;

    public zoekenOpVoornaam: boolean = false;

    public searchList: Array<SearchModel> = [];

    ngOnInit() {
        let loggedIn = "0";
        this.route.params.subscribe(params => loggedIn = params.loggedIn);
        if (loggedIn === "1") {
            this.loggedIn = true;
        }
    }

    displayChild(id: number) {
        console.log(id);
        this.router.navigateByUrl('/child/' + id);
        this.childId = id;
    }

    login() {
        this.hasErrors = false;
        var response = this.adminService.authenticate(this.password)
            .subscribe(
                (jsondata) => {
                    this.loggedIn = true;
                    console.log("ingelogd");
                },
                (error) => {
                    this.loggedIn = false;
                    this.errors = "Fout paswoord, probeer opnieuw om in te loggen";
                    this.hasErrors = true;
                }
            );
    }

    zoekKind() {
        console.log(this.zoekNaam);
        let param = this.zoekParam(this.zoekenOpVoornaam);
        var response = this.adminService.zoekChild(this.zoekNaam, param)
            .subscribe((result) => this.searchList = result);
        this.hasSearched = true;
    }

    zoekParam(isOpVoornaam: boolean): string {
        if (isOpVoornaam) {
            return "voornaam";
        }
        else return "naam";
    }

    afdrukkenKleuters() {
        console.log("afdrukken kleuters");
        var response = this.adminService.getExcels("kleuters")
            .subscribe(res => {
                console.log('start download', res);
                var url = window.URL.createObjectURL(res.data);
                var a = document.createElement('a');
                document.body.appendChild(a);
                a.setAttribute('style', 'display:none');
                a.href = url;
                a.download = res.filename;
                a.click();
                window.URL.revokeObjectURL(url);
                a.remove();
            }, (error) => {
                console.log('download error:', JSON.stringify(error));
            }, () => {
                console.log('Completed download');
            });
    }

    afdrukkenJongsten() {
        console.log("afdrukken jongsten");
        var response = this.adminService.getExcels("jongsten")
            .subscribe(res => {
                console.log('start download', res);
                var url = window.URL.createObjectURL(res.data);
                var a = document.createElement('a');
                document.body.appendChild(a);
                a.setAttribute('style', 'display:none');
                a.href = url;
                a.download = res.filename;
                a.click();
                window.URL.revokeObjectURL(url);
                a.remove();
            }, (error) => {
                console.log('download error:', JSON.stringify(error));
            }, () => {
                console.log('Completed download');
            });
    }

    afdrukkenMidden() {
        console.log("afdrukken midden");
        var response = this.adminService.getExcels("midden")
            .subscribe(res => {
                console.log('start download', res);
                var url = window.URL.createObjectURL(res.data);
                var a = document.createElement('a');
                document.body.appendChild(a);
                a.setAttribute('style', 'display:none');
                a.href = url;
                a.download = res.filename;
                a.click();
                window.URL.revokeObjectURL(url);
                a.remove();
            }, (error) => {
                console.log('download error:', JSON.stringify(error));
            }, () => {
                console.log('Completed download');
            });
    }

    afdrukkenOudsten() {
        console.log("afdrukken oudsten");
        var response = this.adminService.getExcels("oudsten")
            .subscribe(res => {
                console.log('start download', res);
                var url = window.URL.createObjectURL(res.data);
                var a = document.createElement('a');
                document.body.appendChild(a);
                a.setAttribute('style', 'display:none');
                a.href = url;
                a.download = res.filename;
                a.click();
                window.URL.revokeObjectURL(url);
                a.remove();
            }, (error) => {
                console.log('download error:', JSON.stringify(error));
            }, () => {
                console.log('Completed download');
            });
    }
}
