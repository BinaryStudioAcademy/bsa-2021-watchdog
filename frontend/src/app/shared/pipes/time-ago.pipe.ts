import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'timeAgo'
})
export class TimeAgoPipe implements PipeTransform {
    transform(value: Date | string): string {
        const date = new Date(value);
        const difference = new Date().getTime() - date.getTime();
        if (difference < 60 * 1000) {
            return 'just now';
        }
        if (difference < 60 * 60 * 1000) {
            return `${Math.floor(difference / (60 * 1000))}min ago`;
        }
        if (difference < 24 * 60 * 60 * 1000) {
            return `${Math.floor(difference / (60 * 60 * 1000))}h ago`;
        }
        if (difference < 30 * 24 * 60 * 60 * 1000) {
            return `${Math.floor(difference / (24 * 60 * 60 * 1000))}d ago`;
        }
        if (difference < 365 * 24 * 60 * 60 * 1000) {
            return `${Math.floor(difference / (30 * 24 * 60 * 60 * 1000))}mon ago`;
        }
        return `${Math.floor(difference / (365 * 24 * 60 * 60 * 1000))}y ago`;
    }
}
