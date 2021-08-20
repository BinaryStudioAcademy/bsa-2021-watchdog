import { Component, Input, OnInit } from '@angular/core';
import { Breadcrumb } from '@core/collecting-errors/models/breadcrumb';
import { getIconAndColor } from '@core/services/breadcrumb.utils';
import { BreadcrumbItem } from '@shared/models/issue/breadcrumb-item';
import { IssueMessage } from '@shared/models/issue/issue-message';

@Component({
    selector: 'app-breadcrumbs',
    templateUrl: './breadcrumbs.component.html',
    styleUrls: ['./breadcrumbs.component.sass']
})
export class BreadcrumbsComponent implements OnInit {
    @Input() issueMessage: IssueMessage;

    breadcrumbs: BreadcrumbItem[];

    ngOnInit(): void {
        const breadcrumbs = this.issueMessage?.issueDetails?.breadcrumbs?.map(x => new Breadcrumb(x));

        this.breadcrumbs = breadcrumbs?.concat(new Breadcrumb({
            type: 'error',
            category: 'exception',
            level: 'error',
            time: this.issueMessage?.occurredOn,
            body: JSON.stringify(this.issueMessage?.issueDetails),
        }))?.map(b => ({ ...b, ...getIconAndColor(b) }));
    }
}
