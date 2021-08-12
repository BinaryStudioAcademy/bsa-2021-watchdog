import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeamsComponent } from '@modules/team/teams/teams.component';
import { TeamInfoComponent } from './team-info/team-info.component';

const routes: Routes = [{
    path: '',
    component: TeamsComponent
}, {
    path: ':id',
    component: TeamInfoComponent
}, {
    path: '',
    redirectTo: 'teams'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TeamRoutingModule { }
