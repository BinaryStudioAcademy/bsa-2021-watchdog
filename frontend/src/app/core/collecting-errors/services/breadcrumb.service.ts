import { Injectable } from '@angular/core';
import { Breadcrumb } from '../models/breadcrumb';

@Injectable({
    providedIn: 'root'
})
export class BreadcrumbService {

    private static breadcrumbs = [] as Breadcrumb[];

    addBreadcrumb(item: Breadcrumb) {
        BreadcrumbService.breadcrumbs = BreadcrumbService.breadcrumbs.concat(item);
    }

    getBreadcrumbs() {
        return BreadcrumbService.breadcrumbs.concat();
    }

    getBreadcrumbsAndClear() {
        const breadcrumbs = BreadcrumbService.breadcrumbs;
        BreadcrumbService.breadcrumbs = [];
        return breadcrumbs;
    }

    clear() {
        BreadcrumbService.breadcrumbs = [];
    }
}
