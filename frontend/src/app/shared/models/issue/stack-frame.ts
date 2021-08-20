export interface StackFrame {
    file: string,
    methodName: string,
    arguments: string[],
    lineNumber: number,
    column: number
}
