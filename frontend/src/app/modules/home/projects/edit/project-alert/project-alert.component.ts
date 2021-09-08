import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { AlertSettings } from '@shared/models/alert-settings/alert-settings';
import { Project } from '@shared/models/projects/project';
import { DialogService } from 'primeng/dynamicdialog';
import { AlertCategory } from '@shared/models/alert-settings/alert-category';
import { Data } from '../../data';
import { Assignment } from '@shared/models/issue/assignment';
import { TeamService } from '@core/services/team.service';
import { ProjectService } from '@core/services/project.service';
import { RecipientTeam } from '@shared/models/projects/recipient-team';

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

    specialTypes = AlertCategory.Special;

    isAssignmentComponentDisplayed: boolean;
    teams: RecipientTeam[];
    assignment: Assignment;
    maxNumberOfDisplayedAvatars = 5;

    constructor(
        public alertData: Data,
        private teamService: TeamService,
        private projectService: ProjectService
    ) {
        super();
    }

    showAssignmentComponent() {
        this.isAssignmentComponentDisplayed = true;
    }

    hideAssignmentComponent() {
        this.isAssignmentComponentDisplayed = false;
        this.markTeamsAsRecipients();
    }

    getTeamsLabels(): string[] {
        return this.assignment.teamIds.slice(0, this.maxNumberOfDisplayedAvatars)
            .map(id => this.teamService.getLabel(this.teams.find(x => x.id === id).name));
    }

    getNumberOfHiddenAvatars() {
        return this.assignment.teamIds.length - this.maxNumberOfDisplayedAvatars;
    }

    markTeamsAsRecipients() {
        this.teams.forEach(item => {
            item.isRecipient = this.assignment.teamIds.includes(item.id); // eslint-disable-line no-param-reassign
        });
        this.recipientTeams.setValue(this.teams.filter(item => item.isRecipient));
    }

    ngOnInit() {
        this.isAssignmentComponentDisplayed = false;
        this.assignment = { teamIds: [] } as Assignment;
        this.teams = [];

        this.projectService.getRecipientTeams(this.project.id)
            .subscribe((teams: RecipientTeam[]) => {
                this.teams = teams;
                this.assignment.teamIds = teams.filter(x => x.isRecipient).map(x => x.id);
            });

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
        this.editFormAlert.addControl('recipientTeams', new FormControl(
            this.teams,
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
        this.editFormAlert.addControl('recipientTeams', new FormControl(
            this.teams,
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

    get recipientTeams() { return this.editFormAlert.controls.recipientTeams; }
}
