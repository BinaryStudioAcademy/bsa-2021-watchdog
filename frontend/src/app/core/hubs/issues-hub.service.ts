import { IssueMessage } from '@shared/models/issue/issue-message';
import { Injectable } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { BehaviorSubject, Subject, Subscription } from 'rxjs';
import { SignalRHubFactoryService } from './signalr-hub-factory.service';

@Injectable({
    providedIn: 'root'
})
export class IssuesHubService {
    readonly hubUrl = 'issuesHub';
    private hubConnection: HubConnection;

    readonly messages = new Subject<IssueMessage>();
    readonly projects = new BehaviorSubject<number[]>([]);
    private subscriptions: Subscription[] = [];

    constructor(
        private hubFactory: SignalRHubFactoryService
    ) { }

    async start() {
        this.hubConnection = this.hubFactory.createHub(this.hubUrl);
        await this.init();
    }

    listenMessages(action: (msg: IssueMessage) => void) {
        this.subscriptions.push(this.messages.subscribe({ next: action }));
    }

    async stop() {
        await this.hubConnection.stop();
        this.subscriptions.forEach(s => s.unsubscribe());
    }

    private async init() {
        await this.hubConnection.start()
            .then(() => {
                console.info(`"${this.hubFactory}" successfully started.`);
                this.subscriptions = [
                    this.projects.subscribe(ids => {
                        this.hubConnection.send('SetProjects', ids);
                    }), ...this.subscriptions
                ];
            })
            .catch(() => console.info(`"${this.hubFactory}" failed.`));

        this.hubConnection.on('SendIssue', (message: IssueMessage) => {
            this.messages.next(message);
        });
    }
}
