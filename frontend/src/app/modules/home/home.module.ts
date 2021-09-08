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
import { IssuesModule } from '@shared/modules/issues/issues.module';
import { TileHeaderComponent } from './dashboard/tiles/tile-header/tile-header.component';
import { IssuesPerTimeTileComponent } from './dashboard/tiles/issues-per-time-tile/issues-per-time-tile.component';
import { AddEditIssuesPerTimeTileComponent }
    from './modals/tiles/issues-per-time/add-edit-issues-per-time-tile/add-edit-issues-per-time-tile.component';
import { IssuesCountTileComponent } from './dashboard/tiles/issues-count-tile/issues-count-tile.component';
import { AddEditCountIssuesTileComponent }
    from './modals/tiles/count-issues/add-edit-count-issues-tile/add-edit-count-issues-tile.component';
import { AddEditHeatMapTileComponent } from './modals/tiles/heat-map/add-edit-heat-map-tile/add-edit-heat-map-tile.component';
import { HeatMapComponent } from './dashboard/tiles/heat-map/heat-map.component';
import { AddEditTopResponsesTimeComponent } from '@modules/home/modals/tiles/top-responses-time/add-edit-top-responses-time-tile/add-edit-top-responses-time-tile.component';
import { TopResponsesTimeTileComponent } from './dashboard/tiles/top-responses-time-tile/top-responses-time-tile.component';
import { CommonTileComponent } from './dashboard/tiles/common-tile/common-tile.component';
import { CommomEditTileComponent } from './modals/tiles/commom-edit-tile/commom-edit-tile.component';

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
        IssuesPerTimeTileComponent,
        AddEditIssuesPerTimeTileComponent,
        AddEditTopResponsesTimeComponent,
        IssuesCountTileComponent,
        AddEditCountIssuesTileComponent,
        AddEditHeatMapTileComponent,
        HeatMapComponent,
        TopResponsesTimeTileComponent,
        CommonTileComponent,
        CommomEditTileComponent,
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
