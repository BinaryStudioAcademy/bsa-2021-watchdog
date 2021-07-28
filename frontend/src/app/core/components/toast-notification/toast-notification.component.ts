import {Component, OnInit} from '@angular/core';
import {MessageService, PrimeNGConfig} from "primeng/api";
import {NavigationStart, Router} from "@angular/router";
import {ToastNotificationService} from "@core/services/toast-notification.service";
import {Subscription} from "rxjs";

@Component({
    selector: 'toast-notification',
    templateUrl: './toast-notification.component.html',
    styleUrls: ['./toast-notification.component.sass']
})
export class ToastNotificationComponent implements OnInit {
    notificationSubscription: Subscription;
    routeSubscription: Subscription;

    constructor(private messageService: MessageService,
                private primeNGConfig: PrimeNGConfig,
                private router: Router,
                private toastService: ToastNotificationService) {
    }

    ngOnInit(): void {
        this.primeNGConfig.ripple = true;
        this.notificationSubscription = this.toastService.onNotification()
            .subscribe(msg => {
                if (msg) {
                    this.messageService.add(msg);
                } else {
                    this.messageService.clear();
                }
            });
        this.routeSubscription = this.router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                this.messageService.clear();
            }
        });
    }

    ngOnDestroy() {
        this.notificationSubscription.unsubscribe();
        this.routeSubscription.unsubscribe();
    }
}
