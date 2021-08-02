import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { DropdownModule } from 'primeng/dropdown';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { RegistrationRoutingModule } from './registration-routing.module';
import { RegistrationFormComponent } from './registration-form/registration-form.component';

@NgModule({
    declarations: [
        RegistrationPageComponent,
        RegistrationFormComponent,

    ],
    imports: [
        SharedModule,
        RegistrationRoutingModule,
        DropdownModule,
    ]
})
export class RegistrationModule { }
