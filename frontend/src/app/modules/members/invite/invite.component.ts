import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { MemberService } from '@core/services/member.service';
import { Member } from '@shared/models/member/member';
import { Subject } from 'rxjs';
import { debounceTime, switchMap } from 'rxjs/operators';
import { RoleService } from '@core/services/role.service';
import { Role } from '@shared/models/role/role';
import { TeamOption } from '@shared/models/teams/team-option';
import { NewMember } from '@shared/models/member/new-member';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { User } from '@shared/models/user/user';
import { Organization } from '@shared/models/organization/organization';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TeamService } from '@core/services/team.service';
import { UserService } from '@core/services/user.service';
import { ShareDataService } from '@core/services/share-data.service';
import { MembersRoles } from '@shared/constants/member-roles';
import { Invition } from '@shared/models/member/invition';
import { SpinnerService } from '@core/services/spinner.service';

@Component({
    selector: 'app-invite',
    templateUrl: './invite.component.html',
    styleUrls: ['./invite.component.sass']
})
export class InviteComponent extends BaseComponent implements OnInit {
    @Output() closeModal = new EventEmitter<void>();
    notMembers: User[];
    searchTerm: Subject<string> = new Subject<string>();
    roles: Role[];
    teams: TeamOption[];
    loadingNumber: number = 0;
    user: User;
    organization: Organization;
    defaultRole: Role;

    invitingMembersCount = 5;

    invations: Invition[];
    constructor(
        private memberService: MemberService,
        private roleService: RoleService,
        private authService: AuthenticationService,
        private toastNotifications: ToastNotificationService,
        private teamService: TeamService,
        private userService: UserService,
        private updateDataService: ShareDataService<Member>,
        private spinnerService: SpinnerService
    ) {
        super();
    }

    ngOnInit(): void {
        this.loadData();
        this.user = this.authService.getUser();
    }

    generateGroupForm() {
        return new FormGroup({
            name: new FormControl(
                '',
                [
                    Validators.required,
                ]
            ),
            team: new FormControl(
                []
            ),
            role: new FormControl(
                this.organization?.defaultRoleId,
                [
                    Validators.required,
                ]
            )
        });
    }

    loadData() {
        this.searchTerm.pipe(
            this.untilThis,
            debounceTime(300),
            switchMap((term: string) => {
                this.spinnerService.show();
                return this.userService
                    .searchMembersNotInOrganization(this.organization.id, this.invitingMembersCount + this.invations.length, term)
                    .pipe(this.untilThis);
            })
        ).subscribe(users => {
            this.notMembers = users
                .filter(u => !this.invations.some(i => i.groupForm.value.name?.id === u.id))
                .sort((a, b) => a.email.localeCompare(b.email))
                .slice(0, this.invitingMembersCount);
            this.spinnerService.hide();
        }, error => {
            this.toastNotifications.error(error);
            this.spinnerService.hide();
        });

        this.spinnerService.show();
        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(roles => {
                this.roles = roles.filter(r => r.name !== MembersRoles.owner);
                this.spinnerService.hide();
            }, error => {
                this.toastNotifications.error(error);
                this.spinnerService.hide();
            });

        this.spinnerService.show();
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;
                this.invations = [{ member: {} as NewMember, groupForm: this.generateGroupForm() }];
                this.teamService.getTeamOptionsByOrganizationId(organization.id)
                    .pipe(this.untilThis)
                    .subscribe(teams => {
                        this.teams = teams;
                        this.spinnerService.hide();
                    });
            }, error => {
                this.toastNotifications.error(error);
                this.spinnerService.hide();
            });
    }

    search(event: { query: string }) {
        const value = event.query;
        this.searchTerm.next(value);
    }

    invite(invitionInput: Invition) {
        const invition = invitionInput;
        this.spinnerService.show();
        const newMember = {
            userId: invition.groupForm.value.name.id,
            roleId: invition.groupForm.value.role,
            teamIds: invition.groupForm.value.team,
            organizationId: this.organization.id,
            createdBy: this.user.id
        };
        this.memberService.addMemberToOrganization(newMember)
            .subscribe((invatedMember) => {
                this.toastNotifications.success('Member invited');
                invition.isInvited = true;
                this.updateDataService.changeMessage(invatedMember.member);
                this.spinnerService.hide();
            },
            error => {
                this.toastNotifications.error(error);
                this.spinnerService.hide();
            });
    }

    addNew() {
        this.invations = this.invations.concat({ member: {} as NewMember, groupForm: this.generateGroupForm() });
    }
}
