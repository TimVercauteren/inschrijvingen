
import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, URLSearchParams, ResponseType, ResponseContentType } from '@angular/http';
import 'rxjs/add/operator/map'
import { Inschrijving } from '../models/inschrijving';


@Injectable()
export class AdminService {
    constructor(private http: Http) { }

    private baseUrl: string = "http://localhost:57805/api";
    private admin: string = "/admin";
    private gegevens: string = "/gegevens";

    authenticate(password: string) {
        let body = `password=${password}`;
        var headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let options = new RequestOptions({ headers: headers });

        return this.http
            .post(this.baseUrl + this.admin + '/login', body, options)
            .map(response => response.json());
    }

    getChild(id: number) {

        return this.http
            .get(this.baseUrl + this.admin + '/kind/' + id)
            .map(response => response.json());
    }

    zoekChild(zoekTekst: string, param: string) {

        let params: URLSearchParams = new URLSearchParams();
        params.set('zoekTekst', zoekTekst);
        params.set('param', param);


        return this.http
            .get(this.baseUrl + this.admin + '/kind/zoek', { search: params })
            .map(response => response.json());
    }

    getExcels(key: string) {
        return this.http
            .get(this.baseUrl + this.admin + '/' + key, { responseType: ResponseContentType.Blob })
            .map(res => {
                return {
                    filename: key + ".xlsx",
                    data: res.blob()
                };
            });
    }

    postInschrijving(inschrijving: Inschrijving) {
        let body = inschrijving;
        let url = this.baseUrl + this.gegevens;

        return this.http
            .post(url, body)
            .map(res => res.json());
    }



}