import { KeyValuePair } from '@shared/models/key-value-pair';

export const toObject = (kvps: KeyValuePair[]) => Object.assign({}, ...Array.from(kvps, kvp => ({ [kvp.key]: kvp.value })));

export const toKeyValuePairs = (obj: { [key: string]: string }) => Object.keys(obj).map(key => ({ key, value: obj[key] }));
