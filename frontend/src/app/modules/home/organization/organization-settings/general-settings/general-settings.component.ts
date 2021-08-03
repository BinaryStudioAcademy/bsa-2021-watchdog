import { Organization } from "@core/models/organization";
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-general-settings',
    templateUrl: './general-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class GeneralSettingsComponent implements OnInit {
    organization: Organization;
    constructor() { }

    ngOnInit() {
    }

    save() {

    }
}
