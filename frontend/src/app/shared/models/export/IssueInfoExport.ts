/**
 * Use only to pdf/excel export
 */
export interface IssueInfoExport {
    LastErrorUrl?: string,
    ErrorClass?: string,
    ErrorMessage?: string,
    Status?: string,
    Events?: number,
    OccurredOn?: string,
    Project?: string,
    Assignee?: string
}
