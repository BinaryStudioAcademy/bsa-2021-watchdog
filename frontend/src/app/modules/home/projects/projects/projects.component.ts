import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-projects',
    templateUrl: './projects.component.html',
    styleUrls: ['./projects.component.sass']
})
export class ProjectsComponent implements OnInit {
    public projects: { name: string }[]; // edit this

    constructor(private router: Router) {
    }
    ngOnInit(): void {
        // delete this
        this.projects = [{ name: 'FirstProject' }, { name: 'SecondProject' }, { name: 'ThirdProject' },
            { name: 'FirstProject' }, { name: 'SecondProject' }, { name: 'ThirdProject' },
            { name: 'FirstProject' }, { name: 'SecondProject' }, { name: 'ThirdProject' },
            { name: 'FirstProject' }, { name: 'SecondProject' }, { name: 'ThirdProject' },
            { name: 'FirstProject' }, { name: 'SecondProject' }, { name: 'ThirdProject' },
            { name: 'FirstProject' }, { name: 'SecondProject' }, { name: 'ThirdProject' }];
    }

    public onClickCreateProject(): void {
        console.log(this.router.url);
        this.router.navigateByUrl(`${this.router.url}/create-project`).then(r => r);
    }
}
