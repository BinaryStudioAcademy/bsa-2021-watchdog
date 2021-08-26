import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { ProjectService } from '@core/services/project.service';
import { SpinnerService } from '@core/services/spinner.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AlertCategory } from '@shared/models/alert-settings/alert-category';
import { AlertSettings } from '@shared/models/alert-settings/alert-settings';
import { Organization } from '@shared/models/organization/organization';
import { Platform } from '@shared/models/platforms/platform';
import { Project } from '@shared/models/projects/project';
import { UpdateProject } from '@shared/models/projects/update-project';
import { User } from '@shared/models/user/user';
import { PrimeIcons } from 'primeng/api';
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
    alertSetting = {} as AlertSettings;
    editForm: FormGroup = new FormGroup({});
    editFormAlert: FormGroup = new FormGroup({});
    project: Project;
    id: string;
    dropPlatform: Platform[];

    activeIndex: number = 0;

    constructor(
        private toastNotifications: ToastNotificationService,
        private authService: AuthenticationService,
        private projectService: ProjectService,
        public alertData: Data,
        private router: Router,
        private spinnerService: SpinnerService,
        private activatedRoute: ActivatedRoute,
        private confirmService: ConfirmWindowService
    ) {
        super();
    }

    ngOnInit() {
        this.id = this.activatedRoute.snapshot.params.id;
        this.activatedRoute.paramMap
            .pipe(this.untilThis)
            .subscribe(params => {
                this.id = params.get('id');
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
        this.activatedRoute.queryParamMap
            .pipe(this.untilThis)
            .subscribe(params => {
                const tab = params.get('tab');
                if (tab) {
                    this.activeIndex = Number(tab);
                }
            })
    }

    alertFormatting() {
        const specialAlert = { ...this.editFormAlert.value };
        this.alertSetting = {
            alertCategory: specialAlert.alertCategory,
            specialAlertSetting: specialAlert.alertCategory === AlertCategory.Special ? specialAlert : null
        };
    }

    updateProjectFunction() {
        this.alertFormatting();
        const project: UpdateProject = { ...this.editForm.value, alertSettings: this.alertSetting };
        if (this.editForm.valid) {
            this.spinnerService.show(true);
            this.projectService.updateProject(this.id, project)
                .pipe(this.untilThis)
                .subscribe((updatedProject) => {
                    this.project = updatedProject;
                    this.spinnerService.hide();
                    this.toastNotifications.success('Project has been updated!');
                }, error => {
                    this.toastNotifications.error(error);
                    this.spinnerService.hide();
                });
        } else {
            this.toastNotifications.error('Form is not valid', 'Error');
        }
    }

    deleteProjectModal() {
        this.confirmService.confirm({
            title: `Remove Project ${this.project.name}`,
            message: 'Are you sure, you want to delete this project?',
            icon: PrimeIcons.BAN,
            acceptButton: { label: 'Yes', class: 'p-button-outlined p-button-danger' },
            cancelButton: { label: 'No', class: 'p-button-outlined p-button-secondary' },
            accept: () => {
                this.deleteProject();
            }
        });
    }

    deleteProject() {
        this.spinnerService.show(true);
        this.projectService.removeProject(this.project.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.spinnerService.hide();
                this.router.navigate(['home', 'projects']).then(() => {
                    this.toastNotifications.success('Project has been deleted');
                });
            }, error => {
                this.toastNotifications.error(error);
                this.spinnerService.hide();
            });
    }
}
