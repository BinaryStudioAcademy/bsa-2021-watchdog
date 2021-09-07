import { TrelloBoard } from "./../../../../../shared/models/trello/trello-board";
import { AuthenticationService } from '@core/services/authentication.service';
import { BaseComponent } from '@core/components/base/base.component';
import { RoleService } from '@core/services/role.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Organization } from '@shared/models/organization/organization';
import { Role } from '@shared/models/role/role';
import { MembersRoles } from '@shared/constants/membersRoles';
import { TrelloService } from '@core/services/trello-service';

@Component({
    selector: 'app-membership-settings',
    templateUrl: './membership-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class MembershipSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    @Input() parentForm: FormGroup;

    roles: Role[];
    boards: TrelloBoard[];

    constructor(
        private roleService: RoleService,
        private trelloService: TrelloService,
    ) { super(); }

    ngOnInit() {
        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(r => {
                this.roles = r.filter(rm => rm.name !== MembersRoles.owner);
            });

        this.connectForm();
    }

    connectForm(): void {
        this.parentForm.addControl('openMembership', new FormControl(this.organization.openMembership, Validators.required));
        this.parentForm.addControl('defaultRoleId', new FormControl(this.organization.defaultRoleId, Validators.required));
        this.parentForm.addControl('trelloIntegration', new FormControl(false, Validators.required));
        this.parentForm.addControl('trelloBoard', new FormControl({}, Validators.required));

        this.trelloIntegration.valueChanges.pipe(this.untilThis).subscribe(() => {
            if (this.trelloIntegration.value) {
                this.trelloService.getToken().pipe(this.untilThis).subscribe(r => {
                    this.trelloService.getBoards(r).pipe(this.untilThis).subscribe(t => {
                        this.boards = t;
                    });
                });
            } else {
                this.trelloIntegration.setValue(false);
                this.trelloBoard.setValue({});
                this.boards = [];
            }
        });
    }

    get openMembership() { return this.parentForm.controls.openMembership; }

    get defaultRoleId() { return this.parentForm.controls.defaultRoleId; }

    get trelloIntegration() { return this.parentForm.controls.trelloIntegration; }

    get trelloBoard() { return this.parentForm.controls.trelloBoard; }
}
