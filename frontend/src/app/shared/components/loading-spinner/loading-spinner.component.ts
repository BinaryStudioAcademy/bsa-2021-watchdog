import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-loading-spinner',
    templateUrl: './loading-spinner.component.html'
})
export class LoadingSpinnerComponent {
    @Input() overlay: boolean;
    @Input() size = '50px';
    @Input() top = '25vh';
    @Input() left = 'calc(49% - 25px)';
    @Input() position = 'absolute';
    @Input() margin = '100px auto';
}
