import { Injectable } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';

@Injectable({ providedIn: 'root' })
export class DashboardService {
    //mock data
    private dashboards: Dashboard[];

    constructor() {
        //mock data
        this.dashboards = [
            {
                id: 1,
                name: 'WebAPICharts',
                icon: 'pi-chart-line'
            },
            {
                id: 2,
                name: 'JsCharts',
                icon: 'pi-chart-line'
            },
            {
                id: 3,
                name: 'Python app',
                icon: 'pi-chart-line'
            },
            {
                id: 4,
                name: 'ASP.NET Core',
                icon: 'pi-chart-line'
            },
        ];
    }

    //mock methods
    //TODO: Load real data from server
    public getIcons(): string[] {
        return ['pi-chart-bar', 'pi-chart-line'];
    }

    public getAll(): Dashboard[] {
        return this.dashboards;
    }

    public get(id: string): Dashboard {
        return this.dashboards.find(d => d.id === +id);
    }

    public addDashboard(newDashboard: NewDashboard): Dashboard {
        this.dashboards.push({ id: this.dashboards.length + 1, name: newDashboard.name, icon: newDashboard.icon });
        return this.dashboards[this.dashboards.length + 1];
    }

    public deleteDashboard(id: number): boolean {
        this.dashboards = this.dashboards.filter(d => d.id !== id);
        return true;
    }

    public updateDashboard(updateDashboard: UpdateDashboard): Dashboard {
        const key = this.dashboards.findIndex(el => el.id === updateDashboard.id);
        this.dashboards[key] = updateDashboard;
        return this.dashboards[key];
    }
}
