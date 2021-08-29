import { AlertSettings } from '../alert-settings/alert-settings';

export interface UpdateProject {
    name: string,
    apiKey: string,
    description: string,
    platformId: number,
    alertSettings?: AlertSettings,
}
