import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared/shared.module';
import { OrganizationMenuComponent } from './organization-menu/organization-menu.component';
import { GeneralSettingsComponent } from "./organization-settings/general-settings/general-settings.component";
import { MembershipSettingsComponent } from "./organization-settings/membership-settings/membership-settings.component";
import { OrganizationSettingsComponent } from "./organization-settings/organization-settings.component";
import { OrganizationRouitingModule } from './organization-routing.module';

@NgModule({
    imports: [
        SharedModule,
        OrganizationRouitingModule
    ],
    exports: [
        OrganizationMenuComponent,
        OrganizationSettingsComponent,
    ],
    declarations: [
        OrganizationMenuComponent,
        OrganizationSettingsComponent,
        MembershipSettingsComponent,
        GeneralSettingsComponent,
    ]
})
export class OrganizationModule { }
