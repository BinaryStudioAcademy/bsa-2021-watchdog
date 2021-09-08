import { Member } from '@shared/models/member/member';
import { Component, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { Data } from '@modules/home/projects/data';
import { BaseComponent } from '@core/components/base/base.component';
import { ProjectService } from '@core/services/project.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { SpinnerService } from '@core/services/spinner.service';
import { hasAccess } from '@core/utils/access.utils';
import { MembersRoleIds } from '@shared/constants/member-roles';

@Component({
    selector: 'app-projects',
    templateUrl: './projects.component.html',
    styleUrls: ['./projects.component.sass'],
    providers: [Data]
})
export class ProjectsComponent extends BaseComponent implements OnInit {
    public projects: Project[];
    member: Member;
    hasAccess = () => hasAccess(this.member);
    constructor(
        private projectService: ProjectService,
        private toastNotifications: ToastNotificationService,
        private authService: AuthenticationService,
        private spinnerService: SpinnerService
    ) {
        super();
    }

    ngOnInit(): void {
        this.initData();
    }

    initData() {
        this.spinnerService.show(true);
        this.authService.getMember()
            .pipe(this.untilThis)
            .subscribe(member => {
                this.member = member;
                this.projectService
                    .getProjectsByOrganizationId(this.member.organizationId)
                    .pipe(this.untilThis)
                    .subscribe(projects => {
                        this.projects = projects;
                        this.spinnerService.hide();
                    }, error => {
                        this.toastNotifications.error(error);
                        this.spinnerService.hide();
                    });
            });
    }
}
