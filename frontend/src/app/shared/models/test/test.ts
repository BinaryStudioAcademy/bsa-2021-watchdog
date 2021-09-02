import { TestRequest } from './test-request';
import { TestType } from '@shared/models/test/enums/test-type';

export interface Test {
    id?: number,
    name: string,
    type: TestType,
    clients: number,
    duration: string,
    projectId?: number,
    organizationId: number,
    requests: TestRequest[]
}
