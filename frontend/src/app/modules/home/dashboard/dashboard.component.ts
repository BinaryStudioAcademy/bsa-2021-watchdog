import { Component, OnInit } from '@angular/core';
import { Dashboard } from '@shared/models/Dashboard';
import { ActivatedRoute } from '@angular/router';
import { DashboardService } from '@core/services/dashboard.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent implements OnInit {
    dashboard: Dashboard;

    constructor(private route: ActivatedRoute,
        private dashboardService: DashboardService) { }

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            const { name } = params;
            this.dashboard = this.dashboardService.get(name);
        });
    }
}
