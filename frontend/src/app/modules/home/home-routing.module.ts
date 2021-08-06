import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotFoundComponent } from '@shared/components/not-found/not-found.component';
import { ProjectsComponent } from '@modules/home/projects/projects/projects.component';
import { IssuesComponent } from '@modules/home/issues/issues.component';
import { CreateProjectComponent } from '@modules/home/projects/create-project/create-project.component';
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
        path: 'projects/create',
        component: CreateProjectComponent,
    },
    {
        path: 'issues',
        component: IssuesComponent,
    }, {
        path: 'teams',
        loadChildren: () => import('../team/team.module')
            .then(m => m.TeamModule),
    }, {
        path: 'dashboard/:id',
        component: DashboardComponent,
    }, {
        path: 'members',
        loadChildren:()=> import('../members/members.module')
            .then(m=> m.MembersModule),
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
export class HomeRoutingModule {
}
