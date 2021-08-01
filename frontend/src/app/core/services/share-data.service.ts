import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Dashboard } from '@shared/models/dashboard/Dashboard';

@Injectable({ providedIn: 'root' })
export class DataService {
    private messageSource = new BehaviorSubject<Dashboard>({} as Dashboard);
    currentMessage = this.messageSource.asObservable();

    constructor() { }

    changeMessage(dashboard: Dashboard) {
        this.messageSource.next(dashboard);
    }
}
