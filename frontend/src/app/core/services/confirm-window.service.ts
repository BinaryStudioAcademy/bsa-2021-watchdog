import { ComponentFactoryResolver, ComponentRef, Injectable } from '@angular/core';
import { ButtonOptions } from '@shared/models/confirm-window/button-options';
import { ClickFunction, ConfirmOptions } from '@shared/models/confirm-window/confirm-options';
import { DefaultConfirmOptions } from '@shared/models/confirm-window/default-button-options.const';
import { ConfirmationService } from 'primeng/api';
import { ConfirmWindowComponent } from '../components/confirm-window/confirm-window.component';
import { HelperService } from './helper.service';

@Injectable({
    providedIn: 'root',
})
export class ConfirmWindowService {
    confirmWindowRef: ComponentRef<ConfirmWindowComponent>;

    constructor(
        private confirmationService: ConfirmationService,
        private helper: HelperService,
        private componentFactoryResolver: ComponentFactoryResolver
    ) { }

    confirm(options: ConfirmOptions): void {
        this.createConfirmWindow();

        const confirmButton = this.createButtonOptionsUsingExists(
            DefaultConfirmOptions.DEFAULT_ACCEPT,
            options.acceptButton ?? {}
        );
        const decelineButton = this.createButtonOptionsUsingExists(
            DefaultConfirmOptions.DEFAULT_CANCEL,
            options.cancelButton ?? {}
        );

        this.confirmWindowRef.instance.isClosable = options.isClosable;

        this.confirmationService.confirm({
            header: options.title,
            message: options.message,
            icon: options.icon ?? DefaultConfirmOptions.DEFAULT_ICON,
            closeOnEscape: options.isClosable,
            acceptVisible: confirmButton.isVisible,
            rejectVisible: decelineButton.isVisible,
            acceptLabel: confirmButton.label,
            rejectLabel: decelineButton.label,
            acceptButtonStyleClass: confirmButton.class,
            rejectButtonStyleClass: decelineButton.class,
            acceptIcon: confirmButton.icon,
            rejectIcon: decelineButton.icon,
            accept: () => {
                this.invokeAction(options.accept);
            },
            reject: () => {
                this.invokeAction(options.cancel);
            }
        });
    }

    /**Closes current dialog window without running cancel event*/
    closeCurrent(): void {
        this.confirmationService.close();
        this.destroyConfirmWindow();
    }

    private createButtonOptionsUsingExists(label: string, options: ButtonOptions): ButtonOptions {
        return {
            isVisible: options.isVisible ?? DefaultConfirmOptions.DEFAULT_VISIBLE,
            class: options.class ?? DefaultConfirmOptions.DEFAULT_CLASS,
            icon: options.icon ?? '',
            label: options.label ?? label,
        };
    }

    private invokeAction(func: ClickFunction): void {
        if (func) func();
        this.destroyConfirmWindow();
    }

    private createConfirmWindow(): void {
        if (!this.confirmWindowRef || this.confirmWindowRef.hostView.destroyed) {
            this.confirmWindowRef = this.helper.attachComponentToBody(ConfirmWindowComponent, this.componentFactoryResolver);
        }
    }

    private destroyConfirmWindow(): void {
        if (this.confirmWindowRef && !this.confirmWindowRef.hostView.destroyed) {
            this.helper.detachComponentFromBody(this.confirmWindowRef);
        }
    }
}
