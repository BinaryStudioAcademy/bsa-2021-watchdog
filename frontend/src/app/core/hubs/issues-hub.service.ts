import { AuthenticationService } from '@core/services/authentication.service';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { Injectable } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { Subject, Subscription } from 'rxjs';
import { SignalRHubFactoryService } from './signalr-hub-factory.service';
import { first } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class IssuesHubService {
    readonly hubUrl = 'issuesHub';
    private isStarted: boolean = false;
    private hubConnection: HubConnection;

    readonly messages = new Subject<IssueMessage>();
    private subscriptions: Subscription[] = [];

    constructor(
        private hubFactory: SignalRHubFactoryService,
        private authService: AuthenticationService,
    ) { }

    async start() {
        if (this.isStarted) await this.stop();

        const member = await this.authService.getMember()
            .pipe(first())
            .toPromise();

        this.hubConnection = this.hubFactory.createHub(
            `${this.hubUrl}?memberId=${member.id}`
        );

        await this.init();
    }

    listenMessages(action: (msg: IssueMessage) => void) {
        this.subscriptions.push(this.messages.subscribe({ next: action }));
    }

    async stop() {
        await this.hubConnection.stop();
        this.subscriptions.forEach(s => s.unsubscribe());
        this.isStarted = false;
    }

    private async init() {
        try {
            await this.hubConnection.start();
            console.info('IssuesHub successfully started.');
            this.isStarted = true;
            this.hubConnection.on('SendIssue', (message: IssueMessage) => {
                this.messages.next(message);
            });
        } catch {
            console.info('IssuesHub start failed.');
        }
    }
}
