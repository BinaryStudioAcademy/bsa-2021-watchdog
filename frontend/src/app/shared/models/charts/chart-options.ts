import { ColorScheme } from './color-scheme';

export interface ChartOptions {
    xAxisLabel?: string;
    yAxisLabel?: string;
    legendTitle?: string;

    view?: [number, number];

    animations?: boolean;
    showXAxis?: boolean;
    showYAxis?: boolean;
    gradient?: boolean;
    showLegend?: boolean;
    showXAxisLabel?: boolean;
    showYAxisLabel?: boolean;
    timeline?: boolean;
    colorScheme?: ColorScheme;
}
