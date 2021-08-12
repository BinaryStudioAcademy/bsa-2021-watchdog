import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@env/environment';
import { HttpInternalService } from './http-internal.service';

@Injectable({ providedIn: 'root' })
export class CoreHttpService extends HttpInternalService {
    constructor(protected http: HttpClient) {
        super(http, environment.coreUrl);
    }
}
