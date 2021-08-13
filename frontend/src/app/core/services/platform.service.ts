import { Injectable } from '@angular/core';
import { Platform } from '@shared/models/platforms/platform';
import { Observable } from 'rxjs';
import { CoreHttpService } from './core-http.service';

@Injectable({ providedIn: 'root' })
export class PlatformService {
    public readonly routePrefix = '/platforms';

    constructor(private httpService: CoreHttpService) { }

    public getPlatforms(): Observable<Platform[]> {
        return this.httpService.getRequest(`${this.routePrefix}`);
    }
}
