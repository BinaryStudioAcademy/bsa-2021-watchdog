import { Team } from '@shared/models/teams/team';
import { IssueTableItem } from '@shared/models/issue/issue-table-item';
import { ToastNotificationService } from './toast-notification.service';
import { TrelloCard } from '@shared/models/trello/trello-card';
import { TrelloList } from '@shared/models/trello/trello-list';
import { AuthenticationService } from '@core/services/authentication.service';
import { TrelloMember } from '@shared/models/trello/trello-member';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrelloBoard } from '@shared/models/trello/trello-board';
import { Observable, of, Subject } from 'rxjs';
import { authorizeIntegration } from './dialogs/auth-trello.dialog';
import { first, switchMap, take } from 'rxjs/operators';
import { User } from '@shared/models/user/user';

@Injectable({
    providedIn: 'root'
})
export class TrelloService {
    private trelloTokenFromAuthorize: Subject<string | null> = new Subject<string | null>();
    private trelloToken: string;
    private apiKey = '54419603da6616388f1256beedc53731';
    private apiUrl = 'https://api.trello.com/1';

    constructor(
        private httpClient: HttpClient,
        private authService: AuthenticationService,
        private toastService: ToastNotificationService,
    ) {
        this.authService.getOrganization().subscribe(org => {
            this.setTrelloToken(org.trelloToken);
        });
        this.trelloTokenFromAuthorize.subscribe(t => {
            this.setTrelloToken(t);
        });
    }

    getToken(): Observable<string | null> {
        if (!this.trelloToken || this.trelloToken === null) {
            return this.authService.getOrganization().pipe(
                switchMap(organization => {
                    if (!organization.trelloToken && organization.trelloIntegration) {
                        this.authorizeTrello(() => {});
                        return this.trelloTokenFromAuthorize.asObservable();
                    }
                    this.setTrelloToken(organization.trelloToken);
                    return of(this.trelloToken);
                })
            );
        }
        return of(this.trelloToken);
    }

    searchMembers(query: string) {
        if (!query) return of(null);
        return this.httpClient.get<TrelloMember[]>(`${this.apiUrl}/search/members/?query=${query}`);
    }

    clearToken() {
        this.trelloToken = '';
    }

    getBoardsByCurrentIntegration() {
        return this.getToken().pipe(
            switchMap(() => this.httpClient.get<TrelloBoard[]>(
                `${this.apiUrl}/members/me/boards`, { params: this.getParams() }
            ))
        );
    }

    getMember(id: string) {
        return this.httpClient.get<TrelloMember>(`${this.apiUrl}/members/${id}`);
    }

    getMemberByToken(token: string) {
        return this.httpClient.get<TrelloMember>(`${this.apiUrl}/tokens/${token}/member`, {params: this.getParams()});
    }

    async addIssueToBoardWithAssignee(issue: IssueTableItem, users: User[] = [], teams: Team[] = []) {
        await this.getToken().pipe(first()).toPromise();
        const usersArray = users || [];
        const teamsArray = teams || [];

        const projectList = await this.getProjectList(issue.projectName);
        const requiredCard = await this.getCardInProjectList(projectList.id, issue);

        let usersToSend = usersArray;
        if (teams.length) {
            usersToSend = usersToSend.concat(teamsArray.map(t => t.members.map(m => m.user)).reduce((a, b) => a.concat(b)));
        }

        const distinctedUsers = usersToSend.filter((value, index, self) => self.findIndex(selfUser => selfUser.id === value.id) === index);

        await this.addUsersToCard(requiredCard.id, distinctedUsers);
    }

    private async getProjectList(projectName: string) {
        const lists = await this.getBoardLists().pipe(first()).toPromise();
        let projectList = lists.find(list => list.name === this.getProjectListName(projectName));

        if (!projectList) {
            projectList = await this.createListInBoard(this.getProjectListName(projectName)).pipe(first()).toPromise();
        }
        return projectList;
    }

