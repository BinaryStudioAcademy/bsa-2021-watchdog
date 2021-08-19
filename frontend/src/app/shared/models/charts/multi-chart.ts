import { SingleChart } from './single-chart';

export interface MultiChart {
    name: string,
    series: SingleChart[]
}
