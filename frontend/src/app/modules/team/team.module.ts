import { TeamMembersComponent } from "./team-info/team-members/team-members.component";
import { TeamProjectsComponent } from "./team-info/team-projects/team-projects.component";
import { TeamSettingsComponent } from "./team-info/team-settings/team-settings.component";
import { TeamInfoComponent } from "./team-info/team-info.component";
import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { TeamRoutingModule } from '@modules/team/team-routing.module';
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
        TeamMembersComponent
    ],
    imports: [
        SharedModule,
        TeamRoutingModule
    ]
})
export class TeamModule { }
