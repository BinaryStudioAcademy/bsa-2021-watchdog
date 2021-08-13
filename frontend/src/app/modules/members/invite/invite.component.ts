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

@Component({
    selector: 'app-invite',
    templateUrl: './invite.component.html',
    styleUrls: ['./invite.component.sass']
})
export class InviteComponent extends BaseComponent implements OnInit {
    @Output() closeModal = new EventEmitter<void>();
    notMembers: User[];
    memberGroup: FormGroup;
    searchTerm: Subject<string> = new Subject<string>();
    roles: Role[];
    role: Role = {} as Role;
    teams: TeamOption[];
    newMember = {} as NewMember;
    currentUser: User;

    organization: Organization;




    invations: { member: NewMember, groupForm: FormGroup }[] = [{ member: {} as NewMember, groupForm: this.generateGroupForm() }];
    constructor(
        private memberService: MemberService,
        private roleService: RoleService,
        private authService: AuthenticationService,
        private toastNotifications: ToastNotificationService,
        private teamService: TeamService,
        private userService: UserService) {
        super();
    }

    ngOnInit(): void {
        this.loadData();
        this.currentUser = this.authService.getUser();
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
                '',
                [
                    Validators.required,
                ]
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
            switchMap((term: string) =>
                this.userService.searchMembersNotInOrganization(this.organization.id, term)
                    .pipe(this.untilThis))
        ).subscribe(users => {
            this.notMembers = users;
        }, error => {
            this.toastNotifications.error(`${error}`, 'Error');
        });

        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(roles => {
                this.roles = roles;
            }, error => {
                this.toastNotifications.error(`${error}`, 'Error');
            });

        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;

                this.teamService.getTeamOptionsByOrganizationId(organization.id)
                    .pipe(this.untilThis)
                    .subscribe(teams => {
                        this.teams = teams;
                    })
            }, error => {
                this.toastNotifications.error(`${error}`, 'Error');
            });


    }

    search(event: { query: string }) {
        const value = event.query;
        this.searchTerm.next(value);
    }

    invate(formGroup: FormGroup) {
        this.newMember.email = formGroup.value.name.email
        this.newMember.roleId = formGroup.value.role;
        this.newMember.teamId = formGroup.value.team;
        this.newMember.organizationId = this.organization.id;
        this.newMember.createdBy = this.currentUser.id;
        this.memberService.addMemberToOrganization(this.newMember)
            .subscribe(x => this.toastNotifications.success("Member invited"),
                error => {
                    this.toastNotifications.error(`${error}`, 'Error');
                });
    }

    addNew() {
        this.invations = this.invations.concat({ member: {} as NewMember, groupForm: this.generateGroupForm() });
    }
}
