import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { RegistrationRoutingModule } from './registration-routing.module';



@NgModule({
  declarations: [
    RegistrationPageComponent
  ],
  imports: [
    CommonModule,
    RegistrationRoutingModule
  ]
})
export class RegistrationModule { }
