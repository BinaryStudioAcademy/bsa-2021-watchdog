import { Component, EventEmitter, Output } from '@angular/core';

@Component({
    selector: 'app-invite',
    templateUrl: './invite.component.html',
    styleUrls: ['./invite.component.sass']
})
export class InviteComponent {
    @Output() closeModal = new EventEmitter<void>();
}
