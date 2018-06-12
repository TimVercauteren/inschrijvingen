import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'inschrijving',
    templateUrl: './inschrijving.component.html'
})
export class InschrijvingComponent {
    private inschrijvingForm!: FormGroup;


    constructor(private formBuilder: FormBuilder) {
        this.createForm();
    }

    createForm() {
        this.inschrijvingForm = this.formBuilder.group({
            // al de formcontrols
        })
    }
}
