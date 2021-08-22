import { Component, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { PlatformService } from '@core/services/platform.service';
import { ProjectService } from '@core/services/project.service';
import { SpinnerService } from '@core/services/spinner.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { regexs } from '@shared/constants/regexs';
import { Platform } from '@shared/models/platforms/platform';
import { Project } from '@shared/models/projects/project';
import { UpdateProject } from '@shared/models/projects/update-project';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-project-general',
  templateUrl: './project-general.component.html',
  styleUrls: ['../edit.component.sass']
})
export class ProjectGeneralComponent extends BaseComponent implements OnInit {
    @Input() project: Project;
    @Input() editForm: FormGroup;
    @Input() platforms = {
        platformTabItems: [] as MenuItem[],
        activePlatformTabItem: {} as MenuItem,
        viewPlatformCards: [] as Platform[],
        platformCards: [] as Platform[]
    };
    @Input() updateProject = {} as UpdateProject;
    @Input() id: string;

    @Input() dropPlatform: Platform[];

    @Input() selectedPlatform: Platform;

    @Input() idSelectedPlatform = 3;

    currentVal: any;

    constructor(
        private platformService: PlatformService,
    ) {
        super();
     }

    ngOnInit() {
        this.editForm.addControl('name', new FormControl(this.project.name, [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50),
            Validators.pattern(regexs.projectName),
        ]));
        this.editForm.addControl('description', new FormControl(this.project.description, [
            Validators.maxLength(1000),
            Validators.pattern(regexs.projectDescription),
        ]));
        this.platformService.getPlatforms().pipe(this.untilThis)
            .subscribe(platform => {
                this.dropPlatform = platform;
                this.selectedPlatform = this.project.platform;
            })

    }

    onSelectType(event) {
        if(event) {
            this.currentVal = event;
            this.idSelectedPlatform = this.currentVal.id;
        }
        console.log('this.currentVal', this.currentVal);
        console.log('idSelectedPlatform', this.idSelectedPlatform);
    }

    get name() { return this.editForm.controls.name; }

    get description() { return this.editForm.controls.description; }
}
