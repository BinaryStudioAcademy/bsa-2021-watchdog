import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { TeamRoutingModule } from '@modules/team/team-routing.module';
import { TeamAddMemberComponent } from './team-info/team-overlay/team-add-member/team-add-member.component';
import { TeamAddProjectComponent } from './team-info/team-overlay/team-add-project/team-add-project.component';
import { TeamMembersComponent } from './team-info/team-members/team-members.component';
import { TeamProjectsComponent } from './team-info/team-projects/team-projects.component';
import { TeamSettingsComponent } from './team-info/team-settings/team-settings.component';
import { TeamInfoComponent } from './team-info/team-info.component';
import { TeamsComponent } from './teams/teams.component';
import { UserTeamsComponent } from './teams/user-teams/user-teams.component';
import { OtherTeamsComponent } from './teams/other-teams/other-teams.component';
import { CreateTeamComponent } from './create-team/create-team.component';

@NgModule({
    declarations: [
        TeamsComponent,
        UserTeamsComponent,
        OtherTeamsComponent,
        CreateTeamComponent,
        TeamInfoComponent,
        TeamSettingsComponent,
        TeamProjectsComponent,
        TeamMembersComponent,
        TeamAddMemberComponent,
        TeamAddProjectComponent
    ],
    imports: [
        SharedModule,
        TeamRoutingModule
    ]
})
export class TeamModule { }
