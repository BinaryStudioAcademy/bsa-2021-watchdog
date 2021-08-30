import { AuthenticationService } from '@core/services/authentication.service';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import {
    HttpTransportType,
    HubConnectionBuilder,
    LogLevel,
} from '@microsoft/signalr';

@Injectable({
    providedIn: 'root',
})
export class SignalRHubFactoryService {
    constructor(private authService: AuthenticationService) { }

    createHub(hubUrl: string) {
        const hub = this.buildHub(hubUrl);
        return hub;
    }

    private buildHub(hubUrl: string) {
        return new HubConnectionBuilder()
            .withUrl(this.buildUrl(hubUrl), {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets,
                accessTokenFactory: () => this.authService.getJwToken().toPromise()
            })
            .configureLogging(LogLevel.Information)
            .build();
    }

    private buildUrl(hubUrl: string) {
        return `${environment.notifierUrl}/${hubUrl}`;
    }
}
