import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { UserRoutingModule } from './user-routing.module';
import { UserProfileSettingsComponent } from './components/user-profile-settings/user-profile-settings.component';
import { UserPasswordSettingsComponent } from './components/user-password-settings/user-password-settings.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        UserProfileComponent,
        UserProfileSettingsComponent,
        UserPasswordSettingsComponent
    ],
    imports: [
        SharedModule,
        UserRoutingModule,
        FormsModule
    ],
})
export class UserModule { }
