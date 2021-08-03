import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Organization } from '@core/models/organization';

@Component({
    selector: 'app-membership-settings',
    templateUrl: './membership-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class MembershipSettingsComponent implements OnInit {
    @Input() organization: Organization;
    public formGroup: FormGroup = {} as FormGroup;
    constructor(private fb: FormBuilder) { }

    ngOnInit() {
        this.formGroup = this.fb.group({
            id: [this.organization.id],

        });
    }
}
