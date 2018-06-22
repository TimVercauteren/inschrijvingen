import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { InschrijvingComponent } from './components/inschrijving/inschrijving.component';
import { AdminComponent } from './components/admin/admin.component';
import { AdminService } from './components/services/adminservices';
import { ChildComponent } from './components/child/child.component';
import { DoneComponent } from './components/done/done.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        InschrijvingComponent,
        AdminComponent,
        ChildComponent,
        DoneComponent
    ],
    providers: [
        AdminService
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: InschrijvingComponent },
            { path: 'done', component: DoneComponent },
            { path: 'admin/:loggedIn', component: AdminComponent },
            { path: 'child/:id', component: ChildComponent },
            { path: '**', redirectTo: 'home' },
        ])
    ]
})
export class AppModuleShared {
}
