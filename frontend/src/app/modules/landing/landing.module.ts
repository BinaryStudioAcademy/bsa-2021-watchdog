import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { LandingPageComponent } from './landing-page/landing-page.component';
import { LandingRoutingModule } from './landing-routing.module';
import { LandingDemoComponent } from './landing-demo/landing-demo.component';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { LandingContentComponent } from './landing-content/landing-content.component';
import { LandingContentItemComponent } from './landing-content-item/landing-content-item.component';

@NgModule({
    declarations: [
        LandingPageComponent,
        LandingDemoComponent,
        LandingContentComponent,
        LandingContentItemComponent
    ],
    imports: [
        SharedModule, LandingRoutingModule,YouTubePlayerModule
    ],
})
export class LandingModule { }
