export interface HttpResponseErrorMessage {
    message: string,
    url: string,
    status: number,
    statusText: string,
    hostName: string,
    httpMethod: string,
    ipAddress: string,
    headers: Map<string, string>,
    queryString: Map<string, string>
}
