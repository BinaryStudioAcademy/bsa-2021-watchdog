import { Component, Output, EventEmitter } from '@angular/core';
import { Dashboard } from '@shared/models/Dashboard';

@Component({
    selector: 'app-add-dashboard',
    templateUrl: './add-dashboard.component.html',
    styleUrls: ['./add-dashboard.component.sass']
})
export class AddDashboardComponent {
    newDashboard: Dashboard = {} as Dashboard;
    icons: string[];
    @Output() closeModal = new EventEmitter<void>();
    @Output() dashboardCreated = new EventEmitter<Dashboard>();

    constructor() {
        this.icons = ['pi-chart-bar', 'pi-chart-line'];
    }
}
