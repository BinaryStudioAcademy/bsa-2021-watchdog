import { Component, Output, EventEmitter, OnInit, Input } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/Dashboard';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-add-dashboard',
    templateUrl: './add-dashboard.component.html',
    styleUrls: ['./add-dashboard.component.sass']
})
export class AddDashboardComponent implements OnInit {
    public formGroup: FormGroup = {} as FormGroup;
    icons: string[];
    @Input() dashboard: Dashboard = {} as Dashboard;
    @Input() modalName: string;
    @Output() closeModal = new EventEmitter<void>();
    @Output() save = new EventEmitter<Dashboard>();

    constructor() {
        this.icons = ['pi-chart-bar', 'pi-chart-line'];
    }

    ngOnInit() {
        this.formGroup = new FormGroup({
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
        const dashboard: Dashboard = <Dashboard> this.formGroup.value;
        console.log(dashboard);
        this.save.emit(dashboard);
    }
}
