import { TestMethod } from '@shared/models/test/enums/test-method';
import { TestProtocol } from '@shared/models/test/enums/test-protocol';
import { TestType } from '@shared/models/test/enums/test-type';

export const typeOptions = [
    {
        value: TestType.ClientsPerSecond,
        label: 'Clients per second',
    },
    {
        value: TestType.ClientsPerTest,
        label: 'Clients per test',
    },
    {
        value: TestType.MaintainClientLoad,
        label: 'Maintain client load',
    },
];

export const protocolOptions = [
    {
        value: TestProtocol.Http,
        label: 'http',
    },
    {
        value: TestProtocol.Https,
        label: 'https',
    },
];

export const methodOptions = [
    {
        value: TestMethod.Get,
        label: 'GET',
    },
    {
        value: TestMethod.Post,
        label: 'POST',
    },
    {
        value: TestMethod.Patch,
        label: 'PATCH',
    },
    {
        value: TestMethod.Put,
        label: 'PUT',
    },
    {
        value: TestMethod.Delete,
        label: 'DELETE',
    },
];

export const contentTypes = ['application/json', 'application/xml', 'text/html'];
