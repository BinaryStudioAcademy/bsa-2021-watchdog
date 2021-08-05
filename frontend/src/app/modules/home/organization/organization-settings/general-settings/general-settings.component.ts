import { catchError, map } from 'rxjs/operators';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { OrganizationService } from '@core/services/organization.service';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Organization } from '@shared/models/organization/organization';
import { Component, Input, OnInit } from '@angular/core';

import { Observable, of } from 'rxjs';

@Component({
    selector: 'app-general-settings',
    templateUrl: './general-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class GeneralSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    loading: boolean = false;
    errorUpdateMessage: string;
    generalForm: FormGroup = {} as FormGroup;

    constructor(
        private organizationService: OrganizationService,
        private fb: FormBuilder,
        private toastService: ToastNotificationService
    ) { super(); }

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
            organizationSlug: new FormControl(this.organization.organizationSlug, {
                validators: [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(new RegExp('^[\\w\\-]+$')),
                ]
            })
        });
    }

    pendingSlug() {
        const control = this.organizationSlug;
        control.setAsyncValidators(this.validateSlug);
        control.updateValueAndValidity({ onlySelf: true, emitEvent: true });
        control.setAsyncValidators([]);
    }

    pending(propName: string) {
        const control = this.generalForm.controls[propName];
        if (control.invalid) return;

        control.setAsyncValidators(this.saveValidator);
        control.updateValueAndValidity({ onlySelf: true, emitEvent: false });
        control.setAsyncValidators([]);
    }

    validateSlug = (control: AbstractControl): Observable<ValidationErrors | null> => {
        const propName = this.getPropNameFromControl(control);
        if (this.organization[propName] === control.value) {
            return of(null);
        }

        return this.organizationService.isSlugUnique(control.value).pipe(
            map(isUnique => {
                if (!isUnique) {
                    return { notUnique: true };
                }
                this.saveValidator(control).subscribe();
                return null;
            }), catchError(() => of({ serverError: true }))
        );
    };

    saveValidator = (control: AbstractControl): Observable<ValidationErrors | null> => {
        const propName = this.getPropNameFromControl(control);
        console.log('save');
        if (this.organization[propName] === control.value) {
            return of(null);
        }
        return this.organizationService.updateProperty(this.organization.id, propName, control.value)
            .pipe(map(organization => {
                this.organization[propName] = organization[propName];
                this.toastService.success('Changes were saved!');
                control.setValue(organization[propName]);
                return of(null);
            }), catchError(() => of({ serverError: true })));
    };

    get name() { return this.generalForm.controls.name; }

    get organizationSlug() { return this.generalForm.controls.organizationSlug; }

    private getPropNameFromControl(control: AbstractControl) {
        const { parent } = control;
        const propName = Object.keys(parent.controls).find(name => control === parent.controls[name]);
        return propName;
    }
}
