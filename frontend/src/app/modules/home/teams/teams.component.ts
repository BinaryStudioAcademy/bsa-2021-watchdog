import { Component, OnInit } from '@angular/core';
import { Team } from '@shared/models/team/team';

@Component({
    selector: 'app-teams',
    templateUrl: './teams.component.html',
    styleUrls: ['./teams.component.sass']
})
export class TeamsComponent implements OnInit {
    teams: Team[];

    constructor() { }

    ngOnInit(): void {
    }
}
