import { Breadcrumb, BreadcrumbBody } from './breadcrumb';

export interface TraceBreadcrumbBody extends BreadcrumbBody {
    from: string;
    to: string;
}

export class TraceBreadcrumb extends Breadcrumb {
    body: TraceBreadcrumbBody;
    constructor(from: string, to: string) {
        super();
        this.type = 'navigation';
        this.category = 'router';
        this.level = 'info';
        this.body = { from, to };
    }
}
