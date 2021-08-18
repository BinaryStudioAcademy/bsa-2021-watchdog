import { Breadcrumb, BreadcrumbBody, BreadcrumbLevel } from "./breadcrumb";

export class ConsoleBreadcrumbBody extends BreadcrumbBody {
    data: any[];
}

export class ConsoleBreadcrumb extends Breadcrumb {
    body: ConsoleBreadcrumbBody;
    constructor (level: BreadcrumbLevel, data: any[]) {
        super();
        this.type = 'debug';
        this.category = 'console';
        this.level = level;
        this.body = {data: data};
    }
}