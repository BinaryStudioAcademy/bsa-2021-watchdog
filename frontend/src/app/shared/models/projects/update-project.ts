import { AlertSettings } from '../alert-settings/alert-settings';
import { RecipientTeam } from './recipient-team';

export interface UpdateProject {
    name: string,
    apiKey: string,
    description: string,
    platformId: number,
    alertSettings?: AlertSettings,
    recipientTeams: RecipientTeam[]
}
