import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing-platforms',
  templateUrl: './landing-platforms.component.html',
  styleUrls: ['./landing-platforms.component.sass']
})
export class LandingPlatformsComponent implements OnInit {

  urls = [
    'https://www.sentry.dev/_assets2/static/6b716479ae5833968c4c747bc042e4e8/5e011/android.webp',
    'https://www.sentry.dev/_assets2/static/120f665e5d3d75607a9b9cb775c187f2/5e011/apple.webp',
    'https://www.sentry.dev/_assets2/static/ba17d68036d1cbb03ac9ba2fe09e8a8f/5e011/django.webp',
    'https://www.sentry.dev/_assets2/static/f3663bf3904adcea0d835bc0ed00a76e/5e011/dotnet.webp',
    'https://www.sentry.dev/_assets2/static/b0f1a908d726309e5566be8202eb04ec/5e011/go.webp',
    'https://www.sentry.dev/_assets2/static/d68867cb09825ed57929417741df8676/5e011/javascript.webp',
    'https://www.sentry.dev/_assets2/static/555b67576979c86143ae36e6ec18c01c/5e011/laravel.webp',
    'https://www.sentry.dev/_assets2/static/5f9a78ba0acc7e9b1f88ceb7724e11a9/5e011/php.webp',
    'https://www.sentry.dev/_assets2/static/b7c35c80f7bde7d4ef82b1447c47cfa2/5e011/python.webp',
    'https://www.sentry.dev/_assets2/static/f901247d2a4721c8ceee1fbe3d3fa31b/5e011/flutter.webp',
    'https://www.sentry.dev/_assets2/static/24ef7069eeae638c5b3759fb927cd8ec/5e011/react.webp',
    'https://www.sentry.dev/_assets2/static/67dbd2f248ef6cee1b477d68f505357c/5e011/ruby.webp',
    'https://www.sentry.dev/_assets2/static/b0e711dca08f67513b0a3891d25b2b20/5e011/github.webp',
    'https://www.sentry.dev/_assets2/static/c3e15e7003e1d11defbaf6337293db61/58542/gitlab.webp',
    'https://www.sentry.dev/_assets2/static/0e2fd5efe5eb6a313910e6fca7c703c3/5e011/jira.webp',
    'https://www.sentry.dev/_assets2/static/579bd2773227860819ef86d51d5c5767/5e011/rookout.webp',
    'https://www.sentry.dev/_assets2/static/82eefc1961e6a99f8d061458f5b30257/5e011/bitbucket.webp',
    'https://www.sentry.dev/_assets2/static/e697e78c62b9c74b547ee29a53260661/5e011/datadog.webp',
    'https://www.sentry.dev/_assets2/static/b1d99047b9207dce30140079623d522d/5e011/heroku.webp',
    'https://www.sentry.dev/_assets2/static/dd92727260a877e38ae6716c0f5a7f7c/5e011/slack.webp',
    'https://www.sentry.dev/_assets2/static/48245060e178edb2bbbae773106ff75c/5e011/pagerduty.webp',
    'https://www.sentry.dev/_assets2/static/f7498b91ade0730ea7af0f1a16a8d7ca/5e011/segment.webp',
    'https://www.sentry.dev/_assets2/static/ceab725059686dc42f8b8677cb714a3d/5e011/trello.webp'

  ]
  constructor() { }

  ngOnInit(): void {
  }

}
