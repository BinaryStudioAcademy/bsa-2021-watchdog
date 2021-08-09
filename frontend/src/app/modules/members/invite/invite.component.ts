import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-invite',
  templateUrl: './invite.component.html',
  styleUrls: ['./invite.component.sass']
})
export class InviteComponent implements OnInit {
  @Output() closeModal = new EventEmitter<void>();
  
  constructor() { }

  ngOnInit(): void {
  }

}
