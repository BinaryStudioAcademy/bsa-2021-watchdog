import {Injectable} from "@angular/core";
import {Dashboard} from "@shared/models/Dashboard"

@Injectable({ providedIn: 'root' })
export class DashboardService {
    private readonly dashboards: Dashboard[];

    constructor() {
        this.dashboards = [
            {
                name: "WebAPICharts",
                icon: "pi-chart-line"
            },
            {
                name: "JsCharts",
                icon: "pi-chart-line"
            },
            {
                name: "Python app",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core1",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core2",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core3",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core4appppppp",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core5",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core6",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core7",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core8",
                icon: "pi-chart-line"
            },
            {
                name: "ASP.NET Core9",
                icon: "pi-chart-line"
            },

        ];
    }

    public getAll(): Dashboard[]{
        return this.dashboards;
    }

    public get(name: string): Dashboard{
        return this.dashboards.find(d => d.name == name);
    }

    public addDashboard(dashboard: Dashboard): void{
        this.dashboards.push(dashboard);
    }
}
