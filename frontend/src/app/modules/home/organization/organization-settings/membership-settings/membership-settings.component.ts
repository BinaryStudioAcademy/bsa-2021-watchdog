import { OrganizationService } from '@core/services/organization.service';
import { BaseComponent } from '@core/components/base/base.component';
import { RoleService } from '@core/services/role.service';
import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Organization } from '@shared/models/organization/organization';
import { Role } from '@shared/models/role/role';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Component({
    selector: 'app-membership-settings',
    templateUrl: './membership-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class MembershipSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    roles: Role[];
    loading = false;
    membershipForm: FormGroup = {} as FormGroup;

    constructor(
        private fb: FormBuilder,
        private roleService: RoleService,
        private organizationService: OrganizationService,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(r => {
                this.roles = r;
            });
        this.createForm();
    }

    pending(propName: string) {
        const control = this.membershipForm.controls[propName];
        if (control.invalid) return;

        control.setAsyncValidators(this.saveValidator.bind(this));
        control.updateValueAndValidity({ onlySelf: true, emitEvent: false });
        control.setAsyncValidators([]);
    }

    saveValidator = (control: AbstractControl): Observable<ValidationErrors | null> => {
        const { parent } = control;
        const propName = Object.keys(parent.controls).find(name => control === parent.controls[name]);
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

    createForm(): void {
        this.membershipForm = this.fb.group({
            openMembership: [this.organization.openMembership, Validators.required],
            defaultRoleId: [this.organization.defaultRoleId, Validators.required]
        });
    }

    get openMembership() { return this.membershipForm.controls.openMembership; }

    get defaultRoleId() { return this.membershipForm.controls.defaultRoleId; }
}
