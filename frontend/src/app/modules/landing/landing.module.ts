import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { LandingRoutingModule } from './landing-routing.module';
import { LandingDemoComponent } from './components/landing-demo/landing-demo.component';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { LandingContentComponent } from './components/landing-content/landing-content.component';
import { LandingContentItemComponent } from './components/landing-content-item/landing-content-item.component';
import { LandingPlatformsComponent } from './components/landing-platforms/landing-platforms.component';
import { LandingFooterComponent } from './components/landing-footer/landing-footer.component';

@NgModule({
    declarations: [
        LandingPageComponent,
        LandingDemoComponent,
        LandingContentComponent,
        LandingContentItemComponent,
        LandingPlatformsComponent,
        LandingFooterComponent
    ],
    imports: [
        SharedModule, LandingRoutingModule,YouTubePlayerModule
    ],
})
export class LandingModule { }
