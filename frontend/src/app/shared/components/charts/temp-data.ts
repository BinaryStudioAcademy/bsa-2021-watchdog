import { MultiChart } from '@shared/models/charts/multi-chart';
import { SingleChart } from '@shared/models/charts/single-chart';

export const single: SingleChart[] = [{
    name: 'Issue 1',
    value: 5
},
{
    name: 'Issue 2',
    value: 1
}, {
    name: 'Issue 3',
    value: 3
},
{
    name: 'Issue 4',
    value: 2
}, {
    name: 'Issue 5',
    value: 8
},
{
    name: 'Issue 6',
    value: 66
},
{
    name: 'Issue 7',
    value: 11
}];

export const multi: MultiChart[] = [
    {
        name: 'Issue 1',
        series: [
            {
                name: '2 days ago',
                value: 62
            },
            {
                name: '1 day ago',
                value: 73
            },
            {
                name: 'now',
                value: 89
            }
        ]
    },

    {
        name: 'Issue 2',
        series: [
            {
                name: '2 days ago',
                value: 25
            },
            {
                name: '1 day ago',
                value: 30
            },
            {
                name: 'now',
                value: 31
            }
        ]
    },

    {
        name: 'Issue 3',
        series: [
            {
                name: '2 days ago',
                value: 58
            },
            {
                name: '1 day ago',
                value: 50
            },
            {
                name: 'now',
                value: 58
            }
        ]
    },
    {
        name: 'Issue 4',
        series: [
            {
                name: '2 days ago',
                value: 58
            },
            {
                name: '1 day ago',
                value: 50
            },
            {
                name: 'now',
                value: 62
            }
        ]
    }
];
