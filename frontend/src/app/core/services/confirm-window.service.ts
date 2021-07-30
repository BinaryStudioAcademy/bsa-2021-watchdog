import { ComponentFactoryResolver, ComponentRef, Injectable } from '@angular/core';
import { ButtonOptions } from '@shared/models/button-options';
import { ConfirmationService, PrimeIcons } from 'primeng/api';

import { ConfirmWindowComponent } from '../components/confirm-window/confirm-window.component';
import { HelperService } from './helper.service';

const DEFAULT_VISIBLE = true;
const DEFAULT_ACCEPT = 'Accept';
const DEFAULT_CANCEL = 'Cancel';
const DEFAULT_CLASS = 'p-button-primary';
const DEFAULT_ICON = PrimeIcons.INFO_CIRCLE;

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

    /**Creates confirmation window
     * @param title title of the window
     * @param message message of window
     * @param icon default: INFO_CIRCLE, icon before message text
     * @param isClosable default: false, can be closed by esc or close mark
     * @param acceptButton default: visible, accept button options
     * @param cancelButton default: visible, cancel button options
     * @param accept function, that invokes after accept button click
     * @param cancel function, that invokes after cancel button click
     */
    confirm(options: {
        title: string,
        message: string,
        icon?: string,
        isClosable?: boolean,
        accept?: Function,
        cancel?: Function,
        acceptButton?: ButtonOptions,
        cancelButton?: ButtonOptions,
    }): void {
        this.createConfirmWindow();

        const confirmButton = options.acceptButton ?? {};
        const decelineButton = options.cancelButton ?? {};
        this.confirmWindowRef.instance.isClosable = options.isClosable;

        this.confirmationService.confirm({
            header: options.title,
            message: options.message,
            icon: options.icon ?? DEFAULT_ICON,
            closeOnEscape: options.isClosable,
            acceptVisible: confirmButton.isVisible ?? DEFAULT_VISIBLE,
            rejectVisible: decelineButton.isVisible ?? DEFAULT_VISIBLE,
            acceptLabel: confirmButton.label ?? DEFAULT_ACCEPT,
            rejectLabel: decelineButton.label ?? DEFAULT_CANCEL,
            acceptButtonStyleClass: confirmButton.class ?? DEFAULT_CLASS,
            rejectButtonStyleClass: decelineButton.class ?? DEFAULT_CLASS,
            acceptIcon: confirmButton.icon ?? '',
            rejectIcon: decelineButton.icon ?? '',
            accept: () => {
                options.accept?.call(this);
                this.destroyConfirmWindow();
            },
            reject: () => {
                options.cancel?.call(this);
                this.destroyConfirmWindow();
            }
        });
    }

    /**Closes current dialog window without running cancel event*/
    closeCurrent(): void {
        this.confirmationService.close();
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
