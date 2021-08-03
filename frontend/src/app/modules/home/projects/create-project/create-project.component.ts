import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-create-project',
    templateUrl: './create-project.component.html',
    styleUrls: ['./create-project.component.sass']
})
export class CreateProjectComponent implements OnInit {
    // This class is for the test/example, it's not a final result !!!!
    public formGroup: FormGroup;
    public tabItems: MenuItem[];
    public activeTabItem: MenuItem;
    public viewPlatformCards: {
        img: string, name: string, isBrowser?: boolean, isServer?: boolean, isMobile?: boolean, isDesktop?: boolean
    }[];
    public selectedAlertCategory: any = null;
    public alertCategories = [
        { name: 'I\'ll create my own alerts later' },
        { name: 'Alert me on every new issue' },
        { name: 'When there are more than' }];
    public alertsCount: number = 10;
    public alertTypes = [
        { name: 'occurrences of' },
        { name: 'users affected by' }
    ];
    public selectedAlertType: any = null;
    public alertTimeIntervals = [
        { name: 'one minute' },
        { name: '5 minutes' },
        { name: '15 minutes' },
        { name: 'one hour' },
        { name: 'one day' },
        { name: 'one week' },
        { name: '30 days' }
    ];
    public userTeams = [
        { name: '#vitaliy-shatskiy' },
        { name: '#binary-studio' },
        { name: '#watch-dog' },
        { name: '#ats' },
    ];
    public selectedAlertTimeInterval: any = null;
    private platformCards: {
        img: string, name: string, isBrowser?: boolean, isServer?: boolean, isMobile?: boolean, isDesktop?: boolean
    }[];
    public selectedPlatformElement?: { element: HTMLElement, platformName: string };

    constructor(private toastNotifications: ToastNotificationService) {
    }

    ngOnInit() {
        this.platformCards = [
            {
                img: 'https://upload.wikimedia.org/wikipedia/commons/a/a3/.NET_Logo.svg',
                name: 'dotnet',
                isServer: true,
                isDesktop: true
            },
            {
                img: 'https://upload.wikimedia.org/wikipedia/commons/9/99/Unofficial_JavaScript_logo_2.svg',
                name: 'javascript',
                isBrowser: true
            },
            {
                img: 'https://image.flaticon.com/icons/png/512/731/731985.png',
                name: 'ios',
                isMobile: true,
                isDesktop: true
            },
            {
                img: 'https://upload.wikimedia.org/wikipedia/uk/2/2e/Java_Logo.svg',
                name: 'java',
                isServer: true,
                isDesktop: true
            }
        ];
        this.tabItems = [
            { label: 'All', command: (event) => this.onTabChange(event) },
            { label: 'Browser', command: (event) => this.onTabChange(event) },
            { label: 'Server', command: (event) => this.onTabChange(event) },
            { label: 'Mobile', command: (event) => this.onTabChange(event) },
            { label: 'Desktop', command: (event) => this.onTabChange(event) }
        ];
        this.activeTabItem = Object.assign(this.tabItems[0]);
        this.onTabChange();
        this.selectedAlertType = Object.assign(this.alertTypes[0]);
        this.selectedAlertTimeInterval = Object.assign(this.alertTimeIntervals[0]);

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
    }

    onTabChange(event?: any): void {
        if (this.selectedPlatformElement) {
            this.selectedPlatformElement.element.style.background = 'transparent';
            this.selectedPlatformElement = undefined;
        }
        switch (event?.item.label ?? '') {
            case 'Browser': {
                this.viewPlatformCards = [...this.platformCards.filter(value => value.isBrowser === true)];
                break;
            }
            case 'Server': {
                this.viewPlatformCards = [...this.platformCards.filter(value => value.isServer === true)];
                break;
            }
            case 'Mobile': {
                this.viewPlatformCards = [...this.platformCards.filter(value => value.isMobile === true)];
                break;
            }
            case 'Desktop': {
                this.viewPlatformCards = [...this.platformCards.filter(value => value.isDesktop === true)];
                break;
            }
            default: {
                this.viewPlatformCards = [...this.platformCards];
                break;
            }
        }
    }

    onPlatformSelected(event: any, platformName: string) {
        if (this.selectedPlatformElement) {
            this.selectedPlatformElement.element.style.background = 'transparent';
            if (this.selectedPlatformElement.platformName === platformName) {
                this.selectedPlatformElement = undefined;
                return;
            }
        }
        const element = event.target.className !== 'card ng-star-inserted' ? event.target.parentElement : event.target;
        element.style.background = 'lightgray';
        this.selectedPlatformElement = { element, platformName };
    }

    createProject() {
        if (this.formGroup.valid && this.selectedPlatformElement !== undefined) {
            let alertCategorySettings: any;
            if (this.formGroup.controls.alertCategory.value.name === 'When there are more than') {
                alertCategorySettings = {
                    count: this.alertsCount,
                    type: this.selectedAlertType,
                    timeInterval: this.selectedAlertTimeInterval
                };
            }
            const project = {
                projectName: this.formGroup.controls.projectName.value,
                alertCategory: this.formGroup.controls.alertCategory.value.name,
                team: this.formGroup.controls.team.value,
                platform: this.selectedPlatformElement.platformName,
                alertCategorySettings
            };
            console.log(project);
            this.toastNotifications.success('Created');
        }
    }
}
