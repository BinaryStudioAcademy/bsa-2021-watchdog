import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {Dashboard} from "@shared/models/Dashboard"

@Component({
  selector: 'app-add-dashboard',
  templateUrl: './add-dashboard.component.html',
  styleUrls: ['./add-dashboard.component.sass']
})
export class AddDashboardComponent implements OnInit {
    newDashboard: Dashboard = {} as Dashboard;
    icons: string[];
    @Output() onCloseModal = new EventEmitter<void>();
    @Output() onDashboardCreated = new EventEmitter<Dashboard>();

    constructor() { }

    ngOnInit(): void {
        this.icons = ['pi-chart-bar', 'pi-chart-line'];
    }
}
