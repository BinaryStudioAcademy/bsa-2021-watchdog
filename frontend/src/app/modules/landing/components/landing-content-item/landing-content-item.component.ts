import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-landing-content-item',
    templateUrl: './landing-content-item.component.html',
    styleUrls: ['./landing-content-item.component.sass']
})
export class LandingContentItemComponent {
    @Input() item: { title: string, text: string, img: string };
    @Input() index: number;
}
