import { Component, OnInit, Input } from "@angular/core";
import { AdminService } from "../services/adminservices";

@Component({
    selector: 'child',
    templateUrl: './child.component.html'
})
export class ChildComponent implements OnInit {
    constructor(private adminService : AdminService ) {
        
    }

    @Input() id: number = 0;

    ngOnInit() {
        this.adminService.getChild(this.id)
    }
    
}