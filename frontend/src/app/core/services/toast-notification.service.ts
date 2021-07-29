import { Injectable } from '@angular/core';
import { Message, MessageService } from 'primeng/api';

@Injectable({
    providedIn: 'root'
})
export class ToastNotificationService {
    constructor(private messageService: MessageService) {
    }

    info(message: string, title?: string, durationMs?: number): void {
        this.message({
            severity: 'info',
            summary: title ?? 'Info',
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    success(message: string, title?: string, durationMs?: number): void {
        this.message({
            severity: 'success',
            summary: title ?? 'Success',
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    warning(message: string, title?: string, durationMs?: number): void {
        this.message({
            severity: 'warn',
            summary: title ?? 'Warn',
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    error(message: string, title?: string, durationMs?: number): void {
        this.message({
            severity: 'error',
            summary: title ?? 'Error',
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    specificNotification(messageConfig: Message): void {
        this.messageService.add(messageConfig);
    }

    clear() {
        this.messageService.clear();
    }

    private message(message: Message) {
        this.messageService.add(message);
    }
}
