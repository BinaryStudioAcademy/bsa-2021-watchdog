import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ShareDataService<T> {
    private messageSource = new Subject<T>();
    currentMessage = this.messageSource.asObservable();

    changeMessage(message: T) {
        this.messageSource.next(message);
    }
}
