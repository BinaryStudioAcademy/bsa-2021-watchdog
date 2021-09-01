import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from '@core/core.module';
import { HighlightModule, HighlightOptions, HIGHLIGHT_OPTIONS } from 'ngx-highlightjs';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        CoreModule,
        HighlightModule,
        NgbModule
    ],
    providers: [
        {
            provide: HIGHLIGHT_OPTIONS,
            useValue: <HighlightOptions>{
                fullLibraryLoader: () => import('highlight.js'),
            }
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
