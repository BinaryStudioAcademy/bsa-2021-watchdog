import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotFoundComponent } from '@shared/components/not-found/not-found.component';
import { UserProfileComponent } from '@modules/user/components/user-profile/user-profile.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home-page/home-page.component';
import { ApprovedGuard } from '@core/guards/approved.guard';

const routes: Routes = [{
    path: '',
    component: HomeComponent,
    children: [{
        path: '',
        redirectTo: 'projects',
        pathMatch: 'full',
    }, {
        path: 'projects',
        loadChildren: () => import('./projects/projects.module')
            .then(m => m.ProjectsModule),
    }, {
        path: 'issues',
        loadChildren: () => import('./issues/issues.module')
            .then(m => m.IssuesModule),
    }, {
        path: 'users',
        component: UserProfileComponent,
    }, {
        path: 'teams',
        loadChildren: () => import('../team/team.module')
            .then(m => m.TeamModule),
    }, {
        path: 'dashboard/:id',
        component: DashboardComponent,
    }, {
        path: 'members',
        loadChildren: () => import('../members/members.module')
            .then(m => m.MembersModule),
    }, {
        path: 'organization',
        loadChildren: () => import('./organization/organization.module')
            .then(m => m.OrganizationModule),
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
