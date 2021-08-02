import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationPageComponent } from './authorization-page/authorization-page.component';

export const routes: Routes = [
    {
        path: '',
        component: AuthorizationPageComponent,
        children: [{
            path: '',
            component: AuthorizationPageComponent,
            pathMatch: 'full',
        }]
    }

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AuthorizationRoutingModule { }
