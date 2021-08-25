import { Component, Input } from '@angular/core';
import { Breadcrumb } from '@core/collecting-errors/models/breadcrumb';
import { getIconAndColor } from '@core/services/breadcrumb.utils';
import { BreadcrumbItem } from '@shared/models/issue/breadcrumb-item';
import { IssueMessage } from '@shared/models/issue/issue-message';

@Component({
    selector: 'app-breadcrumbs[issueMessage]',
    templateUrl: './breadcrumbs.component.html',
    styleUrls: ['./breadcrumbs.component.sass']
})
export class BreadcrumbsComponent {
    @Input() set issueMessage(value: IssueMessage) {
        const breadcrumbs = value?.issueDetails?.breadcrumbs?.map(x => new Breadcrumb(x));

        this.breadcrumbs = breadcrumbs?.concat(new Breadcrumb({
            type: 'error',
            category: 'exception',
            level: 'error',
            time: value.occurredOn,
            body: JSON.stringify(value?.issueDetails),
        }))?.map(b => ({ ...b, ...getIconAndColor(b) }));
    }

    breadcrumbs: BreadcrumbItem[];
}
