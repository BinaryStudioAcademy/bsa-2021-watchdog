import { Injectable } from '@angular/core';
import { Platform } from '@shared/models/platforms/platform';
import { Observable } from 'rxjs';
import { HttpInternalService } from './http-internal.service';

@Injectable({ providedIn: 'root' })
export class PlatformService {
    public readonly routePrefix = '/platforms';

    constructor(private httpService: HttpInternalService) { }

    public getPlatforms(): Observable<Platform[]> {
        return this.httpService.getRequest(`${this.routePrefix}`);
    }
}
