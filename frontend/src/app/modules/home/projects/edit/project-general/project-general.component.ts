import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { PlatformService } from '@core/services/platform.service';
import { regexs } from '@shared/constants/regexs';
import { Platform } from '@shared/models/platforms/platform';
import { Project } from '@shared/models/projects/project';
import { ProjectService } from '@core/services/project.service';
import { of } from 'rxjs';
import { uniqueApiKeyValidator } from '@shared/validators/api-key.validator';

@Component({
    selector: 'app-project-general',
    templateUrl: './project-general.component.html',
    styleUrls: ['../edit.component.sass']
})
export class ProjectGeneralComponent extends BaseComponent implements OnInit {
    @Input() project: Project;
    @Input() editForm: FormGroup;
    @Input() dropPlatform: Platform[];

    constructor(
        private platformService: PlatformService,
        private projectService: ProjectService
    ) {
        super();
    }

    ngOnInit() {
        this.initValidators();
        this.platformService.getPlatforms().pipe(this.untilThis)
            .subscribe(platform => {
                this.dropPlatform = platform;
            });
    }

    initValidators() {
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
        this.editForm.addControl('apiKey', new FormControl(this.project.apiKey, {
            validators: [
                Validators.required,
                Validators.maxLength(36),
                Validators.minLength(36),
                Validators.pattern(regexs.projectApiKey),
            ],
            asyncValidators: [
                this.apiKeyValidator
            ]
        }));
        this.editForm.addControl('platformId', new FormControl(this.project.platform.id, Validators.required));
    }

    refreshApiKey() {
        this.projectService.refreshApiKey(this.project.id)
            .pipe(this.untilThis)
            .subscribe(updatedProject => {
                this.project = updatedProject;
                this.editForm.patchValue({
                    apiKey: updatedProject.apiKey,
                });
            });
    }

    apiKeyValidator = (ctrl: AbstractControl) => {
        if (this.project.apiKey === ctrl.value) {
            return of(null);
        }
        return uniqueApiKeyValidator(this.projectService)(ctrl);
    };

    get name() { return this.editForm.controls.name; }

    get description() { return this.editForm.controls.description; }

    get platformId() { return this.editForm.controls.platformId; }

    get apiKey() { return this.editForm.controls.apiKey; }
}
