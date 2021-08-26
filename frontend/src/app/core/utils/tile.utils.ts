import { TileType } from '@shared/models/tile/enums/tile-type';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { IssuesPerTimeSettings } from '@shared/models/tile/settings/issues-per-time-settings';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';

export const convertJsonToTileSettings = (json: string, type: TileType) => {
    switch (type) {
        case TileType.TopActiveIssues:
            return JSON.parse(json) as TopActiveIssuesSettings;
        case TileType.IssuesPerTime:
            return JSON.parse(json) as IssuesPerTimeSettings;
        default:
            return undefined;
    }
};

export const convertTileSettingsToJson = (tileSettings: object): string | undefined =>
    (tileSettings ? JSON.stringify(tileSettings) : undefined);

const secondsToMs = (seconds: number): number =>
    seconds * 1000;

const minutesToMs = (minutes: number): number =>
    secondsToMs(minutes * 60);

const hoursToMs = (hours: number): number =>
    minutesToMs(hours * 60);

const daysToMs = (days: number): number =>
    hoursToMs(days * 24);

export const convertTileDateRangeTypeToMs = (type: TileDateRangeType): number | undefined => {
    switch (type) {
        case TileDateRangeType.ThePastHour:
            return hoursToMs(1);
        case TileDateRangeType.ThePastDay:
            return daysToMs(1);
        case TileDateRangeType.ThePast2Days:
            return daysToMs(2);
        case TileDateRangeType.ThePastWeek:
            return daysToMs(7);
        case TileDateRangeType.ThePast2Weeks:
            return daysToMs(14);
        default:
            return undefined;
    }
};

export const convertTileGranularityTypeToMs = (type: TileGranularityType): number | undefined => {
    switch (type) {
        case TileGranularityType.OneMinute:
            return minutesToMs(1);
        case TileGranularityType.TenMinute:
            return minutesToMs(10);
        case TileGranularityType.OneHour:
            return hoursToMs(1);
        case TileGranularityType.OneDay:
            return daysToMs(1);
        default:
            return undefined;
    }
};

export const convertDateToTileGranularityTimeStamp = (type: TileGranularityType, infoDate: Date | number): number | undefined => {
    const date = new Date(infoDate);
    switch (type) {
        case TileGranularityType.OneHour:
            date.setMinutes(0, 0, 0);
            break;
        case TileGranularityType.OneMinute:
            date.setSeconds(0, 0);
            break;
        case TileGranularityType.OneDay:
            date.setHours(0, 0, 0, 0);
            break;
        case TileGranularityType.TenMinute:
            date.setMinutes(Math.round(date.getMinutes() / 10) * 10, 0, 0);
            break;
        default:
            return undefined;
    }
    return date.getTime();
};
