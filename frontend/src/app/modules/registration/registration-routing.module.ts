import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationPageComponent } from './registration-page/registration-page.component';

export const routes : Routes = [
  {
      path: '',
      component: RegistrationPageComponent,
      children: [{
          path: '',
          component: RegistrationPageComponent,
          pathMatch: 'full',
      }]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegistrationRoutingModule { }
