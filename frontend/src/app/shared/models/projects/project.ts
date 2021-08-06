import { AlertSettings } from '@shared/models/projects/alert-settings';
import { Team } from '@shared/models/projects/team';
import { Platform } from './platform';
// edit this when you need
export interface Project {
    id: number,
    name: string,
    description?: string,
    platform: Platform,
    team?: Team,
    alertSettings?: AlertSettings
}
