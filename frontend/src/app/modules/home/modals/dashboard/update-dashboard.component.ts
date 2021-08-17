import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { regexs } from '@shared/constants/regexs';
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
    selectedIcon: SelectItem;
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
                    Validators.pattern(regexs.dashboardName)
                ]
            )
        });
        this.selectedIcon = { label: `pi ${this.dashboard.icon}`, value: `${this.dashboard.icon}` };
    }

    onSelect(icon: SelectItem): void {
        this.selectedIcon = icon;
    }

    saveHandle(): void {
        const dashboard: UpdateDashboard = <UpdateDashboard> this.formGroup.value;
        dashboard.icon = this.selectedIcon.value;
        this.save.emit(dashboard);
    }
}
