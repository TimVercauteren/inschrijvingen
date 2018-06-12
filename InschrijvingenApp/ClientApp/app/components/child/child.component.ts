import { Component, OnInit, Input } from "@angular/core";
import { AdminService } from "../services/adminservices";
import { ActivatedRoute, Route, Router } from "@angular/router";
import { Inschrijving } from "../models/inschrijving";

@Component({
    selector: 'child-display',
    templateUrl: './child.component.html',
    styleUrls: ['./child.component.css']

})
export class ChildComponent implements OnInit {

    private model: Inschrijving = new Inschrijving();

    constructor(private adminService : AdminService, private route: ActivatedRoute, private router:Router ) {

    }
    
    ngOnInit() {
        let id = 0;
        this.route.params.subscribe(params => id = params.id);
        var requestInfo = this.adminService.getChild(id)
            .subscribe((response) => this.model = response);
    }

    goBackToAdmin() {
        this.router.navigateByUrl('/admin/1');
    }
    
}