import { Platform } from '@shared/models/projects/platform';
import { AlertSettings } from '@shared/models/projects/alert-settings';
import { Team } from '@shared/models/projects/team';
// edit this when you need
export interface Project {
    id: number,
    name: string,
    description?: string,
    platform: Platform,
    team: Team,
    alertSettings?: AlertSettings
}
