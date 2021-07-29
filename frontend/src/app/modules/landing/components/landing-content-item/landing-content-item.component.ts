import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing-content-item',
  templateUrl: './landing-content-item.component.html',
  styleUrls: ['./landing-content-item.component.sass']
})
export class LandingContentItemComponent implements OnInit {

  @Input() public item: {title: string, text: string}
  constructor() { }

  ngOnInit(): void {
  }

}
