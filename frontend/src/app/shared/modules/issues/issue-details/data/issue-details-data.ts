import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { IssueStatusDropdown } from '@shared/modules/issues/issue-details/data/models/issue-status-dropdown';
import { IssueSelectDropdown } from '@shared/modules/issues/issue-details/data/models/issue-select-dropdown';
import { IssueSelect } from '@shared/models/issue/enums/issue-select';

export class IssueDetailsData {
    public static getIssueStatusDropdownItems(): IssueStatusDropdown[] {
        return [
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
        ];
    }

    public static getIssuesSelectDropdownItems(): IssueSelectDropdown[] {
        return [
            {
                type: IssueSelect.Active,
                name: 'Active'
            },
            {
                type: IssueSelect.Resolved,
                name: 'Resolved'
            },
            {
                type: IssueSelect.Ignored,
                name: 'Ignored'
            },
            {
                type: IssueSelect.All,
                name: 'All'
            },
        ];
    }
}
