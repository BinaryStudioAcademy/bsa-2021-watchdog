import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing-content',
  templateUrl: './landing-content.component.html',
  styleUrls: ['./landing-content.component.sass']
})
export class LandingContentComponent implements OnInit {

  data = {
    title: 'Actionable insights, right down to code level',
    content: [
      {
        title: 'Real User Monitoring',
        text: 'Quickly identify and resolve front-end performance issues impacting real users. Understand exactly how your application performed for every user session and page load.'
      },
      {
        title: 'Application Performance Monitoring',
        text: 'Actionable APM software to help you pinpoint problems and resolve issues faster. Get the answers you need to deliver exceptional customer experiences.'
      },
      {
        title: 'Dashboards',
        text: 'Your single pane of glass for monitoring the health of your software, dashboards visualize critical error and performance data in a single, highly customizable source of truth.'
      },
      {
        title: 'Error & Crash Reporting',
        text: 'Control the chaos around solving software bugs. Quickly diagnose problems in your codebase, enjoy faster development cycles and make sure users are having error free experiences.'
      },
      {
        title: 'Deployments Tracking',
        text: 'Raygun’s advanced deployment tracking system keeps a watchful eye over every deployment. Instantly know when something goes wrong and see exactly how to fix it.'
      },
      {
        title: 'Customer Experience Monitoring',
        text: "Customers are why we create software. See them all, what they do, and how they're impacted by errors, crashes and performance issues when using your software applications."
      },
    ]
  }
  constructor() { }

  ngOnInit(): void {
  }

}
