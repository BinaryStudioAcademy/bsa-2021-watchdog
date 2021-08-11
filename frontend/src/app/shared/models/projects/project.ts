import { Platform } from '../platforms/platform';
// edit this when you need
export interface Project {
    id: number,
    name: string,
    description: string,
    securityToken: string,
    platform: Platform,
}
