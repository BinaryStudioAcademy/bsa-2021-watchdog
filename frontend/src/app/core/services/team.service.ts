import { Injectable } from '@angular/core';
import {HttpInternalService} from "@core/services/http-internal.service";
import {Observable} from "rxjs";
import { Team} from "@shared/models/team/team";
import {HttpResponse} from "@angular/common/http";

@Injectable({ providedIn: 'root' })
export class TeamService {
    public readonly routePrefix = '/team';

    constructor(private httpService: HttpInternalService) { }

    public getTeams(): Observable<HttpResponse<Team[]>> {
        return this.httpService.getFullRequest(`${this.routePrefix}`);
    }

    public getUserTeams(userId: number): Observable<HttpResponse<Team[]>> {
        return this.httpService.getFullRequest(`${this.routePrefix}/user/${userId}`);
    }

    public getLabel(teamName: string): string {
        const words = teamName.split(' ');

        let label = words[0].charAt(0);

        if(words.length > 1) {
            label += words[words.length - 1].charAt(0);
        }

        return label.toUpperCase();
    }
}
