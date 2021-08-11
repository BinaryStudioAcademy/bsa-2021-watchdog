import { OrganizationService } from '@core/services/organization.service';
import { BaseComponent } from '@core/components/base/base.component';
import { RoleService } from '@core/services/role.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Organization } from '@shared/models/organization/organization';
import { Role } from '@shared/models/role/role';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-membership-settings',
    templateUrl: './membership-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class MembershipSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    @Input() save: Observable<void>;
    @Input() reset: Observable<void>;
    @Output() canSave: EventEmitter<boolean> = new EventEmitter<boolean>();

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

        this.membershipForm.statusChanges.subscribe(() => {
            this.checkSaveStatus();
        });
    }

    createForm(): void {
        this.membershipForm = this.fb.group({
            openMembership: [this.organization.openMembership, Validators.required],
            defaultRoleId: [this.organization.defaultRoleId, Validators.required]
        });
    }

    checkSaveStatus() {
        if (this.membershipForm.untouched || this.membershipForm.pending || this.membershipForm.invalid) {
            this.canSave.next(false);
        }
        if (this.membershipForm.valid && (this.membershipForm.touched || this.membershipForm.dirty)) {
            const unsavedChangesProps = Object.keys(this.membershipForm.controls)
                .filter(key =>
                    this.membershipForm.controls[key].value !== this.organization[key]);

            if (unsavedChangesProps.length > 0) this.canSave.next(true);
            else this.canSave.next(false);
        }
    }

    get openMembership() { return this.membershipForm.controls.openMembership; }

    get defaultRoleId() { return this.membershipForm.controls.defaultRoleId; }
}
