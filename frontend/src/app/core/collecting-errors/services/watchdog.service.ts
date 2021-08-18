import { Injectable } from '@angular/core';
import { ErrorInterceptor } from '../interceptors/error.interceptor';
import { AjaxBreadcrumb } from '../models/ajax-breadcrumb';
import { Breadcrumb } from '../models/breadcrumb';
import { BaseService } from './base.service';
import { BreadcrumbService } from './breadcrumb.service';
import { ClickService } from './click.service';
import { ConsoleService } from './console.service';
import { TraceService } from './trace.service';

@Injectable({
    providedIn: 'root'
})
export class WatchdogService {
    private subscribeFunc:  (breadcrumb: Breadcrumb) => void = breadcrumb => {
        this.breadcrumbService.addBreadcrumb(breadcrumb);
        const breadcrumbs = this.breadcrumbService.getBreadcrumbs();
        if (breadcrumbs.length >= 10)
        {
            this.breadcrumbService.clear()
            console.table(breadcrumbs); 
        }
            
    }
    constructor(
        private traceService: TraceService,
        private consoleService: ConsoleService,
        private errorService: ErrorInterceptor,
        private clickService: ClickService,
        private breadcrumbService: BreadcrumbService,
    ) {
        BaseService.event$.subscribe(this.subscribeFunc);
    }
}
