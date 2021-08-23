import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { AlertSettings } from '@shared/models/alert-settings/alert-settings';
import { Project } from '@shared/models/projects/project';
import { DialogService } from 'primeng/dynamicdialog';
import { Data } from '../../data';

@Component({
    selector: 'app-project-alert',
    templateUrl: './project-alert.component.html',
    styleUrls: ['../edit.component.sass'],
    providers: [Data, DialogService]
})
export class ProjectAlertComponent extends BaseComponent implements OnInit {
    @Input() alertSetting = {} as AlertSettings;
    @Input() editForm: FormGroup;
    @Input() project: Project;

    alertCategoryValue = this.alertData.alertCategories;
    specialAlertTypeValue = this.alertData.alertTypes;
    alertTimeIntervalValue = this.alertData.alertTimeIntervals;

    constructor(
        public alertData: Data
    ) {
        super();
    }

    ngOnInit() {
        if (this.project.alertSettings.alertCategory !== 3) {
            this.initAlertData();
            this.addValidationWithDefaultData();
        } else {
            this.addValidation();
        }
    }

    addValidation() {
        this.editForm.addControl('alertCategory', new FormControl(
            this.project.alertSettings.alertCategory,
            Validators.required
        ));
        this.editForm.addControl('alertsCount', new FormControl(
            this.project.alertSettings.specialAlertSetting.alertsCount,
            Validators.required
        ));
        this.editForm.addControl('specialAlertType', new FormControl(
            this.project.alertSettings.specialAlertSetting.specialAlertType,
            Validators.required
        ));
        this.editForm.addControl('alertTimeInterval', new FormControl(
            this.project.alertSettings.specialAlertSetting.alertTimeInterval,
            Validators.required
        ));
    }

    addValidationWithDefaultData() {
        this.editForm.addControl('alertCategory', new FormControl(
            this.project.alertSettings.alertCategory,
            Validators.required
        ));
        this.editForm.addControl('alertsCount', new FormControl(
            this.alertSetting.specialAlertSetting.alertsCount,
            Validators.required
        ));
        this.editForm.addControl('specialAlertType', new FormControl(
            this.alertSetting.specialAlertSetting.specialAlertType,
            Validators.required
        ));
        this.editForm.addControl('alertTimeInterval', new FormControl(
            this.alertSetting.specialAlertSetting.alertTimeInterval,
            Validators.required
        ));
    }

    private initAlertData() {
        this.alertSetting.alertCategory = this.alertData.initAlertCategory;
        this.alertSetting.specialAlertSetting = {
            alertsCount: this.alertData.initAlertsCount,
            specialAlertType: this.alertData.initSpecialAlertType,
            alertTimeInterval: this.alertData.initAlertTimeInterval
        };
    }

    get alertCategory() { return this.editForm.controls.alertCategory; }

    get alertsCount() { return this.editForm.controls.alertsCount; }

    get specialAlertType() { return this.editForm.controls.specialAlertType; }

    get alertTimeInterval() { return this.editForm.controls.alertTimeInterval; }
}
