import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from '@shared/models/projects/project';
import { FakeData } from '@modules/home/projects/fake-data';
import { BaseComponent } from '@core/components/base/base.component';
import { ProjectService } from '@core/services/project.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-projects',
    templateUrl: './projects.component.html',
    styleUrls: ['./projects.component.sass'],
    providers: [FakeData]
})
export class ProjectsComponent extends BaseComponent implements OnInit {
    public projects: Project[];
    public loadingNumber = 0;
    constructor(
        private projectService: ProjectService,
        private toastNotifications: ToastNotificationService) {
        super();
    }

    ngOnInit(): void {
        this.initData();
    }

    initData() {
        this.loadingNumber += 1;
        this.projectService
        .getProjectsByOrganizationId(1)
        .pipe(this.untilThis)
        .subscribe(projects => {
            this.projects = projects
            this.loadingNumber -= 1;

        }, error => {
            this.toastNotifications.error(`${error}`);
            this.loadingNumber -= 1;
        });
    }
}
