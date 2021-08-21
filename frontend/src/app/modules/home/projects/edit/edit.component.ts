import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { PlatformService } from '@core/services/platform.service';
import { ProjectService } from '@core/services/project.service';
import { SpinnerService } from '@core/services/spinner.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { regexs } from '@shared/constants/regexs';
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

    constructor(
        private toastNotifications: ToastNotificationService,
        private platformService: PlatformService,
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
                    this.validationsInit();
                    this.initPlatforms();
                })

        });
    }

    validationsInit() {

    }

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
        const project: UpdateProject = { ...this.editForm.value, platformId: this.updateProject.platformId };
        if (this.editForm.valid && this.updateProject.platformId) {
            this.spinnerService.show(true);
            this.projectService.updateProject(this.id, project)
                .subscribe(
                    project => {
                        this.toastNotifications.success(`${project.name} has been updated!`);
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
        this.editForm.reset(this.project);
        this.updateProject.platformId = this.project.platform.id;
    }

    deleteProject(id: string) {
        this.spinnerService.show(true);
        this.projectService.removeProject(id)
            .pipe(this.untilThis)
            .subscribe(project => {
                this.toastNotifications.success('Project has been deleted');
                this.router.navigate(['home', 'projects']);
                this.spinnerService.hide();
            },
            error => {
                this.toastNotifications.error(error);
                        this.spinnerService.hide();
            });
    }

}
