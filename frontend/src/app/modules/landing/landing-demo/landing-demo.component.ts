import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing-demo',
  templateUrl: './landing-demo.component.html',
  styleUrls: ['./landing-demo.component.sass']
})
export class LandingDemoComponent implements OnInit {

  videoId:string = 'roHLJEoC2H8';

  constructor() { }

  ngOnInit(): void {
  }

}
