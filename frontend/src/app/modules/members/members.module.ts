import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { MembersPageComponent } from './members-page/members-page.component';
import { MembersRoutingModule } from './members-routing.module';



@NgModule({
  declarations: [
    MembersPageComponent
  ],
  imports: [
    SharedModule,
    MembersRoutingModule,
  ]
})
export class MembersModule { }
