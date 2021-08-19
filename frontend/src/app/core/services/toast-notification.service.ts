import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Message, MessageService } from 'primeng/api';

@Injectable({
    providedIn: 'root'
})
export class ToastNotificationService {
    constructor(private messageService: MessageService) {
    }

    private static isEmpty(str: string) {
        return !str || str === '';
    }

    info(message: string, title: string = 'Info', durationMs: number = 3000): void {
        this.message({
            severity: 'info',
            summary: ToastNotificationService.isEmpty(title) ? 'Info' : title,
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    success(message: string, title: string = 'Success', durationMs: number = 3000): void {
        this.message({
            severity: 'success',
            summary: ToastNotificationService.isEmpty(title) ? 'Success' : title,
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    warning(message: string, title: string = 'Warn', durationMs: number = 3000): void {
        this.message({
            severity: 'warn',
            summary: ToastNotificationService.isEmpty(title) ? 'Warn' : title,
            detail: message,
            closable: true,
            life: durationMs,
            sticky: true
        });
    }

    specificNotification(messageConfig: Message): void {
        this.messageService.add(messageConfig);
    }

    clear(): void {
        this.messageService.clear();
    }

    private message(message: Message): void {
        this.messageService.add(message);
    }

    error(error: string | HttpErrorResponse, title: string = '', durationMs: number = 3000): void {
        if (typeof error === 'string') {
            this.message({
                severity: 'error',
                summary: ToastNotificationService.isEmpty(title) ? 'Error' : title,
                detail: error,
                closable: true,
                life: durationMs,
            });
        } else {
            this.message({
                severity: 'error',
                summary: ToastNotificationService.isEmpty(title) ? error.name : title,
                detail: error.message,
                closable: true,
                life: durationMs,
            });
        }

    }   
}
