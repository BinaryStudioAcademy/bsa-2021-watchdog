import { toBreadcrumbHtmlElement } from '../utils/watchdog.utils';
import { Breadcrumb, BreadcrumbBody } from './breadcrumb';
import { BreadcrumbHtmlElement } from './breadcrumb-html-element';

export interface ClickBreadcrumbBody extends BreadcrumbBody {
    path: BreadcrumbHtmlElement[];
}

export class ClickBreadcrumb extends Breadcrumb {
    body: ClickBreadcrumbBody;
    constructor(path: HTMLElement[]) {
        super();
        this.type = 'user-action';
        this.category = 'click';
        this.level = 'info';
        this.body = {
            path: path.filter(el => el.localName && el.localName !== 'html' && el.localName !== 'body')
                .map(el => toBreadcrumbHtmlElement(el))
        };
    }
}
