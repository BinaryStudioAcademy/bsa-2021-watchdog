import { Injectable } from '@angular/core';
import { Message, MessageService } from 'primeng/api';

@Injectable({
    providedIn: 'root'
})
export class ToastNotificationService {
    private errorCodeWithMessageStrings = { codeString: 'Error Code: ', messageString: '\nMessage: ' };
    private errorString = 'Error: ';

    constructor(private messageService: MessageService) {
    }

    info(message: string, title: string = 'Info', durationMs: number = 2000): void {
        this.message({
            severity: 'info',
            summary: title === '' ? 'Info' : title,
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    success(message: string, title: string = 'Success', durationMs: number = 2000): void {
        console.log(message);
        this.message({
            severity: 'success',
            summary: title === '' ? 'Success' : title,
            detail: message,
            closable: true,
            life: durationMs
        });
    }

    warning(message: string, title: string = 'Warn', durationMs: number = 2000): void {
        this.message({
            severity: 'warn',
            summary: title === '' ? 'Warn' : title,
            detail: message,
            closable: true,
            life: durationMs,
            sticky: true
        });
    }

    error(message: string, title: string = 'Error', durationMs: number = 2000): void {
        let errorMessage = message;
        let errorTitle = title;

        //get error message from error.interceptor
        if (this.isInterceptorErrorCodeWithMessage(message)) {
            const indexOfMessage = errorMessage.indexOf(this.errorCodeWithMessageStrings.messageString);
            errorTitle = message.substr(0, indexOfMessage);
            errorMessage = message.substr(indexOfMessage + this.errorCodeWithMessageStrings.messageString.length);
        } else if (this.isInterceptorError(message)) {
            errorMessage = message.substr(this.errorString.length);
        }

        this.message({
            severity: 'error',
            summary: errorTitle === '' ? 'Error' : title,
            detail: errorMessage,
            closable: true,
            life: durationMs,
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

    private isInterceptorErrorCodeWithMessage(str: string): boolean {
        let count = 0;
        const searchStrings = [this.errorCodeWithMessageStrings.codeString, this.errorCodeWithMessageStrings.messageString];
        searchStrings.forEach(val => {
            if (str.includes(val)) {
                count += 1;
            }
        });

        return count === 2;
    }

    private isInterceptorError(str: string): boolean {
        return str.includes(this.errorString);
    }
}
