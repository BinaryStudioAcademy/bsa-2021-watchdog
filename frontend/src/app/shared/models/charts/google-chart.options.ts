import { ChartType } from 'angular-google-charts';

export interface GoogleChartOptions {
    title?: string;
    width?: number,
    height?: number,
    type?: ChartType,
    geoData?: (string | number)[][]
    options?: Object
}
