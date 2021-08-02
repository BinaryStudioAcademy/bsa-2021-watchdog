import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent implements OnInit {
    public countNew : {[type:string]: number}


    ngOnInit(): void {
        this.countNew = {
            'all': 3,
            'secondtype': 1,
            'thirdtype': 0
        }
    }
}
