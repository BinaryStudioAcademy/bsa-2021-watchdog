import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeamsComponent } from '@modules/team/teams/teams.component';

const routes: Routes = [{
    path: 'teams',
    component: TeamsComponent
}, {
    path: '',
    redirectTo: 'teams'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TeamRoutingModule { }
