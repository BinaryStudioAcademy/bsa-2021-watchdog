import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedModule } from '@shared/shared.module';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { BaseComponent } from './components/base/base.component';
import { ToastNotificationComponent } from './components/toast-notification/toast-notification.component';
import { fakeBackendProvider } from './interceptors/fake-backend';

@NgModule({
    imports: [
        HttpClientModule,
        SharedModule,
    ],
    providers: [
        fakeBackendProvider,
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
    declarations: [
        BaseComponent,
        ToastNotificationComponent
    ],
    exports: [
        ToastNotificationComponent
    ]
})
export class CoreModule { }
