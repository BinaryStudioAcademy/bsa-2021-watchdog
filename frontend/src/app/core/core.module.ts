import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';

import { ErrorInterceptor } from './interceptors/error.interceptor';
import { BaseComponent } from './components/base/base.component';

@NgModule({
    imports: [
        HttpClientModule,
        SharedModule,
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
    declarations: [
        BaseComponent
    ],
})
export class CoreModule { }
