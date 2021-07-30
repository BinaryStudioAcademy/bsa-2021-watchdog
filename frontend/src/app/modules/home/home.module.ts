import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { HomeComponent } from './home-page/home-page.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeRoutingModule } from './home-routing.module';
import { MenuModule } from "primeng/menu";
import { ProjectsComponent } from './projects/projects.component';
import { IssuesComponent } from './issues/issues.component';
import {PanelModule} from "primeng/panel";
import {DialogModule} from "primeng/dialog";
import { AddDashboardComponent } from './add-dashboard/add-dashboard.component';
import {PrimeComponentsModule} from "@shared/modules/prime-components/prime-components.module";

@NgModule({
    declarations: [
        HomeComponent,
        DashboardComponent,
        ProjectsComponent,
        IssuesComponent,
        AddDashboardComponent,
    ],
    imports: [
        SharedModule,
        HomeRoutingModule,
        MenuModule,
        PanelModule,
        DialogModule,
        PrimeComponentsModule,
    ],
})
export class HomeModule { }
