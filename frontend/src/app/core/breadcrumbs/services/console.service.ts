import { Injectable } from '@angular/core';
import { Breadcrumb, BreadcrumbLevel } from '../models/breadcrumb';
import { ConsoleBreadcrumb } from '../models/console-breadcrumb';
import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root'
})
export class ConsoleService extends BaseService{
    private log: (...data: any[]) => void;
    private debug: (...data: any[]) => void;
    private info: (...data: any[]) => void;
    private warn: (...data: any[]) => void;
    private error: (...data: any[]) => void;

    constructor() {
        super();
        this.copyFunctions();
        this.rewriteFunctions();
    }

    private copyFunctions() {
        this.log = console.log;
        this.debug = console.debug;

        this.info = console.info;
        this.warn = console.warn;
        this.error = console.error;
    }

    private rewriteFunctions() {
        console.log = (...data: any[]) => {
            this.log(...data);
            this.send('debug', data);
        };
        console.debug = (...data: any[]) => {
            this.debug(...data);
            this.send('debug', data);
        };
        console.info = (...data: any[]) => {
            this.info(...data);
            this.send('info', data);
        };
        console.warn = (...data: any[]) => {
            this.warn(...data);
            this.send('warning', data);
        };
        console.error = (...data: any[]) => {
            this.error(...data);
            this.send('error', data);
        };
    }

    private send(level: BreadcrumbLevel, data: any[]) {
        this.eventSource.next(new ConsoleBreadcrumb(level, data))
    }
}
