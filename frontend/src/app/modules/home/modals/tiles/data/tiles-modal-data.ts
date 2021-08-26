import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { DateRangeDropdown } from '@modules/home/modals/tiles/models/date-range-dropdown';
import { GranularityDropdown } from '@modules/home/modals/tiles/models/granularity-dropdown';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';
import { IssueStatusCheckbox } from '@modules/home/modals/tiles/models/issue-status-checkbox';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { DateRangeGranularityMap } from '@modules/home/modals/tiles/models/date-range-granularity-map';

export class TilesModalData {
    dateRangeGranularityMap: DateRangeGranularityMap<GranularityDropdown[]> = {};

    dateRangeDropdownItems: DateRangeDropdown[] = [
        {
            type: TileDateRangeType.ThePastHour,
            name: 'The past hour'
        },
        {
            type: TileDateRangeType.ThePastDay,
            name: 'The past day'
        },
        {
            type: TileDateRangeType.ThePast2Days,
            name: 'The past 2 days'
        },
        {
            type: TileDateRangeType.ThePastWeek,
            name: 'The past week'
        },
        {
            type: TileDateRangeType.ThePast2Weeks,
            name: 'The past 2 weeks'
        }
    ];

    issueStatusCheckboxes: IssueStatusCheckbox[] = [
        {
            type: IssueStatus.Active,
            name: 'Active'
        },
        {
            type: IssueStatus.Resolved,
            name: 'Resolved'
        },
        {
            type: IssueStatus.Ignored,
            name: 'Ignored'
        },
        {
            type: IssueStatus.PermanentlyIgnored,
            name: 'Permanently ignored'
        }
    ];

    private granularityDropdownOneMinute: GranularityDropdown = {
        type: TileGranularityType.OneMinute,
        name: 'One minute'
    };

    private granularityDropdownTenMinute: GranularityDropdown = {
        type: TileGranularityType.TenMinute,
        name: 'Ten minute'
    };

    private granularityDropdownOneHour: GranularityDropdown = {
        type: TileGranularityType.OneHour,
        name: 'One hour'
    };

    private granularityDropdownOneDay: GranularityDropdown = {
        type: TileGranularityType.OneDay,
        name: 'One day'
    };

    constructor() {
        this.dateRangeGranularityMap[TileDateRangeType.ThePastHour] = [
            this.granularityDropdownOneMinute, this.granularityDropdownTenMinute];
        this.dateRangeGranularityMap[TileDateRangeType.ThePastDay] = [
            this.granularityDropdownTenMinute, this.granularityDropdownOneHour];
        this.dateRangeGranularityMap[TileDateRangeType.ThePast2Days] = [
            this.granularityDropdownTenMinute, this.granularityDropdownOneHour];
        this.dateRangeGranularityMap[TileDateRangeType.ThePastWeek] = [
            this.granularityDropdownOneHour, this.granularityDropdownOneDay];
        this.dateRangeGranularityMap[TileDateRangeType.ThePast2Weeks] = [
            this.granularityDropdownOneHour, this.granularityDropdownOneDay];
    }
}
