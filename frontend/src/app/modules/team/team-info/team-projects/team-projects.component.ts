import { ToastNotificationService } from "@core/services/toast-notification.service";
import { BaseComponent } from "@core/components/base/base.component";
import { Component, Input, OnInit } from '@angular/core';
import { ProjectService } from '@core/services/project.service';
import { Project } from '@shared/models/projects/project';
import { Team } from '@shared/models/team/team';
import { ProjectTeam } from "@shared/models/projects/project-team";

@Component({
    selector: 'app-team-projects',
    templateUrl: './team-projects.component.html',
    styleUrls: ['../../team.style.sass']
})
export class TeamProjectsComponent extends BaseComponent implements OnInit {
    isLoading: boolean = false;
    @Input() team: Team;
    projectTeams: ProjectTeam[];
    constructor(private projectService: ProjectService, private toastService: ToastNotificationService) { super(); }

    ngOnInit() {
        this.isLoading = true;
        this.projectService.getProjectsByTeam(this.team.id)
            .pipe(this.untilThis)
            .subscribe(projects => {
                this.projectTeams = projects;
                this.isLoading = false;
            }, error => {
                this.toastService.error(error);
                this.isLoading = false;
            });
    }

    removeFromTeam(projectTeamId: number) {
        this.isLoading = true;
        this.projectService.removeProjectFromTeam(projectTeamId)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.projectTeams = this.projectTeams.filter(p => p.id != projectTeamId);
                this.isLoading = false;
            });
    }

    addProject(project: Project) {
        this.isLoading = true;
        this.projectService.addProjectToTeam(project.id, this.team.id)
            .pipe(this.untilThis)
            .subscribe(projectTeam => {
                this.projectTeams = this.projectTeams.concat(projectTeam);
                this.isLoading = false;
            });
    }
}