    private async getCardInProjectList(projectListId: string, issue: IssueTableItem) {
        const cards = await this.getListsCards(projectListId).pipe(first()).toPromise();
        const { name, desc } = this.getIssueCardInfo(issue);
        let requiredCard = cards.find(c => c.name === name && c.desc === desc);
        if (!requiredCard) {
            requiredCard = await this.addCardIssues(name, desc, projectListId).pipe(first()).toPromise();
        }
        return requiredCard;
    }

    private async addUsersToCard(cardId: string, users: User[]) {
        await this.updateCard(cardId, '').pipe(first()).toPromise();

        let hasBadUsers = false;
        users.forEach(async u => {
            if (!u.trelloUserId) {
                hasBadUsers = true;
                return;
            }
            await this.assigneeMemberToCard(u.trelloUserId, cardId).pipe(take(users.length)).toPromise()
                .catch(() => {
                    hasBadUsers = true;
                });
        });

        if (hasBadUsers) {
            this.toastService.warning('Some of members were not added to card.'
                    + ' Check their assignment to username in user profile!');
        }
    }

    private createListInBoard(name: string) {
        return this.authService.getOrganization()
            .pipe(switchMap(org => this.httpClient.post<TrelloList>(
                `${this.apiUrl}/lists`,
                null,
                { params: this.getParams().set('name', name).set('idBoard', org.trelloBoard) }
            )));
    }

    private assigneeMemberToCard(memberId: string, cardId: string) {
        return this.httpClient.post(
            `${this.apiUrl}/cards/${cardId}/idMembers`,
            null,
            { params: this.getParams().set('value', memberId) }
        );
    }

    private addCardIssues(name: string, desc: string, listId: string): Observable<TrelloCard> {
        return this.httpClient.post<TrelloCard>(
            `${this.apiUrl}/cards`,
            null,
            {
                params: this.getParams().set('name', name)
                    .set('idList', listId).set('desc', desc)
            }
        );
    }

    private getBoardLists() {
        return this.authService.getOrganization()
            .pipe(switchMap(org => this.httpClient.get<TrelloList[]>(
                `${this.apiUrl}/boards/${org.trelloBoard}/lists`,
                { params: this.getParams() }
            )));
    }

    private getListsCards(listId: string) {
        return this.httpClient.get<TrelloCard[]>(
            `${this.apiUrl}/lists/${listId}/cards`,
            { params: this.getParams() }
        );
    }

    private updateCard(cardId: string, memberIds: string) {
        return this.httpClient.put<TrelloCard>(
            `${this.apiUrl}/cards/${cardId}`,
            null,
            { params: this.getParams().set('idMembers', memberIds) }
        );
    }

    private addMemberToCurrentBoard(memberId: string) {
        return this.authService.getOrganization()
            .pipe(switchMap(org => this.httpClient.put(
                `${this.apiUrl}/boards/${org.trelloBoard}/members/${memberId}`,
                { params: this.getParams() }
            )));
    }

    private getParams() {
        const params = new HttpParams();
        return params.set('key', this.apiKey)
            .set('token', this.trelloToken);
    }

    private setTrelloToken(token: string) {
        this.trelloToken = token;
    }

    authorizeTrello(afterAuthorize?: Function, badAuthorize?: Function) {
        authorizeIntegration(this.apiKey, token => {
            this.trelloTokenFromAuthorize.next(token);

            if (token !== null) afterAuthorize();
            else badAuthorize();
        });
    }

    authorizeTrelloUser(afterAuthorize?: (token: string) => void) {
        authorizeIntegration(this.apiKey, token => {
            if (token !== null) afterAuthorize(token);
        });
    }

    private getIssueCardInfo(issue: IssueTableItem): { name: string, desc: string } {
        const name = issue.errorClass;
        const desc = issue.errorMessage;
        return { name, desc };
    }

    private getProjectListName(projectName: string) {
        return `ToDo ${projectName}`;
    }
}
