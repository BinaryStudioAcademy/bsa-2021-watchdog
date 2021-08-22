import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { ProjectService } from '@core/services/project.service';
import { SpinnerService } from '@core/services/spinner.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AlertSettings } from '@shared/models/alert-settings/alert-settings';
import { Organization } from '@shared/models/organization/organization';
import { Platform } from '@shared/models/platforms/platform';
import { Project } from '@shared/models/projects/project';
import { UpdateProject } from '@shared/models/projects/update-project';
import { User } from '@shared/models/user/user';
import { MenuItem } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { switchMap } from 'rxjs/operators';
import { Data } from '../data';

@Component({
    selector: 'app-edit',
    templateUrl: './edit.component.html',
    styleUrls: ['./edit.component.sass'],
    providers: [Data, DialogService]
})
export class EditComponent extends BaseComponent implements OnInit {
    user: User;
    organization: Organization;
    platforms = {
        platformTabItems: [] as MenuItem[],
        activePlatformTabItem: {} as MenuItem,
        viewPlatformCards: [] as Platform[],
        platformCards: [] as Platform[]
    };
    alertSetting = {} as AlertSettings;
    editForm: FormGroup = new FormGroup({});
    project: Project;
    updateProject = {} as UpdateProject;
    id: string;
    activeTabIndex: number = 0;
    dropPlatform: Platform[];

    constructor(
        private toastNotifications: ToastNotificationService,
        private authService: AuthenticationService,
        private projectService: ProjectService,
        public alertData: Data,
        private router: Router,
        private spinnerService: SpinnerService,
        private activatedRoute: ActivatedRoute
    ) {
        super();
    }

    ngOnInit() {
        this.id = this.activatedRoute.snapshot.params.id;
        this.activatedRoute.paramMap.pipe(
            switchMap(params => params.getAll('id'))
        ).subscribe(data => {
            this.activeTabIndex = 0;
            this.id = data;
            this.user = this.authService.getUser();

            this.authService.getOrganization()
                .subscribe(organization => {
                    this.organization = organization;
                });

            this.projectService.getProjectById(this.id).pipe(this.untilThis)
                .subscribe(project => {
                    this.project = project;
                });
        });
    }

    updateProjectFunction(): void {
        const project: UpdateProject = { ...this.editForm.value };
        if (this.editForm.valid) {
            this.spinnerService.show(true);
            this.projectService.updateProject(this.id, project)
                .subscribe(
                    response => {
                        if (response) {
                            this.toastNotifications.success('Project has been updated!');
                            this.router.navigate(['home', 'projects']);
                            this.spinnerService.hide();
                        }
                    },
                    error => {
                        this.toastNotifications.error(error);
                        this.spinnerService.hide();
                    }
                );
        } else {
            this.toastNotifications.error('Form is not valid', 'Error');
        }
    }

    tests() {
        const project = { ...this.editForm.value };
        debugger;
    }

    reset() {
        this.editForm.reset(this.project);
    }

    deleteProject(id: string) {
        this.spinnerService.show(true);
        this.projectService.removeProject(id)
            .pipe(this.untilThis)
            .subscribe(response => {
                if (response) {
                    this.toastNotifications.success('Project has been deleted');
                    this.router.navigate(['home', 'projects']);
                    this.spinnerService.hide();
                }
            },
            error => {
                this.toastNotifications.error(error);
                this.spinnerService.hide();
            });
    }

    deleteProjects(id: string) {
        this.spinnerService.show(true);
        this.projectService.removeProject(id)
            .pipe(this.untilThis)
            .subscribe(response => {
                if (response) {
                    this.toastNotifications.success('Project has been deleted');
                    this.router.navigate(['home', 'projects']);
                    this.spinnerService.hide();
                }
            },
            error => {
                this.toastNotifications.error(error);
                this.spinnerService.hide();
            });
    }
}
