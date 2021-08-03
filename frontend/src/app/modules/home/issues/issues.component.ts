import { Component, OnInit } from '@angular/core';
import { Option } from '@core/models/Option';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent implements OnInit {
    public countNew : {[type:string]: number}

    public sortedBy: Option;
    public sortedOptions: Option[];
    
    ngOnInit(): void {
        this.countNew = {
            'all': 3,
            'secondtype': 1,
            'thirdtype': 0
        }

        this.sortedOptions = [
            {
                name: 'Last Seen',
                code: 'last-seen'
            },
            {
                name: 'Newest',
                code: 'newest'
            }
        ]

        this.sortedBy = this.sortedOptions[0];

    }
}
