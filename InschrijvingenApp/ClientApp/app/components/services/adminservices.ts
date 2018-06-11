
import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, URLSearchParams  } from '@angular/http';
import 'rxjs/add/operator/map'


@Injectable()
export class AdminService {
    constructor(private http: Http) { }

    private baseUrl: string = "http://localhost:57805/api";
    private admin: string = "/admin"

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
            .get(this.baseUrl + this.admin + '/' + key)
            .map(response => response.json());
    }



}