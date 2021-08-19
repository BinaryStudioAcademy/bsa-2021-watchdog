import { Component, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { Data } from '@modules/home/projects/data';
import { BaseComponent } from '@core/components/base/base.component';
import { ProjectService } from '@core/services/project.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Organization } from '@shared/models/organization/organization';
import { AuthenticationService } from '@core/services/authentication.service';
import { SpinnerService } from '@core/services/spinner.service';

@Component({
    selector: 'app-projects',
    templateUrl: './projects.component.html',
    styleUrls: ['./projects.component.sass'],
    providers: [Data]
})
export class ProjectsComponent extends BaseComponent implements OnInit {
    public projects: Project[];
    organization: Organization;
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
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;
                this.projectService
                    .getProjectsByOrganizationId(this.organization.id)
                    .pipe(this.untilThis)
                    .subscribe(projects => {
                        this.projects = projects;
                        this.spinnerService.hide();
                    }, error => {
                        this.toastNotifications.error(`${error}`);
                        this.spinnerService.hide();
                    });
            });
    }
}
