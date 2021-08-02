import {Component, Input, OnInit} from '@angular/core';
import {Team} from "@shared/models/team/team";
import {TeamService} from "@core/services/team.service";

@Component({
    selector: 'app-other-teams',
    templateUrl: './other-teams.component.html',
    styleUrls: ['../teams.component.sass']
})
export class OtherTeamsComponent implements OnInit {
    @Input() teams: Team[];
    labels: string[];

    constructor(public teamService: TeamService) { }

    ngOnInit(): void {

    }
}
