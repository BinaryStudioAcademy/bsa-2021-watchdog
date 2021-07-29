import { Component } from '@angular/core';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router, RouterEvent } from '@angular/router';
import { SpinnerService } from '@core/services/spinner.service';

@Component({
    selector: 'app-root',
    template: '<toast-notification></toast-notification><router-outlet></router-outlet>'
})
export class AppComponent {
    constructor(
        private router: Router,
        private spinner: SpinnerService,
    ) {
        this.router.events.subscribe(this.navigationInterceptor);
    }

    private navigationInterceptor = (event: RouterEvent) => {
        if (event instanceof NavigationStart) {
            this.spinner.show(true);
        }
        if (event instanceof NavigationEnd || event instanceof NavigationCancel || event instanceof NavigationError) {
            this.spinner.hide();
        }
    }
}
