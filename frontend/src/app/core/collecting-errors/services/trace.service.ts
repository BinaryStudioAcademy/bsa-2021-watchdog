import { Injectable, OnDestroy } from '@angular/core';
import { NavigationStart, Router, Event, NavigationEnd } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { filter, tap } from 'rxjs/operators';
import { TraceBreadcrumb } from '../models/trace-breadcrumb';
import { BaseService } from './base.service';

@Injectable({ providedIn: 'root' })
export class TraceService extends BaseService implements OnDestroy {
    private subscription: Subscription = new Subscription();

    constructor(private readonly router: Router) {
        super();
        this.subscription.add(this.navStart$.subscribe());
        this.subscription.add(this.navEnd$.subscribe());
    }
    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }

    private startUrl: string;

    public navStart$: Observable<Event> = this.router.events.pipe(
        filter(event => event instanceof NavigationStart),
        tap(() => {
            this.startUrl = this.router.url;
        }),
    );

    public navEnd$: Observable<Event> = this.router.events.pipe(
        filter(event => event instanceof NavigationEnd),
        tap(event => {
            this.eventSource.next(new TraceBreadcrumb(this.startUrl, (event as NavigationEnd).urlAfterRedirects));
        }),
    );
}
