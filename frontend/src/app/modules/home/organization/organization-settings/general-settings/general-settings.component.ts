import { catchError, map } from 'rxjs/operators';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { OrganizationService } from '@core/services/organization.service';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Organization } from '@shared/models/organization/organization';
import { Component, Input, OnInit, EventEmitter, Output } from "@angular/core";

import { Observable, of } from 'rxjs';
import { regexs } from '@shared/constants/regexs';
import { uniqueSlugValidator } from '@shared/validators/unique-slug.validator';

@Component({
    selector: 'app-general-settings',
    templateUrl: './general-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class GeneralSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    @Input() save: Observable<void>;
    @Input() reset: Observable<void>;
    @Output() canSave: EventEmitter<boolean> = new EventEmitter<boolean>();


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

        this.generalForm.statusChanges.subscribe(() => {
            this.checkSaveStatus();
        });
    }

    createForm(): void {
        this.generalForm = this.fb.group({
            name: new FormControl(this.organization.name, [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(50),
                Validators.pattern(regexs.organizationName),
            ]),
            organizationSlug: new FormControl(this.organization.organizationSlug, {
                validators: [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.organizationSlag),
                ],
                asyncValidators: [
                    uniqueSlugValidator(this.organization, this.organizationService)
                ]
            })
        });
    }

    checkSaveStatus() {
        if (this.generalForm.untouched || this.generalForm.pending || this.generalForm.invalid) {
            this.canSave.next(false);
        }
        if (this.generalForm.valid && (this.generalForm.touched || this.generalForm.dirty)) {
            const unsavedChangesProps = Object.keys(this.generalForm.controls)
                .filter(key =>
                    this.generalForm.controls[key].value !== this.organization[key]);

            if (unsavedChangesProps.length > 0) this.canSave.next(true);
            else this.canSave.next(false);
        }
    }

    get name() { return this.generalForm.controls.name; }

    get organizationSlug() { return this.generalForm.controls.organizationSlug; }

    private getPropNameFromControl(control: AbstractControl) {
        const { parent } = control;
        const propName = Object.keys(parent.controls).find(name => control === parent.controls[name]);
        return propName;
    }
}
