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
                this.projectTeams.sort((p1, p2) => p1.isFavorite === p2.isFavorite ? 0 : p1.isFavorite ? -1 : 1);
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
                this.projectTeams.sort((p1, p2) => p1.isFavorite === p2.isFavorite ? 0 : p1.isFavorite ? -1 : 1);
                this.isLoading = false;
                this.toastService.success("Project was removed!");
            }, error => {
                this.isLoading = false;
                this.toastService.error(error);
            });
    }

    addProject(project: Project) {
        this.isLoading = true;
        this.projectService.addProjectToTeam(project.id, this.team.id)
            .pipe(this.untilThis)
            .subscribe(projectTeam => {
                this.projectTeams = this.projectTeams.concat(projectTeam);
                this.projectTeams.sort((p1, p2) => p1.isFavorite === p2.isFavorite ? 0 : p1.isFavorite ? -1 : 1);
                this.isLoading = false;
                this.toastService.success("Project was added!");
            }, error => {
                this.isLoading = false;
                this.toastService.error(error);
            });
    }

    toggleStar(projectTeam: ProjectTeam) {
        this.isLoading = true;
        this.projectService.setProjectForTeamAsFavorite(projectTeam.id, !projectTeam.isFavorite)
            .pipe(this.untilThis)
            .subscribe(state => {
                projectTeam.isFavorite = state;
                this.isLoading = false;
            }, error => {
                this.isLoading = false;
                this.toastService.error(error);
            });
    }
}
