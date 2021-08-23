import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { AlertSettings } from '@shared/models/alert-settings/alert-settings';
import { Project } from '@shared/models/projects/project';
import { DialogService } from 'primeng/dynamicdialog';
import { AlertCategory } from '@shared/models/alert-settings/alert-category';
import { Data } from '../../data';

@Component({
    selector: 'app-project-alert',
    templateUrl: './project-alert.component.html',
    styleUrls: ['../edit.component.sass'],
    providers: [Data, DialogService]
})
export class ProjectAlertComponent extends BaseComponent implements OnInit {
    @Input() alertSetting = {} as AlertSettings;
    @Input() editFormAlert: FormGroup = new FormGroup({});
    @Input() project: Project;

    alertCategoryValue = this.alertData.alertCategories;
    specialAlertTypeValue = this.alertData.alertTypes;
    alertTimeIntervalValue = this.alertData.alertTimeIntervals;
    specialTypes = AlertCategory.Special;

    constructor(
        public alertData: Data
    ) {
        super();
    }

    ngOnInit() {
        if (this.project.alertSettings.alertCategory !== this.specialTypes) {
            this.initAlertData();
            this.addValidationWithDefaultData();
        } else {
            this.addValidation();
        }
    }

    addValidation() {
        this.editFormAlert.addControl('alertCategory', new FormControl(
            this.project.alertSettings.alertCategory,
            Validators.required
        ));
        this.editFormAlert.addControl('alertsCount', new FormControl(
            this.project.alertSettings.specialAlertSetting.alertsCount,
            Validators.required
        ));
        this.editFormAlert.addControl('specialAlertType', new FormControl(
            this.project.alertSettings.specialAlertSetting.specialAlertType,
            Validators.required
        ));
        this.editFormAlert.addControl('alertTimeInterval', new FormControl(
            this.project.alertSettings.specialAlertSetting.alertTimeInterval,
            Validators.required
        ));
    }

    addValidationWithDefaultData() {
        this.editFormAlert.addControl('alertCategory', new FormControl(
            this.project.alertSettings.alertCategory,
            Validators.required
        ));
        this.editFormAlert.addControl('alertsCount', new FormControl(
            this.alertSetting.specialAlertSetting.alertsCount,
            Validators.required
        ));
        this.editFormAlert.addControl('specialAlertType', new FormControl(
            this.alertSetting.specialAlertSetting.specialAlertType,
            Validators.required
        ));
        this.editFormAlert.addControl('alertTimeInterval', new FormControl(
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

    get alertCategory() { return this.editFormAlert.controls.alertCategory; }

    get alertsCount() { return this.editFormAlert.controls.alertsCount; }

    get specialAlertType() { return this.editFormAlert.controls.specialAlertType; }

    get alertTimeInterval() { return this.editFormAlert.controls.alertTimeInterval; }
}
