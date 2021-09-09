import { Component, Input } from '@angular/core';
import { IssueSolutionItem } from '@shared/models/issue/issue-solution/issue-solution-item';

@Component({
    selector: 'app-solution',
    templateUrl: './solution.component.html',
    styleUrls: ['./solution.component.sass'],
})
export class SolutionComponent {
    @Input() solutionItem: IssueSolutionItem;
}
