import { NgModule } from '@angular/core';
import { AuthorizationPageComponent } from './authorization-page/authorization-page.component';
import { AuthorizationRoutingModule } from './authorization-routing.module';
import { SharedModule } from '@shared/shared.module';
import { LoginFormComponent } from './login-form/login-form.component';
import { SocialsLoginComponent } from './socials-login/socials-login.component';


@NgModule({
  declarations: [
    AuthorizationPageComponent,
    LoginFormComponent,
    SocialsLoginComponent,
  ],
  imports: [
    SharedModule, AuthorizationRoutingModule
  ]
})
export class AuthorizationModule { }
