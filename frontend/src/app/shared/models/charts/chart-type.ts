import { PropertiesMap } from './map';

export enum ChartType {
    Bars = 1,
    Pie,
    Tree,
    Guage,
    Line,
    Polar,
    Area,
    Grouped
}

export const chartTypeLabels: PropertiesMap<string> = {};

chartTypeLabels[ChartType.Bars] = 'Bars';
chartTypeLabels[ChartType.Pie] = 'Pie';
chartTypeLabels[ChartType.Tree] = 'Tree';
chartTypeLabels[ChartType.Guage] = 'Guage';
chartTypeLabels[ChartType.Line] = 'Line';
chartTypeLabels[ChartType.Polar] = 'Polar';
chartTypeLabels[ChartType.Area] = 'Area';
chartTypeLabels[ChartType.Grouped] = 'Grouped';
