import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { MemberService } from '@core/services/member.service';
import { Member } from '@shared/models/member/member';
import { Subject } from 'rxjs';
import { debounceTime, switchMap } from 'rxjs/operators';
import { RoleService } from '@core/services/role.service';
import { Role } from '@shared/models/role/role';
import { Team } from '@shared/models/projects/team';
import { NewMember } from '@shared/models/member/new-member';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { User } from '@shared/models/user/user';

@Component({
    selector: 'app-invite',
    templateUrl: './invite.component.html',
    styleUrls: ['./invite.component.sass']
})
export class InviteComponent extends BaseComponent implements OnInit {
    @Output() closeModal = new EventEmitter<void>();
    members: Member[];
    memberGroup: FormGroup;
    searchTerm: Subject<string> = new Subject<string>();
    roles: Role[];
    role: Role = {} as Role;
    teams: Team[];
    newMember = {} as NewMember;
    currentUser: User;
    ORGANIZATIONid = 2;
    disabled: boolean = true;



    invations: { member: NewMember, groupForm: FormGroup }[] = [{ member: {} as NewMember, groupForm: this.generateGroupForm() }];
    reInvitations: { member: NewMember, groupForm: FormGroup }[] = [{ member: {} as NewMember, groupForm: this.generateGroupForm() }];
    constructor(private memberService: MemberService, private roleService: RoleService, private authService: AuthenticationService) {
        super();
    }

    ngOnInit(): void {
        this.loadData();
        this.currentUser = this.authService.getUser();
        this.teams = [
            {
                id: 1,
                name: 'team1'
            },
            {
                id: 2,
                name: 'team2'
            }
        ];
    }
    enableButton(id: string) {
        let element = document.getElementById(id);
        if (element.hasAttribute('disabled')) {
            element.setAttribute('disabled', 'false')
        }
    }
    disableButton(id: string) {
        let element = document.getElementById(id);
        if (element.hasAttribute('disabled')) {
            element.setAttribute('disabled', 'true')
        }
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
                this.memberService.searchMembersNotInOrganization(this.ORGANIZATIONid, term)
                    .pipe(this.untilThis))
        ).subscribe(members => {
            this.members = members;
        });

        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe(roles => this.roles = roles);
    }

    search(event: any) {
        const value = event.query;
        this.searchTerm.next(value);
    }

    invate(formGroup: FormGroup) {
        this.newMember.email = formGroup.value.name.user.email
        this.newMember.roleId = formGroup.value.role;
        this.newMember.teamId = formGroup.value.team;
        this.newMember.organizationId = this.ORGANIZATIONid;
        this.newMember.createdBy = this.currentUser.id;
        this.memberService.addMemberToOrganization(this.newMember)
            .subscribe(invatedMember => {
                alert(JSON.stringify(invatedMember));
            });
    }

    addNew() {
        this.invations = this.invations.concat({ member: {} as NewMember, groupForm: this.generateGroupForm() });
    }
    func() {
        alert('blured!');
    }
}
