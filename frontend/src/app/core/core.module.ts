import { ErrorHandler, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedModule } from '@shared/shared.module';
import { AngularFireModule } from '@angular/fire';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { environment } from '@env/environment';
import { WatchDogErrorHandler } from '@core/interceptors/watchdog.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { ToastNotificationComponent } from './components/toast-notification/toast-notification.component';
import { ConfirmWindowComponent } from './components/confirm-window/confirm-window.component';
import { JwtInterceptorService } from './interceptors/jwt-interceptor.service';
import { AuthGuard } from './guards/auth.guard';
import { WatchdogService } from './breadcrumbs/services/watchdog.service';

@NgModule({
    imports: [
        HttpClientModule,
        SharedModule,
        AngularFireModule.initializeApp(environment.firebaseConfig),
        AngularFireAuthModule
    ],
    providers: [
        AuthGuard,
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptorService, multi: true },
        { provide: ErrorHandler, useClass: WatchDogErrorHandler },
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
export class CoreModule {
    constructor(private wathchdog: WatchdogService) { }
}
