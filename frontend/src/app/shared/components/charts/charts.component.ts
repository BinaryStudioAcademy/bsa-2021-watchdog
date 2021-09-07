import { AfterViewInit, Component, ElementRef, Input, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ChartOptions } from '@shared/models/charts/chart-options';
import { MultiChart } from '@shared/models/charts/multi-chart';
import { SingleChart } from '@shared/models/charts/single-chart';
import { ChartType } from '@shared/models/charts/chart-type';
import { AreaChartComponent } from '@swimlane/ngx-charts';
import { BaseComponent } from '@core/components/base/base.component';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-charts[chartType]',
    templateUrl: './charts.component.html',
    styleUrls: ['./charts.component.sass']
})
export class ChartsComponent extends BaseComponent implements OnInit, AfterViewInit, OnDestroy {
    @Input() single: SingleChart[];
    @Input() multi: MultiChart[];
    @Input() chartType: ChartType;
    @Input() chartOptions: ChartOptions;
    @Input() tileType: TileType;
    @Input() resize: Observable<void>;
    @ViewChild('chart') chart: AreaChartComponent;
    options: ChartOptions;
    ChartType = ChartType;
    observer: ResizeObserver;
    TileType = TileType;

    constructor(
        private host: ElementRef,
        private zone: NgZone
    ) {
        super();
    }

    ngOnInit() {
        this.options = this.setOptions(this.chartOptions);
        this.resize?.pipe(this.untilThis)
            .subscribe(() => {
                this.zone.run(() => {

                    // update chart size on parent resize
                    this.chart.update();
                });
            });
    }

    ngAfterViewInit() {
        if (!this.options.view) {
            this.observer = new ResizeObserver(() => {
                this.zone.run(() => {
                    // update chart size on parent resize
                    this.chart.update();
                });
            });

            this.observer.observe(this.host.nativeElement);
        }
    }

    ngOnDestroy() {
        super.ngOnDestroy();
        if (this.observer) {
            this.observer.unobserve(this.host.nativeElement);
        }
    }

    setOptions(chartOptions: ChartOptions): ChartOptions {
        return {
            xAxisLabel: chartOptions?.xAxisLabel,
            yAxisLabel: chartOptions?.yAxisLabel,
            legendTitle: chartOptions?.legendTitle,
            animations: chartOptions?.animations ?? true,
            showXAxis: chartOptions?.showXAxis ?? true,
            showYAxis: chartOptions?.showYAxis ?? true,
            gradient: chartOptions?.gradient ?? true,
            showLegend: chartOptions?.showLegend ?? false,
            showXAxisLabel: chartOptions?.showXAxisLabel ?? true,
            showYAxisLabel: chartOptions?.showYAxisLabel ?? false,
            timeline: chartOptions?.timeline ?? true,
            roundDomains: chartOptions?.roundDomains ?? true,
            autoScale: chartOptions?.autoScale ?? false,
            colorScheme: chartOptions?.colorScheme ?? {
                domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
            },
            view: chartOptions?.view,
            cardColor: chartOptions?.cardColor ?? '#ebebeb'
        };
    }
}
