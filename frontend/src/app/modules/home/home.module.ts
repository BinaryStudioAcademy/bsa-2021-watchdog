import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { HomeComponent } from './home-page/home-page.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeRoutingModule } from './home-routing.module';
import { ProjectsComponent } from './projects/projects/projects.component';
import { IssuesComponent } from './issues/issues.component';
import { AddDashboardComponent } from './modals/add-dashboard/add-dashboard.component';
import { UpdateDashboardComponent } from './modals/update-dashboard/update-dashboard.component';
import { CreateProjectComponent } from './projects/create-project/create-project.component';


@NgModule({
    declarations: [
        HomeComponent,
        DashboardComponent,
        ProjectsComponent,
        IssuesComponent,
        AddDashboardComponent,
        UpdateDashboardComponent,
        CreateProjectComponent,
    ],
    imports: [
        SharedModule,
        HomeRoutingModule,
    ],
})
export class HomeModule { }
