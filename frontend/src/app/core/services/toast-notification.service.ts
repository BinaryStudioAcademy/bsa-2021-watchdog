import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
    providedIn: 'root'
})
export class ToastNotificationService {
    constructor(private messageService: MessageService) { }

    private message(severity: string, summary: string, detail: string) {
        this.messageService.add({
            closable: true,
            severity,
            summary,
            detail,
        });
    }

    success(message: string) {
        this.message('success', 'Success', message);
    }

    info(message: string) {
        this.message('info', 'Info', message);
    }

    warning(message: string) {
        this.message('warn', 'Warn', message);
    }

    error(message: string): void {
        this.message('error', 'Error', message);
    }

    clear() {
        this.messageService.clear();
    }
}
