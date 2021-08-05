import { SpinnerService } from "@core/services/spinner.service";
import { OrganizationService } from "@core/services/organization.service";
import { BaseComponent } from "@core/components/base/base.component";
import { RoleService } from "@core/services/role.service";
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Organization } from '@core/models/organization';
import { Role } from '@core/models/role';
import { ToastNotificationService } from "@core/services/toast-notification.service";

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
        private toastService: ToastNotificationService,
        private spinnerService: SpinnerService
    ) { super(); }

    ngOnInit() {
        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(r => {
                this.roles = r;
            });
        this.createForm();
    }

    createForm(): void {
        this.membershipForm = this.fb.group({
            openMembership: [this.organization.openMembership, Validators.required],
            defaultRoleId: [this.organization.defaultRoleId, Validators.required]
        });
    }

    save(propName: string): void {
        const control = this.membershipForm.controls[propName];
        if (!control || !control.valid || this.organization[propName] === control.value) {
            return;
        }
        this.spinnerService.show(true);
        const organizationToUpdate = { ...this.organization };
        organizationToUpdate[propName] = control.value;
        this.organizationService.updateOrganization(organizationToUpdate)
            .subscribe((organization) => {
                this.organization = organization;
                this.createForm();
                this.spinnerService.hide();
                this.toastService.success("Changes were saved!");
            }, (error) => {
                this.toastService.error(error);
                control.setValue(this.organization[propName]);
                this.spinnerService.hide();
            });
    }
}
