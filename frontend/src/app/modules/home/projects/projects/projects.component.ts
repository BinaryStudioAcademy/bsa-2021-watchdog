import { Component, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { Data } from '@modules/home/projects/data';
import { BaseComponent } from '@core/components/base/base.component';
import { ProjectService } from '@core/services/project.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Organization } from '@shared/models/organization/organization';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-projects',
    templateUrl: './projects.component.html',
    styleUrls: ['./projects.component.sass'],
    providers: [Data]
})
export class ProjectsComponent extends BaseComponent implements OnInit {
    public projects: Project[];
    organization: Organization;
    public loadingNumber = 0;
    constructor(
        private projectService: ProjectService,
        private toastNotifications: ToastNotificationService,
        private authService: AuthenticationService
    ) {
        super();
    }

    ngOnInit(): void {
        this.initData();
    }

    initData() {
        this.loadingNumber += 1;
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;
                this.projectService
                    .getProjectsByOrganizationId(this.organization.id)
                    .pipe(this.untilThis)
                    .subscribe(projects => {
                        this.projects = projects;
                        this.loadingNumber -= 1;
                    }, error => {
                        this.toastNotifications.error(`${error}`);
                        this.loadingNumber -= 1;
                    });
            });
    }
}
