import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from "@angular/router";
import { ToastNotificationService } from "@core/services/toast-notification.service";
import { BaseComponent } from '../base/base.component';

@Component({
    selector: 'toast-notification',
    templateUrl: './toast-notification.component.html',
    styleUrls: ['./toast-notification.component.sass']
})
export class ToastNotificationComponent extends BaseComponent implements OnInit {
    constructor(
        private router: Router,
        private toastService: ToastNotificationService
    ) {
        super();
    }

    ngOnInit() {
        this.router.events.pipe(this.untilThis).subscribe(event => {
            if (event instanceof NavigationStart) {
                this.toastService.clear();
            }
        });
    }
}
