import { OrganizationSettingsComponent } from "./organization-settings/organization-settings.component";
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [{
    path: 'settings',
    component: OrganizationSettingsComponent
},
{
    path: '',
    redirectTo: './settings'
}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class OrganizationRouitingModule { }
