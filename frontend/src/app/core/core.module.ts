import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedModule } from '@shared/shared.module';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { ToastNotificationComponent } from './components/toast-notification/toast-notification.component';
import { ConfirmWindowComponent } from './components/confirm-window/confirm-window.component';
import { AngularFireModule } from '@angular/fire';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { environment } from '@env/environment';

@NgModule({
    imports: [
        HttpClientModule,
        SharedModule,
        AngularFireModule.initializeApp(environment.firebaseConfig),
        AngularFireAuthModule
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
    ],
    declarations: [
        ToastNotificationComponent,
        ConfirmWindowComponent,
    ],
    exports: [
        ToastNotificationComponent,
        ConfirmWindowComponent,
    ]
})
export class CoreModule { }
