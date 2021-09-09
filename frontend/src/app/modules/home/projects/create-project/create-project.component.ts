import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Data } from '@modules/home/projects/data';
import { PlatformService } from '@core/services/platform.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Platform } from '@shared/models/platforms/platform';
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
import { uniqueProjectNameValidator } from '@shared/validators/unique-project-name.validator';
import { SpinnerService } from '@core/services/spinner.service';
import { AlertCategory } from '@shared/models/alert-settings/alert-category';
import { NewProject } from '@shared/models/projects/new-project';

@Component({
    selector: 'app-create-project',
    templateUrl: './create-project.component.html',
    styleUrls: ['./create-project.component.sass'],
    providers: [Data, DialogService]
})
export class CreateProjectComponent extends BaseComponent implements OnInit {
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
    formGroup: FormGroup;
    createTeamDialog: DynamicDialogRef;

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
                this.loadTeams();
                this.addValidation();
                this.initPlatforms();
                this.initAlertData();
            });
    }

    private addValidation() {
        this.formGroup = new FormGroup({
            alertCategory: new FormControl(
                this.alertData.alertCategories[0].value,
                [
                    Validators.required
                ]
            ),
            projectName: new FormControl(
                '',
                {
                    validators: [
                        Validators.required,
                        Validators.minLength(3),
                        Validators.maxLength(50),
                        Validators.pattern(regexs.projectName)
                    ],
                    asyncValidators: [
                        uniqueProjectNameValidator(this.projectService, this.organization.id)
                    ]
                }
            ),
            projectDescription: new FormControl(
                '',
                [
                    Validators.maxLength(1000),
                    Validators.pattern(regexs.projectDescription)
                ]
            ),
            team: new FormControl(
                '',
                [
                    Validators.required
                ],
            ),
        });
    }
    get alertCategory() { return this.formGroup.controls.alertCategory; }
    get projectName() { return this.formGroup.controls.projectName; }
    get projectDescription() { return this.formGroup.controls.projectDescription; }
    get team() { return this.formGroup.controls.team; }

    private initPlatforms() {
        this.loadPlatforms();
        this.platforms.platformTabItems = [
            { label: 'All', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Browser', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Server', command: (event) => this.onTabChange(event?.item.label) },
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

    private loadTeams() {
        this.spinnerService.show(true);
        this.teamService
            .getTeamOptionsByOrganizationId(this.organization.id)
            .pipe(this.untilThis)
            .subscribe(teamOptions => {
                this.teams = teamOptions;
                this.spinnerService.hide();
            }, error => {
                this.toastNotifications.error(error);
                this.spinnerService.hide();
            });
    }

    private initAlertData() {
        this.alertSetting.alertCategory = this.alertData.initAlertCategory;
        this.alertSetting.specialAlertSetting = {
            alertsCount: this.alertData.initAlertsCount,
            specialAlertType: this.alertData.initSpecialAlertType,
            alertTimeInterval: this.alertData.initAlertTimeInterval
        };
    }

    private onTabChange(label: string = ''): void {
        this.newProject.platformId = undefined;
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

    isSpecialCategory = (category: number) => category === AlertCategory.Special;

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
                            this.formGroup.controls.team.setValue(team.id);
                            this.spinnerService.hide();
                        }, error => {
                            this.toastNotifications.error(error);
                            this.spinnerService.hide();
                        });
                }
            });
    }

    createProject(): void {
        if (this.formGroup.valid && this.newProject.platformId) {
            this.newProject.description = this.projectDescription.value;
            this.newProject.name = this.projectName.value;
            this.newProject.organizationId = this.organization.id;
            this.newProject.createdBy = this.user.id;
            this.newProject.teamId = this.team.value;
            this.newProject.alertSettings = {
                alertCategory: this.alertSetting.alertCategory,
                specialAlertSetting: this.alertSetting.alertCategory === AlertCategory.Special
                    ? this.alertSetting.specialAlertSetting
                    : null
            };
            this.spinnerService.show(true);
            this.projectService.createProject(this.newProject)
                .subscribe(
                    project => {
                        this.toastNotifications.success(`${project.name} created!`);
                        this.router.navigate(['home', 'projects', 'edit', `${project.id}`], { queryParams: { tab: 'configure' } });
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
}
