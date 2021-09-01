import { Component, Input, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';

@Component({
    selector: 'app-project-analytics',
    templateUrl: './project-analytics.component.html',
    styleUrls: ['./project-analytics.component.sass']
})
export class ProjectAnalyticsComponent implements OnInit {
    @Input() project: Project;

    constructor() {

    }

    ngOnInit(): void {
        console.log(this.project.name);
    }
}
