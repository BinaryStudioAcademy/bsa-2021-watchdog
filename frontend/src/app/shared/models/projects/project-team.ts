import { Team } from '@shared/models/teams/team';
import { Project } from '@shared/models/projects/project';

export interface ProjectTeam {
    id: number,
    team: Team,
    project: Project,
    isFavorite: boolean
}
