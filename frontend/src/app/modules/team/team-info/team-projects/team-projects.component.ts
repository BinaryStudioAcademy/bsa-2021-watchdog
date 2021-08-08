import { ToastNotificationService } from "@core/services/toast-notification.service";
import { BaseComponent } from "@core/components/base/base.component";
import { Component, Input, OnInit } from '@angular/core';
import { ProjectService } from '@core/services/project.service';
import { Project } from '@shared/models/projects/project';
import { Team } from '@shared/models/team/team';

@Component({
    selector: 'app-team-projects',
    templateUrl: './team-projects.component.html',
    styleUrls: ['./team-projects.component.sass']
})
export class TeamProjectsComponent extends BaseComponent implements OnInit {
    isLoading: boolean = false;
    @Input() team: Team;
    projects: Project[];
    constructor(private projectService: ProjectService, private toastService: ToastNotificationService) { super(); }

    ngOnInit() {
        this.isLoading = true;
        this.projectService.getProjectsByTeam(this.team.id)
            .pipe(this.untilThis)
            .subscribe(projects => {
                this.projects = projects;
                this.isLoading = false;
            }, error => {
                this.toastService.error(error);
                this.isLoading = false;
            });
    }

    removeFromTeam(id: number) {

    }
}
