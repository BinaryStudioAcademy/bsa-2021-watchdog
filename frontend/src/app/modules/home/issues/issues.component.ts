import { Component, OnInit } from '@angular/core';
import { Issue } from '@shared/models/issue/issue';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent implements OnInit {
    public countNew: { [type: string]: number };

    public issues: Issue[];

    public selectedIssues: Issue[] = [];

    ngOnInit(): void {
        this.setAllFieldsTemp();
    }

    selectAll(event: { checked: boolean, originalEvent: Event }) {
        this.disableParentEvent(event);
        if (event.checked) {
            this.selectedIssues = Object.assign([], this.issues);
        } else {
            this.selectedIssues = [];
        }
    }

    disableParentEvent(event: { originalEvent: Event }) { // to disable sorting
        event.originalEvent.stopPropagation();
    }

    private setAllFieldsTemp() {
        this.countNew = {
            all: 3,
            secondtype: 1,
            thirdtype: 0
        };

        this.issues = [];

        for (let i = 1; i <= 25; i += 1) {
            const issue = {
                name: `TypeError${i}`,
                description: "Object [object object] has no method 'updateForm'",
                isNew: i % 3 === 0,
                projectTag: 'BSA-2021-1',
                createdAt: new Date(Date.now() - (i <= 14 ? ((i - 1) * 30 * 60 * 1000) : (i * 30 * 60 * 1000 * 10))), //2 min
                events: i,
                users: i
            };
            this.issues.push(issue);
        }
    }
}
