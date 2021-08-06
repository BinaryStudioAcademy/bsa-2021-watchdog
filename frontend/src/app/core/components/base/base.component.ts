import { Component, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
    selector: 'app-base',
    template: '',
})
export class BaseComponent implements OnDestroy {
    protected destroyed$ = new Subject<void>();

    readonly untilThis = <T>(source: Observable<T>) =>
        source.pipe(takeUntil(this.destroyed$));

    ngOnDestroy() {
        this.destroyed$.next();
        this.destroyed$.complete();
    }
}
