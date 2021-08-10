export interface StackTrace {
    file: string,
    methodName: string,
    arguments: string[],
    lineNumber: number,
    column: number
}
