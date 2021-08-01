import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Dashboard } from '@shared/models/dashboard/Dashboard';

@Injectable({ providedIn: 'root' })
export class DataService {
    private messageSource = new Subject<Dashboard>();
    currentMessage = this.messageSource.asObservable();

    changeMessage(dashboard: Dashboard) {
        this.messageSource.next(dashboard);
    }
}
