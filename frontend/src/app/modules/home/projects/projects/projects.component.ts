import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from '@shared/models/projects/project';
import { FakeData } from '@modules/home/projects/fake-data';

@Component({
    selector: 'app-projects',
    templateUrl: './projects.component.html',
    styleUrls: ['./projects.component.sass'],
    providers: [FakeData]
})
export class ProjectsComponent implements OnInit {
    public projects: Project[];

    constructor(private router: Router,
        private fakeData: FakeData) {
    }

    ngOnInit(): void {
        this.initFakeData();
    }

    initFakeData() {
        this.projects = this.fakeData.fakeProjects;
    }

    public onClickCreateProject(): void {
        this.router.navigateByUrl(`${this.router.url}/create`).then(r => r);
    }
}
