import { hasAccess } from '@core/utils/access.utils';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Component, Input, OnInit } from '@angular/core';
import { ProjectService } from '@core/services/project.service';
import { Project } from '@shared/models/projects/project';
import { Team } from '@shared/models/teams/team';
import { ProjectTeam } from '@shared/models/projects/project-team';
import { SpinnerService } from '@core/services/spinner.service';
import { Member } from '@shared/models/member/member';

@Component({
    selector: 'app-team-projects',
    templateUrl: './team-projects.component.html',
    styleUrls: ['../../team.style.sass']
})
export class TeamProjectsComponent extends BaseComponent implements OnInit {
    @Input() team: Team;
    @Input() member: Member;
    projectTeams: ProjectTeam[];
    constructor(
        private projectService: ProjectService,
        private toastService: ToastNotificationService,
        private spinnerService: SpinnerService
    ) {
        super();
    }

    hasAccess = () => hasAccess(this.member) && this.team.members.find(x => x.id === this.member.id);

    ngOnInit() {
        this.spinnerService.show(true);
        this.projectService.getProjectsByTeam(this.team.id)
            .pipe(this.untilThis)
            .subscribe(projects => {
                this.projectTeams = projects;
                this.projectTeams.sort(this.sortProjectTeams);
                this.spinnerService.hide();
            }, error => {
                this.toastService.error(error);
                this.spinnerService.hide();
            });
    }

    removeFromTeam(projectTeamId: number) {
        this.spinnerService.show(true);
        this.projectService.removeProjectFromTeam(projectTeamId)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.projectTeams = this.projectTeams.filter(p => p.id !== projectTeamId);
                this.projectTeams.sort(this.sortProjectTeams);
                this.spinnerService.hide();
                this.toastService.success('Project was removed!');
            }, error => {
                this.spinnerService.hide();
                this.toastService.error(error);
            });
    }

    addProject(project: Project) {
        this.spinnerService.show(true);
        this.projectService.addProjectToTeam(project.id, this.team.id)
            .pipe(this.untilThis)
            .subscribe(projectTeam => {
                this.projectTeams = this.projectTeams.concat(projectTeam);
                this.projectTeams.sort(this.sortProjectTeams);
                this.spinnerService.hide();
                this.toastService.success('Project was added!');
            }, error => {
                this.spinnerService.hide();
                this.toastService.error(error);
            });
    }

    toggleStar(projectTeamId: number) {
        if (this.hasAccess()) {
            const projectTeam = this.projectTeams.find(project => project.id === projectTeamId);
            projectTeam.isFavorite = !projectTeam.isFavorite;
            this.projectService.setProjectForTeamAsFavorite(projectTeamId, projectTeam.isFavorite)
                .pipe(this.untilThis)
                .subscribe(() => { },
                    error => {
                        projectTeam.isFavorite = !projectTeam.isFavorite;
                        this.toastService.error(error);
                    });
        }
    }

    sortProjectTeams: (pt1: ProjectTeam, pt2: ProjectTeam) => number = (pt1, pt2) => {
        if (pt1.isFavorite === pt2.isFavorite) return 0;
        if (pt1.isFavorite) return -1;
        return 1;
    };
}
