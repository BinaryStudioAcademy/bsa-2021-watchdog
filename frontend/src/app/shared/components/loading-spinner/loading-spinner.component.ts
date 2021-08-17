import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-loading-spinner',
    templateUrl: './loading-spinner.component.html'
})
export class LoadingSpinnerComponent {
    @Input() overlay: boolean;
}
