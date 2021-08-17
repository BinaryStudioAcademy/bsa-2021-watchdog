import { StackFrame } from '@shared/models/issue/stack-frame';
import { HttpResponseErrorMessage } from '@shared/models/issue/http-response.message';
import { IssueEnvironment } from '@shared/models/issue/issue-environment';

export interface IssueDetails {
    url: string,
    errorMessage: string,
    className: string,
    stackTrace?: StackFrame[],
    responseErrorMessage?: HttpResponseErrorMessage,
    environmentMessage: IssueEnvironment,
}
