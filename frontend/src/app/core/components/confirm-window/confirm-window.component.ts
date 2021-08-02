import { Component } from '@angular/core';

@Component({
    selector: 'app-confirm-window',
    templateUrl: './confirm-window.component.html',
    styleUrls: ['./confirm-window.component.sass'],
})
export class ConfirmWindowComponent {
    isClosable: boolean = false;
}
