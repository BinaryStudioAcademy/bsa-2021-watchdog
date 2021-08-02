import { Organization } from '@core/models/organization';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-organization-settings',
    templateUrl: './organization-settings.component.html',
    styleUrls: ['./organization-settings.style.sass']
})
export class OrganizationSettingsComponent implements OnInit {
    organization: Organization;
    constructor() { }

    ngOnInit() {
    }
}
