import { BaseComponent } from '@core/components/base/base.component';
import { RoleService } from '@core/services/role.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl, FormGroupDirective } from "@angular/forms";
import { Organization } from '@shared/models/organization/organization';
import { Role } from '@shared/models/role/role';

@Component({
    selector: 'app-membership-settings',
    templateUrl: './membership-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class MembershipSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    @Input() parentForm: FormGroup;

    roles: Role[];

    constructor(
        private roleService: RoleService
    ) { super(); }

    ngOnInit() {
        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(r => {
                this.roles = r;
            });

        this.connectForm();
    }

    connectForm(): void {
        this.parentForm.addControl('openMembership', new FormControl(this.organization.openMembership, Validators.required));
        this.parentForm.addControl('defaultRoleId', new FormControl(this.organization.defaultRoleId, Validators.required));
    }

    get openMembership() { return this.parentForm.controls.openMembership; }

    get defaultRoleId() { return this.parentForm.controls.defaultRoleId; }
}
