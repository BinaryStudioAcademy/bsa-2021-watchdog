import { IssueStatusDropdown } from '@modules/home/issues/issue-details/data/models/issue-status-dropdown';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';

export class IssueDetailsData {
    issueStatusDropdownItems: IssueStatusDropdown[] = [
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
