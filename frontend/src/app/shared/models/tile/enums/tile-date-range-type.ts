export enum TileDateRangeType {
    ThePastHour = 0,
    ThePastDay = 1,
    ThePast2Days = 2,
    ThePastWeek = 3,
    ThePast2Weeks = 4,
    ThePast30Days = 5,
    ThePastYear = 6,
    All = 7
}

export const dateRangeTypeLabels: {} = [];

dateRangeTypeLabels[TileDateRangeType.ThePastHour] = 'Past hour';
dateRangeTypeLabels[TileDateRangeType.ThePastDay] = 'Past day';
dateRangeTypeLabels[TileDateRangeType.ThePast2Days] = 'Past 2 days';
dateRangeTypeLabels[TileDateRangeType.ThePast2Weeks] = 'Past 2 weeks';
dateRangeTypeLabels[TileDateRangeType.ThePast30Days] = 'Past month';
dateRangeTypeLabels[TileDateRangeType.ThePastYear] = 'Past year';
dateRangeTypeLabels[TileDateRangeType.All] = 'All';
