import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { GoogleChartOptions } from '@shared/models/charts/google-chart.options';
import { ChartType, GoogleChartComponent } from 'angular-google-charts';

@Component({
    selector: 'app-project-analytics',
    templateUrl: './project-analytics.component.html',
    styleUrls: ['./project-analytics.component.sass']
})
export class ProjectAnalyticsComponent implements OnInit {
    @Input() project: Project;
    geoChartOptions: GoogleChartOptions;
    @ViewChild('geoChart') geoChart: GoogleChartComponent;

    constructor() {

    }

    ngOnInit(): void {
        this.initChartSettings();
    }

    private initChartSettings() {
        this.geoChartOptions = {
            title: 'GeoMap',
            width: 800,
            height: 800,
            type: ChartType.GeoChart,
            geoData: [
                ['Germany', 340],
                ['United States', 300],
                ['Brazil', 400],
                ['Canada', 500],
                ['France', 600],
                ['Ukraine', 700],
                ['Russia', 100],
            ],
        };
    }
}
