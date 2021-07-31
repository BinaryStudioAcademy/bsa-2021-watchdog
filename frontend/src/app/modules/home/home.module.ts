import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { PrimeComponentsModule } from '@shared/modules/prime-components/prime-components.module';
import { HomeComponent } from './home-page/home-page.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeRoutingModule } from './home-routing.module';
import { ProjectsComponent } from './projects/projects.component';
import { IssuesComponent } from './issues/issues.component';
import { AddDashboardComponent } from './add-dashboard/add-dashboard.component';
import { ReactiveFormsModule } from '@angular/forms';

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
        PrimeComponentsModule,
        ReactiveFormsModule,
    ],
})
export class HomeModule { }
