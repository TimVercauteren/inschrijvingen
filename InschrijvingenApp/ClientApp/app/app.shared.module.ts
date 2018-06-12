import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { InschrijvingComponent } from './components/home/inschrijving.component';
import { AdminComponent } from './components/admin/admin.component';
import { AdminService } from './components/services/adminservices';
import { ChildComponent } from './components/child/child.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        InschrijvingComponent,
        AdminComponent,
        ChildComponent
    ],
    providers: [
        AdminService
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: InschrijvingComponent },
            { path: 'admin', component: AdminComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
