import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { MemberService } from '@core/services/member.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Member } from '@shared/models/member/member';

@Component({
selector: 'app-members-page',
templateUrl: './members-page.component.html',
styleUrls: ['./members-page.component.sass']
})


export class MembersPageComponent extends BaseComponent implements OnInit {

    public loadingNumber = 0;
    public members : Member [] = [];


constructor(
    private memberService: MemberService,
    private toastNotifications : ToastNotificationService,
    ) {
    super();
}

ngOnInit(): void {
    this.loadingNumber += 1;
    this.memberService.getMembersByOrganizationId(1) //1 - organization id ?? from current user
        .pipe(this.untilThis)
        .subscribe(members => {
            this.members = members;
            this.loadingNumber -= 1;
        }, error => {
            this.toastNotifications.error(error.toString());
            this.loadingNumber -= 1;
        });
}

}
