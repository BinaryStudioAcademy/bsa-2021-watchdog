import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { GeneralSettingsComponent } from './organization/organization-settings/general-settings/general-settings.component';
import { OrganizationSettingsComponent } from './organization/organization-settings/organization-settings.component';

import { HomeComponent } from './home-page/home-page.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeRoutingModule } from './home-routing.module';
import { MembershipSettingsComponent } from './organization/organization-settings/membership-settings/membership-settings.component';
import { OrganizationMenuComponent } from './organization/organization-menu/organization-menu.component';
import { ProjectsComponent } from './projects/projects.component';
import { IssuesComponent } from './issues/issues.component';
import { AddDashboardComponent } from './modals/add-dashboard/add-dashboard.component';
import { UpdateDashboardComponent } from './modals/update-dashboard/update-dashboard.component';

@NgModule({
    declarations: [
        HomeComponent,
        DashboardComponent,
        OrganizationMenuComponent,
        OrganizationSettingsComponent,
        MembershipSettingsComponent,
        GeneralSettingsComponent,
        ProjectsComponent,
        IssuesComponent,
        AddDashboardComponent,
        UpdateDashboardComponent,
    ],
    imports: [
        SharedModule,
        HomeRoutingModule,
    ],
})
export class HomeModule { }
