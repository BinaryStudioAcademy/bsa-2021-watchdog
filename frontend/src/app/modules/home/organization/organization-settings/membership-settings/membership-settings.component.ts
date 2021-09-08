import { TrelloBoard } from '@shared/models/trello/trello-board';
import { BaseComponent } from '@core/components/base/base.component';
import { RoleService } from '@core/services/role.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Organization } from '@shared/models/organization/organization';
import { Role } from '@shared/models/role/role';
import { TrelloService } from '@core/services/trello-service';
import { User } from '@shared/models/user/user';
import { MembersRoles } from '@shared/constants/member-roles';

@Component({
    selector: 'app-membership-settings',
    templateUrl: './membership-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class MembershipSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    @Input() parentForm: FormGroup;
    @Input() user: User;
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
        if (this.organization.trelloIntegration) {
            this.trelloService.getBoardsByCurrentIntegration().pipe(this.untilThis).subscribe(t => {
                this.boards = t;
            });
        }
        this.connectForm();
    }

    connectForm(): void {
        this.parentForm.addControl('openMembership', new FormControl(this.organization.openMembership, Validators.required));
        this.parentForm.addControl('defaultRoleId', new FormControl(this.organization.defaultRoleId, Validators.required));
        this.parentForm.addControl('trelloIntegration', new FormControl(this.organization.trelloIntegration, Validators.required));
        this.parentForm.addControl('trelloBoard', new FormControl(this.organization.trelloBoard, Validators.required));
        this.parentForm.addControl('trelloToken', new FormControl(this.organization.trelloToken));

        this.trelloIntegration.valueChanges.pipe(this.untilThis).subscribe(() => {
            console.log(this.parentForm);
            if (this.trelloIntegration.value) {
                this.trelloService.authorizeTrello(() => this.trelloService.getBoardsByCurrentIntegration()
                    .pipe(this.untilThis)
                    .subscribe(boards => {
                        this.boards = boards;
                        this.trelloService.getToken()
                            .pipe(this.untilThis)
                            .subscribe(t => this.trelloToken.setValue(t));
                    }), () => this.trelloIntegration.setValue(false));
            } else {
                this.trelloService.clearToken();
                this.trelloBoard.setValue({});
                this.trelloToken.setValue('');
                this.boards = [];
            }
        });
    }

    get openMembership() { return this.parentForm.controls.openMembership; }

    get defaultRoleId() { return this.parentForm.controls.defaultRoleId; }

    get trelloIntegration() { return this.parentForm.controls.trelloIntegration; }

    get trelloBoard() { return this.parentForm.controls.trelloBoard; }

    get trelloToken() { return this.parentForm.controls.trelloToken; }
}
