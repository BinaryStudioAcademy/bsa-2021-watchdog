import { SpinnerService } from "@core/services/spinner.service";
import { ToastNotificationService } from "@core/services/toast-notification.service";
import { OrganizationService } from "@core/services/organization.service";
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from "@angular/forms";
import { Organization } from "@core/models/organization";
import { Component, Input, OnInit } from '@angular/core';
import { map } from "rxjs/operators";
import { Observable } from "rxjs";

@Component({
    selector: 'app-general-settings',
    templateUrl: './general-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class GeneralSettingsComponent implements OnInit {
    @Input() organization: Organization;
    loading: boolean = false;
    errorUpdateMessage: string;
    generalForm: FormGroup = {} as FormGroup;

    constructor(
        private organizationService: OrganizationService,
        private fb: FormBuilder,
        private toastService: ToastNotificationService,
        private spinnerService: SpinnerService
    ) { }

    ngOnInit() {
        this.createForm();
    }

    createForm(): void {
        this.generalForm = this.fb.group({
            name: new FormControl(this.organization.name, [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(50),
                Validators.pattern(new RegExp('^[\\w\\s-!#$%&\'*+—/=?^`{|}~]+$')),
            ]),
            organizationSlug: [this.organization.organizationSlug, [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(50),
                Validators.pattern(new RegExp('^[\\w\\-]+$'))
            ]]
        });
    }

    save(propName: string): void {
        const control = this.generalForm.controls[propName];
        if (!control || !control.valid || this.organization[propName] === control.value) {
            return;
        }
        this.spinnerService.show(true);
        const organizationToUpdate = { ...this.organization };
        organizationToUpdate[propName] = control.value;
        this.organizationService.updateOrganization(organizationToUpdate)
            .subscribe(organization => {
                this.organization = organization;
                this.createForm();
                this.toastService.success("Changes were saved!");
            }, error => {
                this.toastService.error(error);
            }, () => {
                this.spinnerService.hide();
            });
    }

    saveSlug() {
        const result = this.validateSlug(this.organizationSlug);
        this.spinnerService.show(true);
        result.subscribe(t => {
            if (t === null) {
                this.save('organizationSlug');
                return;
            }
            this.organizationSlug.setErrors(t);
            this.spinnerService.hide();
        });
    }

    validateSlug = (control: AbstractControl): Observable<ValidationErrors | null> => {
        return this.organizationService.isSlugUnique(control.value).pipe(
            map(isUnique => (!isUnique ? { notUnique: true } : null))
        );
    }

    get name() { return this.generalForm.controls['name']; }

    get organizationSlug() { return this.generalForm.controls['organizationSlug']; }
}
