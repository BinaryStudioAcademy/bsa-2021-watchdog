import {Component, Input, OnInit} from '@angular/core';
import {Team} from "@shared/models/team/team";

@Component({
  selector: 'app-user-teams',
  templateUrl: './user-teams.component.html',
  styleUrls: ['../teams.component.sass']
})
export class UserTeamsComponent implements OnInit {
    @Input() teams: Team[];

    constructor() { }

    ngOnInit(): void {

    }
}
