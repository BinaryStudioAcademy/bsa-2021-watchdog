import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotFoundComponent } from '@shared/components/not-found/not-found.component';
import { ProjectsComponent } from '@modules/home/projects/projects.component';
import { TeamsComponent } from '@modules/home/teams/teams.component';
import { IssuesComponent } from '@modules/home/issues/issues.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home-page/home-page.component';

const routes: Routes = [{
    path: '',
    component: HomeComponent,
    children: [{
        path: '',
        redirectTo: 'projects',
        pathMatch: 'full',
    }, {
        path: 'projects',
        component: ProjectsComponent,
    }, {
        path: 'issues',
        component: IssuesComponent,
    }, {
        path: 'teams',
        component: TeamsComponent,
    }, {
        path: 'dashboard/:id',
        component: DashboardComponent,
    }, {
        path: '**',
        component: NotFoundComponent,
        pathMatch: 'full'
    }]
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomeRoutingModule { }
