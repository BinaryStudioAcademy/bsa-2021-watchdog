import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { FakeData } from '@modules/home/projects/fake-data';
import { PlatformService } from '@core/services/platform.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Platform } from '@shared/models/platforms/platform';
import { NewProject } from '@shared/models/projects/new-project';
import { TeamService } from '@core/services/team.service';
import { TeamOption } from '@shared/models/teams/team-option';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CreateTeamComponent } from '@modules/team/create-team/create-team.component';

@Component({
    selector: 'app-create-project',
    templateUrl: './create-project.component.html',
    styleUrls: ['./create-project.component.sass'],
    providers: [FakeData, DialogService]
})
export class CreateProjectComponent extends BaseComponent implements OnInit {

    ORGANIZATION_ID = 1;
    USER_ID = 9;


    loadingNumber: number = 0;

    newProject = {} as NewProject;
    
    platforms = {} as {
        platformTabItems: MenuItem[],
        activePlatformTabItem: MenuItem,
        viewPlatformCards: Platform[],
        platformCards: Platform[]
    };

    teams: TeamOption[];

    alerts = {} as {
        alertCategories: string[],
        alertTypes: string[],
        alertTimeIntervals: string[],
    
        alertsCount: number,
        selectedAlertCategory?: string,
        selectedAlertType?: string,
        selectedAlertTimeInterval?: string,
        
        isSpecialAlertCategory: boolean
    }

   
    formGroup: FormGroup;
    SPECIAL_ALERT_CATEGORY: string = 'When there are more than';
    

    constructor(
        private toastNotifications: ToastNotificationService,
        private platformService: PlatformService,
        private teamService: TeamService,
        private dialogService: DialogService,
        private fakeData: FakeData
    ) {
        super();
    }

    ngOnInit() {
        this.initPlatforms();
        this.loadTeams();
        this.initFakeData();

        this.alerts.selectedAlertType = String(this.alerts.alertTypes[0]);
        this.alerts.selectedAlertTimeInterval = String(this.alerts.alertTimeIntervals[0]);
        this.alerts.alertsCount = 10;

        this.addValidation();
        
    }

    private addValidation()
    {
        this.formGroup = new FormGroup({
            alertCategory: new FormControl(
                this.alerts.alertCategories[0],
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

    private loadTeams() {
        this.loadingNumber += 1;
        this.teamService
            .getTeamOptionsByOrganizationId(this.ORGANIZATION_ID)
            .pipe(this.untilThis)
            .subscribe(teamOptions => {
                this.teams = teamOptions;
                this.loadingNumber -= 1;

            }, error => {
                this.toastNotifications.error(`${error}`);
                this.loadingNumber -= 1;
            });
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

    initFakeData() {
        this.alerts.alertTypes = this.fakeData.fakeAlertTypes;
        this.alerts.alertTimeIntervals = this.fakeData.fakeAlertTimeIntervals;
        this.alerts.alertCategories = this.fakeData.fakeAlertCategories;
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


    createTeamDialog: DynamicDialogRef;
    
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
                            createdBy: this.USER_ID,
                            organizationId: this.ORGANIZATION_ID,
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
        console.log(this.newProject);
    }
}
