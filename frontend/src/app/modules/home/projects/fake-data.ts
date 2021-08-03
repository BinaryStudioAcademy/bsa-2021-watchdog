import { Platform } from '@shared/models/projects/platform';
import { Project } from '@shared/models/projects/project';
import { Team } from '@shared/models/projects/team';

export class FakeData {
    public fakePlatforms: Platform[] = [
        {
            id: 1,
            avatarUrl: 'https://www.sentry.dev/_assets2/static/f3663bf3904adcea0d835bc0ed00a76e/5e011/dotnet.webp',
            name: 'dotnet',
            isServer: true,
            isDesktop: true
        },
        {
            id: 2,
            avatarUrl: 'https://www.sentry.dev/_assets2/static/d68867cb09825ed57929417741df8676/5e011/javascript.webp',
            name: 'javascript',
            isBrowser: true
        },
        {
            id: 3,
            avatarUrl: 'https://www.sentry.dev/_assets2/static/120f665e5d3d75607a9b9cb775c187f2/5e011/apple.webp',
            name: 'ios',
            isMobile: true,
            isDesktop: true
        },
        {
            id: 4,
            avatarUrl: 'https://www.sentry.dev/_assets2/static/b7c35c80f7bde7d4ef82b1447c47cfa2/5e011/python.webp',
            name: 'python',
            isServer: true,
            isDesktop: true
        }
    ];

    public fakeTeams: Team[] = [
        { id: 1, name: '#vitaliy-shatskiy' },
        { id: 2, name: '#binary-studio' },
        { id: 3, name: '#watch-dog' },
        { id: 4, name: '#binary-studio-academy' },
    ];

    public fakeProjects: Project[] = [
        {
            name: 'DotNet App',
            description: 'Cool DotNet App',
            id: 1,
            platform: this.fakePlatforms[0],
            team: this.fakeTeams[0]
        },
        {
            name: 'JavaScript App',
            description: 'Cool JavaScript App',
            id: 1,
            platform: this.fakePlatforms[1],
            team: this.fakeTeams[1]
        },
        {
            name: 'IOS App',
            description: 'Cool IOS App',
            id: 2,
            platform: this.fakePlatforms[2],
            team: this.fakeTeams[2]
        },
        {
            name: 'Python App',
            description: 'Cool Python App',
            id: 3,
            platform: this.fakePlatforms[3],
            team: this.fakeTeams[3]
        },
    ];

    public fakeAlertCategories = [
        'I\'ll create my own alerts later',
        'Alert me on every new issue',
        'When there are more than'];

    public fakeAlertTypes = [
        'occurrences of',
        'users affected by'];

    public fakeAlertTimeIntervals = [
        'one minute',
        '5 minutes',
        '15 minutes',
        'one hour',
        'one day',
        'one week',
        '30 days'];
}
