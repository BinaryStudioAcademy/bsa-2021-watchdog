import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { FakeData } from '@modules/home/projects/fake-data';
import { Project } from '@shared/models/projects/project';
import { PlatformService } from '@core/services/platform.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Platform } from '@shared/models/platforms/platform';
import { Team } from '@shared/models/projects/team';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-create-project',
    templateUrl: './create-project.component.html',
    styleUrls: ['./create-project.component.sass'],
    providers: [FakeData]
})
export class CreateProjectComponent extends BaseComponent implements OnInit {
    public loadingNumber: number = 0;

    public platformTabItems: MenuItem[];
    public viewPlatformCards: Platform[];
    public userTeams: Team[];
    public alertCategories: string[];
    public alertTypes: string[];
    public alertTimeIntervals: string[];

    public alertsCount: number;
    public selectedAlertCategory?: string;
    public selectedAlertType?: string;
    public selectedAlertTimeInterval?: string;
    public selectedPlatformId?: number;
    public activePlatformTabItem: MenuItem;
    public formGroup: FormGroup;
    public SPECIAL_ALERT_CATEGORY: string = 'When there are more than';
    private platformCards: Platform[];

    constructor(
        private toastNotifications: ToastNotificationService,
        private platformService: PlatformService,
        private fakeData: FakeData,
        private sanitizer: DomSanitizer
    ) {
        super();
    }

    ngOnInit() {
        this.initData();
        this.initFakeData();
        this.platformTabItems = [
            { label: 'All', command: (event) => this.onTabChange(event) },
            { label: 'Browser', command: (event) => this.onTabChange(event) },
            { label: 'Server', command: (event) => this.onTabChange(event) },
            { label: 'Mobile', command: (event) => this.onTabChange(event) },
            { label: 'Desktop', command: (event) => this.onTabChange(event) }
        ];
        this.activePlatformTabItem = Object.assign(this.platformTabItems[0]);
        this.selectedAlertType = String(this.alertTypes[0]);
        this.selectedAlertTimeInterval = String(this.alertTimeIntervals[0]);
        this.alertsCount = 10;
        this.formGroup = new FormGroup({
            alertCategory: new FormControl(
                this.alertCategories[0],
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
                    Validators.pattern('^[a-zA-Z0-9-_]+$')
                ]
            ),
            team: new FormControl(
                this.userTeams[0],
                [
                    Validators.required
                ],
            ),
        });
        this.onTabChange();
    }
    initData() {
        this.loadingNumber += 1;
        this.platformService
        .getPlatforms()
        .pipe(this.untilThis)
        .subscribe(p => {
            const platforms = p as HttpResponse<Platform[]>;
            this.platformCards = this.viewPlatformCards = platforms.body;
        }, error => {
            this.toastNotifications.error(`${error}`, 'Error', 2000);
        }, () => this.loadingNumber -= 1);
    }

    initFakeData() {
        // this.platformCards = this.fakeData.fakePlatforms;
        this.alertTypes = this.fakeData.fakeAlertTypes;
        this.alertTimeIntervals = this.fakeData.fakeAlertTimeIntervals;
        this.alertCategories = this.fakeData.fakeAlertCategories;
        this.userTeams = this.fakeData.fakeTeams;
    }

    onTabChange(event?: any): void {
        this.selectedPlatformId = undefined;
        switch (event?.item.label ?? '') {
            case 'Browser': {
                this.viewPlatformCards = [...this.platformCards.filter(value => value.platformTypes.includes('browser'))];
                break;
            }
            case 'Server': {
                this.viewPlatformCards = [...this.platformCards.filter(value => value.platformTypes.includes('server'))];
                break;
            }
            case 'Mobile': {
                this.viewPlatformCards = [...this.platformCards.filter(value => value.platformTypes.includes('mobile'))];
                break;
            }
            case 'Desktop': {
                this.viewPlatformCards = [...this.platformCards.filter(value => value.platformTypes.includes('desktop'))];
                break;
            }
            default: {
                this.viewPlatformCards = [...this.platformCards];
                break;
            }
        }
    }

    onPlatformSelected(platformId: number): void {
        this.selectedPlatformId = platformId === this.selectedPlatformId ? undefined : platformId;
    }

    createProject(): void {
        if (this.formGroup.valid && this.selectedPlatformId) {
            const project: Project = {
                id: 5,
                name: this.formGroup.controls.projectName.value,
                team: this.formGroup.controls.team.value,
                platform: this.platformCards.find(value => value.id === this.selectedPlatformId),
                alertSettings:
                    {
                        alertCategory: this.selectedAlertCategory,
                        alertsCount: this.alertsCount,
                        alertType: this.selectedAlertType,
                        alertTimeInterval: this.selectedAlertTimeInterval
                    }
            };
            console.log(project);
            this.toastNotifications.success(`${project.name} created!`);
        }
    }
}
