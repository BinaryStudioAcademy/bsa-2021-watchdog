import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { CreateProjectComponent } from './create-project/create-project.component';
import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects/projects.component';
import { EditComponent } from './edit/edit.component';
import { ProjectGeneralComponent } from './edit/project-general/project-general.component';
import { ProjectAlertComponent } from './edit/project-alert/project-alert.component';
import { ConfigureWrapperComponent } from './edit/configure/configure-wrapper/configure-wrapper.component';
import { AspNetCoreComponent } from './edit/configure/configurations/asp-net-core/asp-net-core.component';
import { HighlightModule } from 'ngx-highlightjs';
import { AngularComponent } from './edit/configure/configurations/angular/angular.component';
import { ReactComponent } from './edit/configure/configurations/react/react.component';
import { JavascriptComponent } from './edit/configure/configurations/javascript/javascript.component';
import { ProjectAnalyticsComponent } from './project-analytics/project-analytics.component';
import { CodeComponent } from './edit/configure/code/code.component';
import { AssignmentOfTeamsComponent } from './edit/project-alert/assignment/assignment-of-teams/assignment-of-teams.component';
import { IssuesModule } from '@shared/modules/issues/issues.module';
import { DotNetComponent } from './edit/configure/configurations/dot-net/dot-net.component';

@NgModule({
    declarations: [
        ProjectsComponent,
        CreateProjectComponent,
        EditComponent,
        ProjectGeneralComponent,
        ProjectAlertComponent,
        ConfigureWrapperComponent,
        AspNetCoreComponent,
        AngularComponent,
        ReactComponent,
        JavascriptComponent,
        ProjectAnalyticsComponent,
        CodeComponent,
        AssignmentOfTeamsComponent,
        DotNetComponent,
    ],
    imports: [
        SharedModule,
        ProjectsRoutingModule,
        HighlightModule,
        IssuesModule
    ]
})
export class ProjectsModule {
}
