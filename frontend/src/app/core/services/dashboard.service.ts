import { Injectable } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { HttpInternalService } from './http-internal.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class DashboardService {

    constructor(private http: HttpInternalService) { }

    public getIcons(): string[] {
        return ['pi-chart-bar', 'pi-chart-line'];
    }

    public getAll(): Observable<HttpResponse<Dashboard[]>> {
        return this.http.getFullRequest<Dashboard[]>(`${environment.coreUrl}/dashboard`);
    }

    public get(id: string): Observable<HttpResponse<Dashboard>> {
        return this.http.getFullRequest<Dashboard>(`${environment.coreUrl}/dashboard/${id}`);
    }

    public addDashboard(newDashboard: NewDashboard): Observable<HttpResponse<Dashboard>> {
        return this.http.postFullRequest<Dashboard>(`${environment.coreUrl}/dashboard`, newDashboard);
    }

    public deleteDashboard(id: number) {
        return this.http.deleteFullRequest<number>(`${environment.coreUrl}/dashboard/${id}`);
    }

    public updateDashboard(updateDashboard: UpdateDashboard): Observable<HttpResponse<Dashboard>> {
        return this.http.putFullRequest<Dashboard>(`${environment.coreUrl}/dashboard/${updateDashboard.id}`, updateDashboard);
    }
}
