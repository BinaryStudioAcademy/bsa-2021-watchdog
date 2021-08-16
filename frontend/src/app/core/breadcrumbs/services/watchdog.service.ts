import { Injectable } from '@angular/core';
import { Breadcrumb } from '../models/breadcrumb';
import { ConsoleService } from './console.service';
import { TraceService } from './trace.service';

@Injectable({
    providedIn: 'root'
})
export class WatchdogService {
    private subscribeFunc:  (breadcrumb: Breadcrumb) => void = breadcrumb => {
        this.breadCrumbs = this.breadCrumbs.concat(breadcrumb);
        if (this.breadCrumbs.length >= 10)
        {
            console.table(this.breadCrumbs); 
            this.breadCrumbs = [];
        }
            
    }

    public breadCrumbs = [] as Breadcrumb[];
    constructor(
        private traceService: TraceService,
        private consoleService: ConsoleService
    ) {
        traceService.event$.subscribe(this.subscribeFunc);
        consoleService.event$.subscribe(this.subscribeFunc);
    }
}
