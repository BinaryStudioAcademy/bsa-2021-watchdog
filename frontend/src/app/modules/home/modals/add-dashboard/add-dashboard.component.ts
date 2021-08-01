import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DashboardService } from '@core/services/dashboard.service';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';

@Component({
    selector: 'app-add-dashboard',
    templateUrl: './add-dashboard.component.html',
    styleUrls: ['./add-dashboard.component.sass']
})
export class AddDashboardComponent implements OnInit {
    public formGroup: FormGroup = {} as FormGroup;
    icons: string[];
    @Output() closeModal = new EventEmitter<void>();
    @Output() save = new EventEmitter<NewDashboard>();

    constructor(private dashboardService: DashboardService) {
        this.icons = dashboardService.getIcons();
    }

    ngOnInit() {
        this.formGroup = new FormGroup({
            name: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(5),
                    Validators.maxLength(50)
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
        this.save.emit(dashboard);
    }
}
