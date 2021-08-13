import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@env/environment';
import { HttpInternalService } from './http-internal.service';

@Injectable({ providedIn: 'root' })
export class CollectorHttpService extends HttpInternalService {
    protected baseUrl = environment.collectorUrl;

    constructor(protected http: HttpClient) {
        super(http, environment.collectorUrl);
    }
}
