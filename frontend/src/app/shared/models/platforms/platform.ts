import { PlatformTypes } from './platform-types';

export interface Platform {
    id: number,
    name: string,
    avatarUrl: string,
    platformTypes: PlatformTypes
}
