
import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
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



}