import { Breadcrumb, BreadcrumbBody, BreadcrumbLevel } from "./breadcrumb";

export class TraceBreadcrumbBody extends BreadcrumbBody {
    from: string;
    to: string;
}

export class TraceBreadcrumb extends Breadcrumb {
    body: TraceBreadcrumbBody;
    constructor (from: string, to: string) {
        super();
        this.type = 'navigation';
        this.category = 'react-router';
        this.level = 'info';
        this.body = {from: from, to: to};
    }
}