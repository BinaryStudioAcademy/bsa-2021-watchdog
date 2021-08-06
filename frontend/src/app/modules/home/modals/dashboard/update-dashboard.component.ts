import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { DashboardService } from '@core/services/dashboard.service';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';

@Component({
    selector: 'app-update-dashboard',
    templateUrl: './dashboard-template.html',
    styleUrls: ['./dashboard-template.sass']
})
export class UpdateDashboardComponent implements OnInit {
    public formGroup: FormGroup = {} as FormGroup;
    icons: string[];
    @Input() dashboard: Dashboard;
    @Output() closeModal = new EventEmitter<void>();
    @Output() save = new EventEmitter<UpdateDashboard>();

    constructor(private dashboardService: DashboardService) {
        this.icons = dashboardService.getIcons();
    }

    ngOnInit() {
        this.formGroup = new FormGroup({
            id: new FormControl(
                this.dashboard.id,
                [
                    Validators.required
                ]
            ),
            name: new FormControl(
                this.dashboard.name,
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern('^[a-zA-Z0-9_. ]*$')
                ]
            ),
            icon: new FormControl(
                this.dashboard.icon,
                [
                    Validators.required
                ]
            ),
        });
    }

    saveHandle(): void {
        const dashboard: UpdateDashboard = <UpdateDashboard> this.formGroup.value;
        this.save.emit(dashboard);
    }
}
