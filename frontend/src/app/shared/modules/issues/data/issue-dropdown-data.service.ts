import { IssueStatusDropdown } from '@shared/modules/issues/data/models/issue-status.dropdown';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { IssueSelectDropdown } from '@shared/modules/issues/data/models/issue-select.dropdown';
import { IssueSelect } from '@shared/models/issue/enums/issue-select';

export class IssueDropdownDataService {
    getIssueStatusDropdownItems(): IssueStatusDropdown[] {
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

    getIssuesSelectDropdownItems(): IssueSelectDropdown[] {
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
