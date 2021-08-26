import { BaseComponent } from '@core/components/base/base.component';
import { OrganizationService } from '@core/services/organization.service';
import { FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { Organization } from '@shared/models/organization/organization';
import { Component, Input, OnInit } from '@angular/core';
import { regexs } from '@shared/constants/regexs';
import { uniqueSlugValidator } from '@shared/validators/unique-slug.validator';
import { of } from 'rxjs';

@Component({
    selector: 'app-general-settings',
    templateUrl: './general-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class GeneralSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    @Input() parentForm: FormGroup;

    loading: boolean = false;
    errorUpdateMessage: string;

    constructor(
        private organizationService: OrganizationService,
    ) { super(); }

    ngOnInit() {
        this.connectForm();
    }

    connectForm(): void {
        this.parentForm.addControl('name', new FormControl(this.organization.name, [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50),
            Validators.pattern(regexs.organizationName),
        ]));
        this.parentForm.addControl('organizationSlug', new FormControl(this.organization.organizationSlug, {
            validators: [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(50),
                Validators.pattern(regexs.organizationSlag),
            ],
            asyncValidators: [
                this.slagValidator,
            ]
        }));
    }

    slagValidator = (ctrl: AbstractControl) => {
        if (this.organization.organizationSlug === ctrl.value) {
            return of(null);
        }
        return uniqueSlugValidator(this.organizationService)(ctrl);
    };

    get name() { return this.parentForm.controls.name; }

    get organizationSlug() { return this.parentForm.controls.organizationSlug; }
}
