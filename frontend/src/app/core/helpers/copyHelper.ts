import { Injectable } from '@angular/core';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Injectable({ providedIn: 'root' })
export class CopyHelper {
    constructor(private toastNotification: ToastNotificationService) {

    }
    copyMessage(val: string) {
        const selBox = document.createElement('textarea');
        selBox.value = val;
        document.body.appendChild(selBox);
        selBox.focus();
        selBox.select();
        document.execCommand('copy');
        document.body.removeChild(selBox);
        this.toastNotification.success('Coppied!');
    }
}
