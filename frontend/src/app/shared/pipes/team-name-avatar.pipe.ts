import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'teamNameAvatar'
})
export class TeamNameAvatarPipe implements PipeTransform {
    transform(value: string): string {
        const words = value.split(' ');

        let label = words[0].charAt(0);

        if (words.length > 1) {
            label += words[words.length - 1].charAt(0);
        }

        return label.toUpperCase();
    }
}
