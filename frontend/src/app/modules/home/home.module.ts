import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { HomeComponent } from './home-page/home-page.component';
import { OrganizationModule } from './organization/organization.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeRoutingModule } from './home-routing.module';
import { ProjectsComponent } from './projects/projects/projects.component';

import { AddDashboardComponent } from './modals/dashboard/add-dashboard.component';
import { UpdateDashboardComponent } from './modals/dashboard/update-dashboard.component';
import { CreateProjectComponent } from './projects/create-project/create-project.component';
import { TileMenuComponent } from './dashboard/tile-menu/tile-menu.component';

import { TopActiveIssuesTileComponent } from './dashboard/tiles/top-active-issues-tile/top-active-issues-tile.component';
import { AddEditTopActiveIssuesTileComponent }
    from './modals/tiles/top-active-issues/add-edit-top-active-issues-tile/add-edit-top-active-issues-tile.component';
import { IssuesModule } from '@modules/home/issues/issues.module';
import { EditProjectComponent } from './projects/edit-project/edit-project.component';

@NgModule({
    declarations: [
        HomeComponent,
        DashboardComponent,
        AddDashboardComponent,
        UpdateDashboardComponent,
        TileMenuComponent,
        TopActiveIssuesTileComponent,
        AddEditTopActiveIssuesTileComponent,
    ],
    imports: [
        SharedModule,
        HomeRoutingModule,
        OrganizationModule,
        IssuesModule
    ],
})
export class HomeModule {
}
