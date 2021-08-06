import { Injectable } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { environment } from 'src/environments/environment';
import { HttpInternalService } from './http-internal.service';

@Injectable({ providedIn: 'root' })
export class DashboardService {
    constructor(private httpService: HttpInternalService) { }

    public getIcons(): string[] {
        return ['pi-chart-bar', 'pi-chart-line'];
    }

    public getAll(): Observable<HttpResponse<Dashboard[]>> {
        return this.httpService.getFullRequest<Dashboard[]>(`${environment.coreUrl}/dashboard`);
    }

    public get(id: string): Observable<HttpResponse<Dashboard>> {
        return this.httpService.getFullRequest<Dashboard>(`${environment.coreUrl}/dashboard/${id}`);
    }

    public addDashboard(newDashboard: NewDashboard): Observable<HttpResponse<Dashboard>> {
        return this.httpService.postFullRequest<Dashboard>(`${environment.coreUrl}/dashboard`, newDashboard);
    }

    public deleteDashboard(id: number) {
        return this.httpService.deleteFullRequest<number>(`${environment.coreUrl}/dashboard/${id}`);
    }

    public updateDashboard(updateDashboard: UpdateDashboard): Observable<HttpResponse<Dashboard>> {
        return this.httpService.putFullRequest<Dashboard>(`${environment.coreUrl}/dashboard/${updateDashboard.id}`, updateDashboard);
    }
}
