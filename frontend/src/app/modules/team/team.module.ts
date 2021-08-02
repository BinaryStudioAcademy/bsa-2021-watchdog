import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { TeamRoutingModule } from '@modules/team/team-routing.module';
import { TeamsComponent } from './teams/teams.component';
import { UserTeamsComponent } from './teams/user-teams/user-teams.component';
import { OtherTeamsComponent } from './teams/other-teams/other-teams.component';

@NgModule({
    declarations: [
        TeamsComponent,
        UserTeamsComponent,
        OtherTeamsComponent
    ],
    imports: [
        SharedModule,
        TeamRoutingModule
    ]
})
export class TeamModule { }
