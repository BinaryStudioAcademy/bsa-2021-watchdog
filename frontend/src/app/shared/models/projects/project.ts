import { AlertSettings } from '../alert-settings/alert-settings';
import { Platform } from '../platforms/platform';

export interface Project {
    id: number,
    name: string,
    apiKey: string,
    description: string,
    securityToken: string,
    platform: Platform,
    alertSettings?: AlertSettings,
    organizationId: number
}
