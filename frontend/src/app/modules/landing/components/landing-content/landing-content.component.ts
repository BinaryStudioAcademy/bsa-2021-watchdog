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
                + 'dashboards visualize critical error and performance data in a single, highly customizable source of truth.'
            },
            {
                title: 'Coming soon',
                text: 'There will be many more interesting features.'
            },
        ]
    };
}
