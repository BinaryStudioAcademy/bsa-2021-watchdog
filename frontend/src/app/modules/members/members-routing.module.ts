import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MembersPageComponent } from './members-page/members-page.component';

export const routes: Routes = [
    {
        path: '',
        component: MembersPageComponent,
        children: [{
            path: 'invite',
            component: MembersPageComponent,
            pathMatch: 'full',
        }]
    }

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MembersRoutingModule { }
