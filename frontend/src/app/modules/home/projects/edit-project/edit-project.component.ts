import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Data } from '@modules/home/projects/data';
import { PlatformService } from '@core/services/platform.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Platform } from '@shared/models/platforms/platform';
import { NewProject } from '@shared/models/projects/new-project';
import { UpdateProject } from '@shared/models/projects/update-project';
import { TeamService } from '@core/services/team.service';
import { TeamOption } from '@shared/models/teams/team-option';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
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

    updateProject = {} as UpdateProject;

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
        this.user = this.authService.getUser();
        this.authService.getOrganization()
            .subscribe(organization => {
                this.organization = organization;
            });

        this.projectService.getProjectById(18).pipe(this.untilThis)
            .subscribe(project => {
                this.project = project;
                this.validationsInit();
                this.initPlatforms();
            })
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
        // this.editForm.addControl('alertCategory', new FormControl(this.project.alertSettings, [
        //     Validators.required,
        // ]));
    }

    // private initAlertData() {
    //     this.alertSetting.alertCategory = this.alertData.initAlertCategory;
    //     this.alertSetting.specialAlertSetting = {
    //         alertsCount: this.alertData.initAlertsCount,
    //         specialAlertType: this.alertData.initSpecialAlertType,
    //         alertTimeInterval: this.alertData.initAlertTimeInterval
    //     };
    // }

    private initPlatforms() {
        this.loadPlatforms();
        this.platforms.platformTabItems = [
            { label: 'All', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Browser', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Server', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Mobile', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Desktop', command: (event) => this.onTabChange(event?.item.label) }
        ];
        this.platforms.activePlatformTabItem = Object.assign(this.platforms.platformTabItems[0]);
    }

    private loadPlatforms() {
        this.spinnerService.show(true);
        this.platformService
            .getPlatforms()
            .pipe(this.untilThis)
            .subscribe(platforms => {
                this.platforms.platformCards = platforms;
                this.onTabChange();
                this.spinnerService.hide();
            }, error => {
                this.toastNotifications.error(error);
                this.spinnerService.hide();
            });
    }

    private onTabChange(label: string = ''): void {
        this.updateProject.platformId = this.project.platform.id;
        if (this.platforms.platformCards) {
            switch (label) {
                case 'Browser': {
                    this.platforms.viewPlatformCards = this.platforms.platformCards.filter(value => value.platformTypes.isBrowser);
                    break;
                }
                case 'Server': {
                    this.platforms.viewPlatformCards = this.platforms.platformCards.filter(value => value.platformTypes.isServer);
                    break;
                }
                case 'Mobile': {
                    this.platforms.viewPlatformCards = this.platforms.platformCards.filter(value => value.platformTypes.isMobile);
                    break;
                }
                case 'Desktop': {
                    this.platforms.viewPlatformCards = this.platforms.platformCards.filter(value => value.platformTypes.isDesktop);
                    break;
                }
                default: {
                    this.platforms.viewPlatformCards = this.platforms.platformCards.concat();
                    break;
                }
            }
        }
    }

    updateProjectFunction(): void {
        const project = { name: this.project.name, description: this.project.description, platformId: this.updateProject.platformId};
        debugger;
        this.updateProject.name = "Blalalala";
        this.updateProject.description = "Lalalalala";
        this.updateProject.platformId = 2;
        if (this.editForm.valid && this.updateProject.platformId) {
            this.spinnerService.show(true);
            this.projectService.updateProject(18, this.updateProject)
                .subscribe(
                    project => {
                        debugger;
                        this.toastNotifications.success(`${project.name} has been updated!`);
                        this.router.navigate(['home', 'projects']);
                        this.spinnerService.hide();
                    },
                    error => {
                        debugger;
                        this.toastNotifications.error(error);
                        this.spinnerService.hide();
                    }
                );
        } else {
            this.toastNotifications.error('Form is not valid', 'Error');
        }
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
        this.updateProject.platformId = this.project.platform.id;

    }

    get projectName() { return this.editForm.controls.projectName; }

    get projectDescription() { return this.editForm.controls.projectDescription; }

}
