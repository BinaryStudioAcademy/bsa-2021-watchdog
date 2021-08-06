import { Injectable } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { environment } from 'src/environments/environment';
import { HttpInternalService } from './http-internal.service';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class DashboardService {
    constructor(private httpService: HttpInternalService) { }

    public getIcons(): string[] {
        return ['pi-chart-bar', 'pi-chart-line'];
    }

    public getAll(): Observable<Dashboard[]> {
        return this.httpService.getRequest<Dashboard[]>(`${environment.coreUrl}/dashboard/organization/1`);
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
