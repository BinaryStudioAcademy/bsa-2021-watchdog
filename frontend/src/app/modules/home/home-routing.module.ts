import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotFoundComponent } from '@shared/components/not-found/not-found.component';
import { OrganizationSettingsComponent } from './organization/organization-settings/organization-settings.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home-page/home-page.component';

const routes: Routes = [{
    path: '',
    component: HomeComponent,
    children: [{
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
    }, {
        path: 'dashboard',
        component: DashboardComponent,
    }, {
        path: 'settings',
        component: OrganizationSettingsComponent
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
