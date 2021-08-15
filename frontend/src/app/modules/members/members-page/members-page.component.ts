import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { MemberService } from '@core/services/member.service';
import { RoleService } from '@core/services/role.service';
import { ShareDataService } from '@core/services/share-data.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Member } from '@shared/models/member/member';
import { MemberItem } from '@shared/models/member/member-item';
import { Organization } from '@shared/models/organization/organization';
import { Role } from '@shared/models/role/role';
import { TeamOption } from '@shared/models/teams/team-option';
import { User } from '@shared/models/user/user';
import { TreeNode } from 'primeng/api';

@Component({
    selector: 'app-members-page',
    templateUrl: './members-page.component.html',
    styleUrls: ['./members-page.component.sass']
})

export class MembersPageComponent extends BaseComponent implements OnInit {
    loadingNumber = 0;
    memberItems: MemberItem[];
    isInviting: Boolean;
    user: User;
    roles: Role[];

    isEdit: boolean = false;

    constructor(
        private memberService: MemberService,
        private roleService: RoleService,
        private toastNotifications: ToastNotificationService,
        private authService: AuthenticationService,
        private confirmWindowService: ConfirmWindowService,
        private updateDataService: ShareDataService<Member>
    ) {
        super();
    }

    ngOnInit(): void {
        this.user = this.authService.getUser();
        this.setUpSharedDate();
        this.isInviting = false;
        this.loadingNumber += 1;
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.loadMembers(organization);
                this.loadingNumber -= 1;
            }, error => {
                this.toastNotifications.error(error.toString());
                this.loadingNumber -= 1;
            });

        this.loadingNumber += 1;
        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(roles => {
                this.roles = roles;
                this.loadingNumber -= 1;
            }, error => {
                this.toastNotifications.error(error.toString());
                this.loadingNumber -= 1;
            });
    }

    private loadMembers(organization: Organization) {
        this.loadingNumber += 1;
        this.memberService.getMembersByOrganizationId(organization.id)
            .pipe(this.untilThis)
            .subscribe(members => {
                this.memberItems = members.map(member => ({ member, treeTeams: this.fromTeams(member.teams) }));
                this.loadingNumber -= 1;
            }, error => {
                this.toastNotifications.error(error.toString());
                this.loadingNumber -= 1;
            });
    }

    private setUpSharedDate() {
        this.updateDataService.currentMessage
            .pipe(this.untilThis)
            .subscribe(member => {
                this.memberItems = this.memberItems.concat({ member, treeTeams: this.fromTeams(member.teams) });
            });
    }

    fromTeams(teams: TeamOption[]): TreeNode[] {
        return [{
            label: 'Teams',
            children: teams.map(team => ({
                label: team.name
            }))
        }];
    }

    startEdit(memberItemInput: MemberItem) {
        const memberItem = memberItemInput;
        memberItem.isEdit = true;
        memberItem.saveRole = memberItem.member.role;
    }

    finishEdit(memberItemInput: MemberItem) {
        const memberItem = memberItemInput;
        memberItem.isEdit = false;
        if (memberItem.saveRole) memberItem.member.role = memberItem.saveRole;
    }

    toggleEditor(memberItemInput: MemberItem) {
        const memberItem = memberItemInput;
        memberItem.isEdit = !memberItem.isEdit;
    }

    toggleAllEditors() {
        this.isEdit = !this.isEdit;
        if (this.isEdit === false) this.memberItems.forEach(m => this.finishEdit(m));
    }

    saveRoleChanges(memberItemInput: MemberItem) {
        const memberItem = memberItemInput;
        memberItem.isEdit = false;
        memberItem.saveRole = memberItem.member.role;
        this.memberService.updateMember(memberItem.member.id, memberItem.member.role.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.toastNotifications.success('Role updated');
            }, error => {
                this.toastNotifications.error(`${error}`);
            });
    }

    deleteMember(memberItem: MemberItem) {
        this.confirmWindowService.confirm({
            title: 'Delete member?',
            message: `Are you sure you wish to delete the <strong>${memberItem.member.user.firstName}`
                + ` ${memberItem.member.user.lastName} </strong>from the organization?`,
            acceptButton: { class: 'p-button-primary p-button-outlined' },
            cancelButton: { class: 'p-button-secondary p-button-outlined' },
            accept: () => {
                this.memberService.deleteMember(memberItem.member.id)
                    .pipe(this.untilThis)
                    .subscribe(() => {
                        this.toastNotifications.success('Member deleted');
                        this.memberItems = this.memberItems.filter(m => m.member.id !== memberItem.member.id);
                    }, error => {
                        this.toastNotifications.error(`${error}`);
                    });
            },
        });
    }
    reinvite(member: Member) {
        this.memberService.reinviteMember(member.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.toastNotifications.success('Member reinvited');
            }, error => {
                this.toastNotifications.error(`${error}`);
            });
    }
}
