import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { SelectItem } from 'primeng/api/selectitem';

@Component({
    selector: 'app-update-dashboard',
    templateUrl: './dashboard-template.html',
    styleUrls: ['./dashboard-template.sass']
})
export class UpdateDashboardComponent implements OnInit {
    title: string = 'Edit dashboard';
    public formGroup: FormGroup = {} as FormGroup;
    icons: SelectItem[];
    @Input() dashboard: Dashboard;
    @Output() closeModal = new EventEmitter<void>();
    @Output() save = new EventEmitter<UpdateDashboard>();

    constructor() {
        this.icons = [
            { label: 'pi pi-chart-bar', value: 'pi-chart-bar' },
            { label: 'pi pi-chart-line', value: 'pi-chart-line' }
        ];
    }

    ngOnInit() {
        const namePattern = new RegExp('^[a-zA-Z0-9_. ]*$');
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
                    Validators.pattern(namePattern)
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
