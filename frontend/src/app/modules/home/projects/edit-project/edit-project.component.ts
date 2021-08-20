import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Data } from '@modules/home/projects/data';
import { PlatformService } from '@core/services/platform.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Platform } from '@shared/models/platforms/platform';
import { NewProject } from '@shared/models/projects/new-project';
import { TeamService } from '@core/services/team.service';
import { TeamOption } from '@shared/models/teams/team-option';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CreateTeamComponent } from '@modules/team/create-team/create-team.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { User } from '@shared/models/user/user';
import { Organization } from '@shared/models/organization/organization';
import { AlertSettings } from '@shared/models/alert-settings/alert-settings';
import { regexs } from '@shared/constants/regexs';
import { ProjectService } from '@core/services/project.service';
import { Router } from '@angular/router';
import { SpinnerService } from '@core/services/spinner.service';
import { Project } from '@shared/models/projects/project';
import { throwIfEmpty } from 'rxjs/operators';

@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
  styleUrls: ['./edit-project.component.sass'],
  providers: [Data, DialogService]
})
export class EditProjectComponent extends BaseComponent implements OnInit {
    user: User;
    organization: Organization;
    newProject = {} as NewProject;
    platforms = {
        platformTabItems: [] as MenuItem[],
        activePlatformTabItem: {} as MenuItem,
        viewPlatformCards: [] as Platform[],
        platformCards: [] as Platform[]
    };
    teams: TeamOption[];
    alertSetting = {} as AlertSettings;

    editForm: FormGroup = new FormGroup({});

    createTeamDialog: DynamicDialogRef;

    project: Project;

    constructor(
        private toastNotifications: ToastNotificationService,
        private platformService: PlatformService,
        private teamService: TeamService,
        private dialogService: DialogService,
        private authService: AuthenticationService,
        private projectService: ProjectService,
        public alertData: Data,
        private router: Router,
        private spinnerService: SpinnerService
    ) {
        super();
    }

    ngOnInit() {
        //this.project.name = "Android";
        //this.project.description = "Super";
        this.user = this.authService.getUser();
        this.authService.getOrganization()
            .subscribe(organization => {
                this.organization = organization;
            });

        this.projectService.getProjectById(18).pipe(this.untilThis)
            .subscribe(project => {
                this.project = project;
                this.validationsInit();
            })
        //this.initAlertData();
        //this.addValidation();

    }

    validationsInit() {
        this.editForm.addControl('projectName', new FormControl(this.project.name, [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50),
            Validators.pattern(regexs.projectName),
        ]));
        this.editForm.addControl('projectDescription', new FormControl(this.project.description, [
            Validators.maxLength(1000),
            Validators.pattern(regexs.projectDescription),
        ]));
    }



    private initAlertData() {
        this.alertSetting.alertCategory = this.alertData.initAlertCategory;
        this.alertSetting.specialAlertSetting = {
            alertsCount: this.alertData.initAlertsCount,
            specialAlertType: this.alertData.initSpecialAlertType,
            alertTimeInterval: this.alertData.initAlertTimeInterval
        };
    }

    openDialog() {
        this.createTeamDialog = this.dialogService.open(CreateTeamComponent, {
            header: 'Creating team',
            width: '35%',
            showHeader: true,
            baseZIndex: 10000
        });

        this.createTeamDialog.onClose
            .pipe(this.untilThis)
            .subscribe((name: string) => {
                if (name) {
                    this.spinnerService.show(true);
                    this.teamService
                        .createTeam({
                            createdBy: this.user.id,
                            organizationId: this.organization.id,
                            name
                        })
                        .pipe(this.untilThis)
                        .subscribe(team => {
                            this.toastNotifications.success(`Team #${name} created!`);
                            this.teams = this.teams.concat({ name, id: team.id });
                            this.newProject.teamId = team.id;
                            this.spinnerService.hide();
                        }, error => {
                            this.toastNotifications.error(error);
                            this.spinnerService.hide();
                        });
                }
            });
    }

    createProject(): void {
        if (this.editForm.valid && this.newProject.platformId) {
            this.newProject.organizationId = this.organization.id;
            this.newProject.createdBy = this.user.id;
            this.newProject.alertSettings = {
                alertCategory: this.alertSetting.alertCategory,
                specialAlertSetting: this.alertSetting.alertCategory === 3 ? this.alertSetting.specialAlertSetting : null
            };
            this.spinnerService.show(true);
            this.projectService.createProject(this.newProject)
                .subscribe(
                    project => {
                        this.toastNotifications.success(`${project.name} created!`);
                        this.router.navigate(['home', 'projects']);
                        this.spinnerService.hide();
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

    reset() {
        this.editForm.reset();
    }

    get projectName() { return this.editForm.controls.projectName; }

    get projectDescription() { return this.editForm.controls.projectDescription; }

}
