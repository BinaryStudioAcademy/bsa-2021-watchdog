import { Observable, Subject } from "rxjs";

export type BreadcrumbType = 'navigation' | 'debug' | 'error'; 
export type BreadcrumbCategory = 'react-router' | 'console' | 'ajax' | 'click' | 'exception';
export type BreadcrumbLevel = 'info' | 'warning' | 'error' | 'debug';

export class BreadcrumbBody {

}

export class Breadcrumb {
    type: BreadcrumbType;
    category: BreadcrumbCategory;
    level: BreadcrumbLevel;
    time: Date;
    body: BreadcrumbBody;

    constructor() {
        this.time = new Date;
    }
}