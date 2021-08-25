import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-no-content-placeholder',
    templateUrl: './no-content-placeholder.html',
    styleUrls: ['./no-content-placeholder.sass']
})

export class NoContentPlaceholderComponent {
    @Input() title: string;
}
