import { Component, Input, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { GoogleChartOptions } from '@shared/models/charts/google-chart.options';
import { ChartType } from 'angular-google-charts';
import { BaseComponent } from '@core/components/base/base.component';
import { ProjectService } from '@core/services/project.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-project-analytics',
    templateUrl: './project-analytics.component.html',
    styleUrls: ['./project-analytics.component.sass']
})
export class ProjectAnalyticsComponent extends BaseComponent implements OnInit {
    @Input() project: Project;
    geoChartOptions: GoogleChartOptions;
    geoData: (string | number)[][];
    defaultMargin = 345;

    width = document.documentElement.clientWidth - this.defaultMargin;
    height = document.documentElement.clientHeight - this.defaultMargin;

    constructor(
        private projectsService: ProjectService,
        private toastNotification: ToastNotificationService
    ) {
        super();
    }

    ngOnInit(): void {
        this.initChartSettings();
    }

    resetWindowSize(event) {
        this.width = event.target.innerWidth - this.defaultMargin;
        this.height = event.target.innerHeight - this.defaultMargin;
        this.initChartSettings();
    }

    private initChartSettings() {
        this.geoChartOptions = {
            type: ChartType.GeoChart,
            width: this.width,
            height: this.height
        };

        this.projectsService
            .getCountriesInfo(this.project.id)
            .pipe(this.untilThis)
            .subscribe(countriesInfo => {
                this.geoData = countriesInfo.length
                    ? countriesInfo.map(c => ([c.country, c.count]))
                    : [['', 0]];
            }, error => {
                this.toastNotification.error(error);
            });
    }
}
