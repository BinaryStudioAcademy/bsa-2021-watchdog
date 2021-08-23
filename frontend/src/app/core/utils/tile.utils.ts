import { TileType } from '@shared/models/tile/enums/tile-type';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';

export const convertJsonToTileSettings = (json: string, type: TileType): TopActiveIssuesSettings | undefined => {
    switch (type) {
        case TileType.TopActiveIssues:
            return JSON.parse(json) as TopActiveIssuesSettings;
        default:
            return undefined;
    }
};

export const convertTileSettingsToJson = (tileSettings: object): string | undefined =>
    (tileSettings ? JSON.stringify(tileSettings) : undefined);

const hoursToMs = (hours: number): number =>
    hours * 60 * 60 * 1000;

export const convertTileDateRangeTypeToMs = (type: TileDateRangeType): number => {
    switch (type) {
        case TileDateRangeType.ThePastHour:
            return hoursToMs(1);
        case TileDateRangeType.ThePastDay:
            return hoursToMs(24);
        case TileDateRangeType.ThePast2Days:
            return hoursToMs(48);
        case TileDateRangeType.ThePastWeek:
            return hoursToMs(168);
        case TileDateRangeType.ThePast2Weeks:
            return hoursToMs(336);
        default:
            return undefined;
    }
};
