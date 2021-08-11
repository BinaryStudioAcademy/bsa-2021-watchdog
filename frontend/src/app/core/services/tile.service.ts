import { Injectable } from '@angular/core';
import { TileType } from '@shared/models/tile/tile-type';
import { TopActiveIssuesSettings } from '@shared/models/tile/tiles-settings/top-active-issues-settings';

@Injectable({ providedIn: 'root' })
export class TileService {
    convertJsonToTileSettings(json: string, type: TileType): TopActiveIssuesSettings | undefined {
        switch (type) {
            case TileType.TopActiveIssues:
                return JSON.parse(json) as TopActiveIssuesSettings;
            default:
                return undefined;
        }
    }

    convertTileSettingsToJson(tileSettings: object): string | undefined {
        return tileSettings ? JSON.stringify(tileSettings) : undefined;
    }
}
