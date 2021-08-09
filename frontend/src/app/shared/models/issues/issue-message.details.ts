import { StackTrace } from '@shared/models/issues/stack.trace';
import { HttpResponseErrorMessage } from '@shared/models/issues/http-response.message';
import { IssueEnvironment } from '@shared/models/issues/issue-environment';

export interface IssueMessageDetails {
    url: string,
    errorMessage: string,
    className: string,
    stackTrace?: StackTrace[],
    responseErrorMessage?: HttpResponseErrorMessage,
    environmentMessage: IssueEnvironment,
}
