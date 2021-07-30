import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { UserRoutingModule } from './user-routing.module';

@NgModule({
    declarations: [
        UserProfileComponent
    ],
    imports: [
        SharedModule,
        UserRoutingModule
    ],
})
export class UserModule { }
