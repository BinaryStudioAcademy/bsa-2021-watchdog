import { Component } from '@angular/core';

@Component({
    selector: 'app-landing-content',
    templateUrl: './landing-content.component.html',
    styleUrls: ['./landing-content.component.sass']
})
export class LandingContentComponent {
    data = {
        title: 'Actionable insights, right down to code level',
        content: [
            {
                title: 'Dashboards',
                text: 'Your single pane of glass for monitoring the health of your software, '
                    + 'dashboards visualize critical error and performance data in a single, highly customizable source of truth. '
                    + 'You can easy track data that you need by creating a tiles with charts and tables'
            },
            {
                title: 'Trail of events - Breadcrumbs',
                text: 'Breadcrumbs make application development a little easier '
                    + 'by showing you the trails of events that lead to the errors.'
            },
            {
                title: 'Error Monitoring & Crash Reporting',
                text: 'Ship better quality software, faster. '
                    + 'Get code-level insights into the health of your application in real-time '
                    + 'and start fixing the errors impacting your end-users experience.'
            },
            {
                title: 'StackOverflow Integration',
                text: 'You can easily find information about errors on the StackOverflow service,'
                    + ' which will save you a lot of time looking for solutions to your problem.'
            },
            {
                title: 'Issues Assignee',
                text: 'The software development cycle can be riddled with ambiguity. '
                    + 'Issue Owners put control back in the hands of developers to fix what’s broken in their code.'
            },
        ]
    };
}
