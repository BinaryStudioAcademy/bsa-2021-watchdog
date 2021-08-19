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
import { Invition } from '@shared/models/member/invition';

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

    invations: Invition[] = [{ member: {} as NewMember, groupForm: this.generateGroupForm() }];
    constructor(
        private memberService: MemberService,
        private roleService: RoleService,
        private authService: AuthenticationService,
        private toastNotifications: ToastNotificationService,
        private teamService: TeamService,
        private userService: UserService,
        private updateDataService: ShareDataService<Member>
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
                '',
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
                this.loadingNumber += 1;
                return this.userService.searchMembersNotInOrganization(this.organization.id, term)
                    .pipe(this.untilThis);
            })
        ).subscribe(users => {
            this.notMembers = users
                .filter(u => !this.invations.some(i => i.groupForm.value.name.id === u.id))
                .sort((a, b) => a.email.localeCompare(b.email))
                .slice(0, 5);
            this.loadingNumber -= 1;
        }, error => {
            this.toastNotifications.error(`${error}`, 'Error');
            this.loadingNumber -= 1;
        });

        this.loadingNumber += 1;
        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(roles => {
                this.roles = roles;
                this.loadingNumber -= 1;
            }, error => {
                this.toastNotifications.error(`${error}`, 'Error');
                this.loadingNumber -= 1;
            });

        this.loadingNumber += 1;
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;

                this.teamService.getTeamOptionsByOrganizationId(organization.id)
                    .pipe(this.untilThis)
                    .subscribe(teams => {
                        this.teams = teams;
                        this.loadingNumber -= 1;
                    });
            }, error => {
                this.toastNotifications.error(`${error}`, 'Error');
                this.loadingNumber -= 1;
            });
    }

    search(event: { query: string }) {
        const value = event.query;
        this.searchTerm.next(value);
    }

    invate(invitionInput: Invition) {
        const invition = invitionInput;
        this.loadingNumber += 1;
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
                this.loadingNumber -= 1;
            },
            error => {
                this.toastNotifications.error(`${error}`, 'Error');
                this.loadingNumber -= 1;
            });
    }

    addNew() {
        this.invations = this.invations.concat({ member: {} as NewMember, groupForm: this.generateGroupForm() });
    }
}
