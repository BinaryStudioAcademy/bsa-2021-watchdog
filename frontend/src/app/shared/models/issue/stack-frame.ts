export interface StackFrame {
    file: string,
    methodName: string,
    className: string,
    arguments: string[],
    lineNumber: number,
    column: number
}
