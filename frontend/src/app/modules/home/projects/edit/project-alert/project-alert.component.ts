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

    constructor(
        public alertData: Data
    ) {
        super();
    }

    ngOnInit() {
        this.initAlertData();
        this.addValidation();
    }

    // initValidatorForAlert() {
    //     this.editForm.addControl('alertCategory', new FormControl(this.alertData.alertCategories[0].value,
    //         Validators.required));
    //     this.editForm.addControl('alertsCount', new FormControl(this.alertSetting.specialAlertSetting.alertsCount,
    //         Validators.required));
    //     this.editForm.addControl('specialAlertType', new FormControl(this.alertSetting.specialAlertSetting.specialAlertType,
    //         Validators.required));
    //     this.editForm.addControl('alertTimeInterval', new FormControl(this.alertSetting.specialAlertSetting.alertTimeInterval,
    //         Validators.required));
    // }

    private addValidation() {
        this.editForm = new FormGroup({
            alertCategory: new FormControl(
                this.alertData.alertCategories[1].value,
                [
                    Validators.required
                ]
            )
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

    get alertCategory() { return this.editForm.controls.alertCategory; }
}
