import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorizationPageComponent } from './authorization-page/authorization-page.component';
import { AuthorizationRoutingModule } from './authorization-routing.module';



@NgModule({
  declarations: [
    AuthorizationPageComponent
  ],
  imports: [
    CommonModule,
    AuthorizationRoutingModule
  ]
})
export class AuthorizationModule { }
