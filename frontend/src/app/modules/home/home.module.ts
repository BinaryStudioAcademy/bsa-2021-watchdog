import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { MenuModule } from 'primeng/menu';
import { PanelModule } from 'primeng/panel';
import { DialogModule } from 'primeng/dialog';
import { PrimeComponentsModule } from '@shared/modules/prime-components/prime-components.module';
import { HomeComponent } from './home-page/home-page.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeRoutingModule } from './home-routing.module';
import { ProjectsComponent } from './projects/projects.component';
import { IssuesComponent } from './issues/issues.component';
import { AddDashboardComponent } from './add-dashboard/add-dashboard.component';

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
