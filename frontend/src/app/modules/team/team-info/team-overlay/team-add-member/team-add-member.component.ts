import { Team } from "@shared/models/team/team";
import { BaseComponent } from "@core/components/base/base.component";
import { MemberService } from "@core/services/member.service";
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Member } from '@shared/models/member/member';
import { OverlayPanel } from "primeng/overlaypanel";
import { debounceTime, distinctUntilChanged, switchMap } from "rxjs/operators";
import { Subject } from "rxjs";

@Component({
    selector: 'app-team-add-member',
    templateUrl: './team-add-member.component.html',
    styleUrls: ['../team-overlay.style.sass', '../../../team.style.sass']
})
export class TeamAddMemberComponent extends BaseComponent implements OnInit {
    @Input() team: Team;
    @Output() addedMember: EventEmitter<Member> = new EventEmitter<Member>();

    members: Member[];
    searchTerm: Subject<string> = new Subject<string>();
    constructor(public memberService: MemberService) { super(); }

    ngOnInit() {
        this.loadData();
    }

    loadData() {
        this.searchTerm.pipe(
            this.untilThis,
            debounceTime(100),
            switchMap((term: string) =>
                this.memberService.searchMembersNotInTeam(this.team.id, term)
                    .pipe(this.untilThis)
            )).subscribe(members => {
                this.members = members;
            });
    }

    search(input: string) {
        this.members = [];
        this.searchTerm.next(input);
    }

    addMember(member: Member, panel: OverlayPanel) {
        this.addedMember.emit(member);
        panel.hide();
    }

    toggle(event: any, panel: OverlayPanel) {
        if (!panel.willHide) {
            panel.toggle(event);
            this.search('');
        }
    }
}
