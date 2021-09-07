import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrelloBoard } from '@shared/models/trello/trello-board';
import { Observable, Subject } from 'rxjs';
import { authorizeIntegration } from './dialogs/auth-trello.dialog';

@Injectable({
    providedIn: 'root'
})
export class TrelloService {
    trelloToken: Subject<string | null> = new Subject<string | null>();
    apiKey = '54419603da6616388f1256beedc53731';
    constructor(private httpClient: HttpClient) {

    }

    getToken(): Observable<string | null> {
        this.authorizeTrello();
        return this.trelloToken.asObservable();
    }

    setTrelloToken(token: string) {
        this.trelloToken.next(token);
    }

    getBoards(token: string) {
        return this.httpClient.get<TrelloBoard[]>(`https://api.trello.com/1/members/me/boards?key=${this.apiKey}&token=${token}`);
    }

    private authorizeTrello() {
        const api = '54419603da6616388f1256beedc53731';
        authorizeIntegration(api, token => {
            this.setTrelloToken(token);
        });
    }
}
