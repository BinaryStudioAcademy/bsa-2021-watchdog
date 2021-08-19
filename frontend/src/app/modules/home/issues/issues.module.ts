import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { IssuesRoutingModule } from '@modules/home/issues/issues-routing.module';
import { IssueEventsComponent } from '@modules/home/issues/issue-details/issue-events/issue-events.component';
import { IssueDetailsPageComponent } from '@modules/home/issues/issue-details/issue-details-page/issue-details-page.component';
import { IssueEnvironmentComponent } from '@modules/home/issues/issue-details/issue-environment/issue-environment.component';
import { IssuesComponent } from '@modules/home/issues/issues.component';
import { IssueDetailsComponent } from '@modules/home/issues/issue-details/issue-details/issue-details.component';
import { IssueHttpComponent } from '@modules/home/issues/issue-details/issue-http/issue-http.component';

@NgModule({
    imports: [
        SharedModule,
        IssuesRoutingModule
    ],
    exports: [],
    declarations: [
        IssuesComponent,
        IssueDetailsPageComponent,
        IssueDetailsComponent,
        IssueEventsComponent,
        IssueHttpComponent,
        IssueEnvironmentComponent,

    ]
})
export class IssuesModule {
}
