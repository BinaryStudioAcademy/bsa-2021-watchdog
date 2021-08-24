import { Component, Input, OnInit } from '@angular/core';
import { ChartOptions } from '@shared/models/charts/chart-options';
import { MultiChart } from '@shared/models/charts/multi-chart';
import { SingleChart } from '@shared/models/charts/single-chart';
import { MenuItem } from 'primeng/api';
import { chartTypeLabels, ChartType } from '@shared/models/charts/chart-type';

@Component({
    selector: 'app-charts',
    templateUrl: './charts.component.html',
    styleUrls: ['./charts.component.sass']
})
export class ChartsComponent implements OnInit {
    @Input() single: SingleChart[];
    @Input() multi: MultiChart[];
    @Input() chartType: ChartType;
    @Input() chartOptions: ChartOptions;

    chartSingleTabItems: MenuItem[];
    currentSingleTabLable: string;
    chartMultiTabItems: MenuItem[];
    currentMultiTabLable: string;
    options: ChartOptions;

    constructor() {
        this.chartSingleTabItems = [
            { label: 'Bars', command: (event) => this.onSingleTabChange(event?.item) },
            { label: 'Pie', command: (event) => this.onSingleTabChange(event?.item) },
            { label: 'Tree', command: (event) => this.onSingleTabChange(event?.item) },
            { label: 'Guage', command: (event) => this.onSingleTabChange(event?.item) }];

        this.chartMultiTabItems = [
            { label: 'Line', command: (event) => this.onMultiTabChange(event?.item) },
            { label: 'Polar', command: (event) => this.onMultiTabChange(event?.item) },
            { label: 'Area', command: (event) => this.onMultiTabChange(event?.item) },
            { label: 'Grouped', command: (event) => this.onMultiTabChange(event?.item) }];
    }

    ngOnInit(): void {
        this.options = this.setOptions(this.chartOptions);
        this.currentMultiTabLable = chartTypeLabels[this.chartType] ?? 'Line';
        this.currentSingleTabLable = chartTypeLabels[this.chartType] ?? 'Bars';
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
            colorScheme: chartOptions?.colorScheme ?? {
                domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
            },
            view: chartOptions?.view
        };
    }

    onSingleTabChange(item) {
        this.currentSingleTabLable = item.label;
    }

    onMultiTabChange(item) {
        this.currentMultiTabLable = item.label;
    }
}
