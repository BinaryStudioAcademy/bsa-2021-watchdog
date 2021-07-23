import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-loading-spinner',
    templateUrl: './loading-spinner.component.html'
})
export class LoadingSpinnerComponent {
    @Input() overlay: boolean;
    @Input() size = '20px';
    @Input() top = '30%';
    @Input() left = '49%';
    @Input() position = 'absolute';
    @Input() margin = '100px auto';
}
