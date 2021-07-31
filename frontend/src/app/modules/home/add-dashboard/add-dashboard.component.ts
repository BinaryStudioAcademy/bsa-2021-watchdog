import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { Dashboard } from '@shared/models/Dashboard';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-add-dashboard',
    templateUrl: './add-dashboard.component.html',
    styleUrls: ['./add-dashboard.component.sass']
})
export class AddDashboardComponent implements OnInit {
    public formGroup: FormGroup = {} as FormGroup;
    icons: string[];
    @Output() closeModal = new EventEmitter<void>();
    @Output() dashboardCreated = new EventEmitter<Dashboard>();

    constructor() {
        this.icons = ['pi-chart-bar', 'pi-chart-line'];
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

    onSubmit(): void {
        const newDashboard: Dashboard = <Dashboard> this.formGroup.value;
        this.dashboardCreated.emit(newDashboard);
    }
}
