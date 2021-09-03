import { TestProtocol } from './enums/test-protocol';
import { TestMethod } from './enums/test-method';

export interface TestRequest {
    id?: number,
    method: TestMethod
    protocol: TestProtocol,
    host: string,
    path?: string,
    body?: string,
    headers?: string,
    parameters?: string,
}
