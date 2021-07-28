import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationPageComponent } from './authorization-page/authorization-page.component';

export const routes : Routes=[
  {
    path:'', component: AuthorizationPageComponent,
    children: [{
      path: '',
      redirectTo: 'login',
      pathMatch: 'full',
  }, {
      path: 'login',
      component: AuthorizationPageComponent,
      pathMatch: 'full',
  }, {
      path: '**',
      redirectTo: 'login',
      pathMatch: 'full',
  }]
  }

]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthorizationRoutingModule { }
