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

@Component({
    selector: 'app-create-project',
    templateUrl: './create-project.component.html',
    styleUrls: ['./create-project.component.sass'],
    providers: [Data, DialogService]
})
export class CreateProjectComponent extends BaseComponent implements OnInit {

    user: User;
    organization: Organization;
    loadingNumber: number = 0;
    newProject = {} as NewProject;
    platforms = {
        platformTabItems: [] as MenuItem[],
        activePlatformTabItem: {} as MenuItem,
        viewPlatformCards: [] as Platform[],
        platformCards: [] as Platform[]
    };
    teams: TeamOption[];
    alertSetting = {} as AlertSettings;
    formGroup = {} as FormGroup;
    createTeamDialog: DynamicDialogRef;
    
    constructor(
        private toastNotifications: ToastNotificationService,
        private platformService: PlatformService,
        private teamService: TeamService,
        private dialogService: DialogService,
        private authService: AuthenticationService,
        public alertData: Data
    ) {
        super();
    }

    ngOnInit() {
        this.user = this.authService.getUser();
        this.authService.getOrganization()
            .subscribe(organization => {
                this.organization = organization;
                this.loadTeams();     
            });
        this.initPlatforms(); 
        this.initAlertData();
        this.addValidation();  
    }

    private addValidation()
    {
        this.formGroup = new FormGroup({
            alertCategory: new FormControl(
                this.alertData.alertCategories[0].value,
                [
                    Validators.required
                ]
            ),
            projectName: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern('^[a-zA-Z0-9-_ ]+$')
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

    private initPlatforms() {
        this.loadPlatforms();
        this.platforms.platformTabItems = [
            { label: 'All', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Browser', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Server',  command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Mobile', command: (event) => this.onTabChange(event?.item.label) },
            { label: 'Desktop', command: (event) => this.onTabChange(event?.item.label) }
        ];
        this.platforms.activePlatformTabItem = Object.assign(this.platforms.platformTabItems[0]);
        
    }

    private loadPlatforms() {
        this.loadingNumber += 1;
        this.platformService
            .getPlatforms()
            .pipe(this.untilThis)
            .subscribe(platforms => {
                this.platforms.platformCards = platforms;
                this.onTabChange();
                this.loadingNumber -= 1;

            }, error => {
                this.toastNotifications.error(`${error}`);
                this.loadingNumber -= 1;
            });
    }

    private loadTeams() {
        this.loadingNumber += 1;
        this.teamService
            .getTeamOptionsByOrganizationId(this.organization.id)
            .pipe(this.untilThis)
            .subscribe(teamOptions => {
                this.teams = teamOptions;
                this.loadingNumber -= 1;

            }, error => {
                this.toastNotifications.error(`${error}`);
                this.loadingNumber -= 1;
            });
    }
    
    private initAlertData() {
        this.alertSetting.alertCategory = this.alertData.initAlertCategory;
        this.alertSetting.specialAlertSetting = {
            alertsCount: this.alertData.initAlertsCount,
            specialAlertType: this.alertData.initSpecialAlertType,
            alertTimeInterval: this.alertData.initAlertTimeInterval
        }
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
                    this.teamService
                        .createTeam({
                            createdBy: this.user.id,
                            organizationId: this.organization.id,
                            name
                        })
                        .pipe(this.untilThis)
                        .subscribe(response => {
                            this.toastNotifications.success(`Team #${name} created!`, '', 2000);
                            this.teams = this.teams.concat({name: name, id: response.body.id});
                            this.newProject.teamId = response.body.id;
                        }, error => {
                            this.toastNotifications.error(`${error}`, 'Error');
                        });
                }
            });
    }

    createProject(): void {
        // if (this.formGroup.valid && this.newProject.platformId) {
            // const project: Project = {
            //     id: 5,
            //     name: this.formGroup.controls.projectName.value,
            //     platform: this.platformCards.find(value => value.id === this.selectedPlatformId),
            //     alertSettings:
            //         {
            //             alertCategory: this.selectedAlertCategory,
            //             alertsCount: this.alertsCount,
            //             alertType: this.selectedAlertType,
            //             alertTimeInterval: this.selectedAlertTimeInterval
            //         }
            // };
            // console.log(project);
            // this.toastNotifications.success(`${project.name} created!`);
        // }
        alert(JSON.stringify(this.alertSetting));
    }
}
