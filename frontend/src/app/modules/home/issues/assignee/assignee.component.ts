import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { MemberService } from '@core/services/member.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Member } from '@shared/models/member/member';
import { Organization } from '@shared/models/organization/organization';
import { switchMap, tap } from 'rxjs/operators';

@Component({
    selector: 'app-assignee',
    templateUrl: './assignee.component.html',
    styleUrls: ['./assignee.component.sass']
})
export class AssigneeComponent extends BaseComponent implements OnInit {


    @Output() closeModal = new EventEmitter<void>();
    constructor(private memberService: MemberService,
        private authService: AuthenticationService,
        private toastNotification: ToastNotificationService) {
        super();
    }
    members = {} as Member[];
    organization: Organization;
    avatar: string;
    ngOnInit(): void {
        this.avatar = "'user.avatarUrl' ?? 'assets\\avatar.png'";
        this.authService.getOrganization()
            .pipe(
                this.untilThis,
                tap(organization => this.organization = organization),
                switchMap(() => this.loadMember())
            )
            .subscribe(response => {
                this.members = response;
            }, errorResponse => {
                this.toastNotification.error(errorResponse);
            });
    }

    loadMember() {
        return this.memberService.getMembersByOrganizationId(this.organization.id)
            .pipe(this.untilThis)

    }

    // generateGroupForm() {
    //   return new FormGroup({
    //     assignee: new FormControl(
    //       '',
    //       [
    //         Validators.required,
    //       ]
    //     )
    //   });
    // }
}


