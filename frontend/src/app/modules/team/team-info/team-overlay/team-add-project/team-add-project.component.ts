import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { ProjectService } from '@core/services/project.service';
import { OverlayPanel } from 'primeng/overlaypanel';
import { Project } from '@shared/models/projects/project';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Team } from '@shared/models/teams/team';
import { Subject } from 'rxjs';
import { debounceTime, switchMap } from 'rxjs/operators';

@Component({
    selector: 'app-team-add-project',
    templateUrl: './team-add-project.component.html',
    styleUrls: ['../team-overlay.style.sass', '../../../team.style.sass']
})
export class TeamAddProjectComponent extends BaseComponent implements OnInit {
    @Input() team: Team;
    @Output() addedProject: EventEmitter<Project> = new EventEmitter<Project>();

    isLoading: boolean = false;
    projects: Project[];
    searchTerm: Subject<string> = new Subject<string>();

    constructor(
        private projectService: ProjectService,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.loadData();
    }

    loadData() {
        this.searchTerm.pipe(
            this.untilThis,
            debounceTime(300),
            switchMap((term: string) =>
                this.projectService.searchProjectsNotInTeam(this.team.id, term)
                    .pipe(this.untilThis))
        ).subscribe(projects => {
            this.projects = projects;
            this.isLoading = false;
        }, error => {
            this.toastService.error(error);
            this.isLoading = false;
        });
    }

    search(input: string) {
        this.isLoading = true;
        this.projects = [];
        this.searchTerm.next(input);
    }

    addProject(project: Project, panel: OverlayPanel) {
        this.addedProject.emit(project);
        panel.hide();
    }

    toggle(event: any, panel: OverlayPanel) {
        if (!panel.willHide) {
            panel.toggle(event);
            this.search('');
        }
    }
}
