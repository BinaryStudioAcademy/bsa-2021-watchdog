import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { MemberService } from '@core/services/member.service';
import { Member } from '@shared/models/member/member';
import { OverlayPanel } from 'primeng/overlaypanel';
import { Subject } from 'rxjs';
import { debounceTime, switchMap } from 'rxjs/operators';
import { RoleService } from '@core/services/role.service';
import { Role } from '@shared/models/role/role';
import { Team } from '@shared/models/projects/team';
import { NewMember } from '@shared/models/member/new-member';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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

    invations: { member: NewMember, groupForm: FormGroup }[] = [{ member: {} as NewMember, groupForm: this.generateGroupForm() }];

    constructor(private memberService: MemberService, private roleService: RoleService) {
        super();
    }

    ngOnInit(): void {
        this.loadData();
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
                this.memberService.searchMembersNotInOrganization(2, term)
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
        alert(JSON.stringify(formGroup.value.name.user.email));
    }

    addNew() {
        this.invations = this.invations.concat({ member: {} as NewMember, groupForm: this.generateGroupForm() });
    }
    func() {
        alert('blured!');
    }
}
