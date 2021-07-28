import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { LandingPageComponent } from './landing-page/landing-page.component';
import { LandingRoutingModule } from './landing-routing.module';
import { LandingDemoComponent } from './landing-demo/landing-demo.component';

@NgModule({
    declarations: [
        LandingPageComponent,
        LandingDemoComponent
    ],
    imports: [
        SharedModule, LandingRoutingModule
    ],
})
export class LandingModule { }
