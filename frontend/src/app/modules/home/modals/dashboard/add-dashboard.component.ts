import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DashboardService } from '@core/services/dashboard.service';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';

@Component({
    selector: 'app-add-dashboard',
    templateUrl: './dashboard-template.html',
    styleUrls: ['./dashboard-template.sass']
})
export class AddDashboardComponent implements OnInit {
    public formGroup: FormGroup = {} as FormGroup;
    icons: string[];
    @Output() closeModal = new EventEmitter<void>();
    @Output() save = new EventEmitter<NewDashboard>();
    //fake data
    fakeOrganizationId = 1;
    fakeUserId = 1;

    constructor(private dashboardService: DashboardService) {
        this.icons = dashboardService.getIcons();
    }

    ngOnInit() {
        const namePattern = new RegExp('^[a-zA-Z0-9_. ]*$');
        this.formGroup = new FormGroup({
            name: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(namePattern)
                ]
            ),
            icon: new FormControl(
                '',
                [
                    Validators.required
                ]
            ),
        });
    }

    saveHandle(): void {
        const dashboard: NewDashboard = <NewDashboard> this.formGroup.value;
        dashboard.createdBy = this.fakeOrganizationId;
        dashboard.organizationId = this.fakeUserId;
        this.save.emit(dashboard);
    }
}
