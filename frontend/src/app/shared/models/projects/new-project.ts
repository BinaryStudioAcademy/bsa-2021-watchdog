import { AlertSettings } from '../alert-settings/alert-settings';

export interface NewProject {
    name: string,
    description: string,
    platformId: number,
    organizationId: number,
    teamId: number,
    alertSettings?: AlertSettings,
    createdBy: number
}
