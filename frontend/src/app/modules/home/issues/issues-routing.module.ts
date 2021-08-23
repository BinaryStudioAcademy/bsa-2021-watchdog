import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IssueDetailsPageComponent } from '@modules/home/issues/issue-details/issue-details-page/issue-details-page.component';
import { IssuesComponent } from '@modules/home/issues/issues.component';

const routes: Routes = [{
    path: '',
    component: IssuesComponent,
}, {
    path: ':issueId/:eventId',
    component: IssueDetailsPageComponent,
}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class IssuesRoutingModule {
}
