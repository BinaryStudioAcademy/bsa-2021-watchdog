import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { environment } from 'src/environments/environment';
import { HttpInternalService } from './http-internal.service';

@Injectable({ providedIn: 'root' })
export class DashboardService {
    constructor(private httpService: HttpInternalService) { }

    public getAllByOrganization(id: number): Observable<Dashboard[]> {
        return this.httpService.getRequest<Dashboard[]>(`${environment.coreUrl}/dashboard/organization/${id}`);
    }

    public get(id: string): Observable<Dashboard> {
        return this.httpService.getRequest<Dashboard>(`${environment.coreUrl}/dashboard/${id}`);
    }

    public addDashboard(newDashboard: NewDashboard): Observable<Dashboard> {
        return this.httpService.postRequest<Dashboard>(`${environment.coreUrl}/dashboard`, newDashboard);
    }

    public deleteDashboard(id: number) {
        return this.httpService.deleteFullRequest<number>(`${environment.coreUrl}/dashboard/${id}`);
    }

    public updateDashboard(updateDashboard: UpdateDashboard): Observable<Dashboard> {
        return this.httpService.putRequest<Dashboard>(`${environment.coreUrl}/dashboard`, updateDashboard);
    }
}
