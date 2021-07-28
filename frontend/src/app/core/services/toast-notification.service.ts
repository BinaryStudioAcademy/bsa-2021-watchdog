import {Injectable} from '@angular/core';
import {Observable, Subject} from "rxjs";
import {Message} from "primeng/api";

@Injectable({
    providedIn: 'root'
})
export class ToastNotificationService {
    private subject = new Subject<Message>();

    constructor() {
    }

    onNotification(): Observable<Message> {
        return this.subject.asObservable();
    }

    showSpecificNotification(messageConfig: Message) {
        this.subject.next(messageConfig);
    }

    showSuccess(message: string, title?: string, durationMs?: number) {
        this.subject.next({
            severity: 'success',
            summary: title ?? 'Success',
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    showInfo(message: string, title?: string, durationMs?: number) {
        this.subject.next({
            severity: 'info',
            summary: title ?? 'Info',
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    showWarning(message: string, title?: string, durationMs?: number) {
        this.subject.next({
            severity: 'warn',
            summary: title ?? 'Warning',
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    showError(message: string, title?: string, durationMs?: number) {
        this.subject.next({
            severity: 'error',
            summary: title ?? 'Error',
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    clearNotifications() {
        this.subject.next();
    }
}
