import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { HomeComponent } from './home-page/home-page.component';
import { OrganizationModule } from './organization/organization.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeRoutingModule } from './home-routing.module';

import { AddDashboardComponent } from './modals/dashboard/add-dashboard.component';
import { UpdateDashboardComponent } from './modals/dashboard/update-dashboard.component';
import { TileMenuComponent } from './dashboard/tile-menu/tile-menu.component';

import { TopActiveIssuesTileComponent } from './dashboard/tiles/top-active-issues-tile/top-active-issues-tile.component';
import { AddEditTopActiveIssuesTileComponent }
    from './modals/tiles/top-active-issues/add-edit-top-active-issues-tile/add-edit-top-active-issues-tile.component';
import { IssuesModule } from '@modules/home/issues/issues.module';
import { TileHeaderComponent } from './dashboard/tiles/tile-header/tile-header.component';

@NgModule({
    declarations: [
        HomeComponent,
        DashboardComponent,
        AddDashboardComponent,
        UpdateDashboardComponent,
        TileMenuComponent,
        TopActiveIssuesTileComponent,
        AddEditTopActiveIssuesTileComponent,
        TileHeaderComponent,
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
