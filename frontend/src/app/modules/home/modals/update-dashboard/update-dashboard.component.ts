import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { DashboardService } from '@core/services/dashboard.service';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';

@Component({
    selector: 'app-update-dashboard',
    templateUrl: './update-dashboard.component.html',
    styleUrls: ['./update-dashboard.component.sass']
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
                    Validators.minLength(5),
                    Validators.maxLength(50)
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
