import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { IssuesComponent } from '@shared/modules/issues/issues.component';
import { IssueEventsComponent } from '@shared/modules/issues/issue-details/issue-events/issue-events.component';
import { BreadcrumbsComponent } from '@shared/modules/issues/issue-details/breadcrumbs/breadcrumbs.component';
import { IssuesRoutingModule } from '@shared/modules/issues/issues-routing.module';
import { IssueDetailsPageComponent } from '@shared/modules/issues/issue-details/issue-details-page/issue-details-page.component';
import { IssueEnvironmentComponent } from '@shared/modules/issues/issue-details/issue-environment/issue-environment.component';
import { IssueDetailsComponent } from '@shared/modules/issues/issue-details/issue-details/issue-details.component';
import { AssigneeComponent } from '@shared/modules/issues/assignee/assignee.component';
import { IssueHttpComponent } from '@shared/modules/issues/issue-details/issue-http/issue-http.component';

@NgModule({
    imports: [
        SharedModule,
        IssuesRoutingModule
    ],
    exports: [
        IssuesComponent
    ],
    declarations: [
        IssuesComponent,
        IssueDetailsPageComponent,
        IssueDetailsComponent,
        IssueEventsComponent,
        IssueHttpComponent,
        IssueEnvironmentComponent,
        AssigneeComponent,
        BreadcrumbsComponent
    ]
})
export class IssuesModule {
}
