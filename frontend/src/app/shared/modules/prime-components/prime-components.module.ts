import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationService, MessageService, PrimeNGConfig } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { ScrollTopModule } from 'primeng/scrolltop';
import { ChipModule } from 'primeng/chip';

// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        InputTextModule,
        ToastModule,
        ConfirmDialogModule,
        ScrollTopModule,
        ChipModule
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        ToastModule,
        ConfirmDialogModule,
        ScrollTopModule,
        ChipModule
    ],
    declarations: [],
    providers: [
        MessageService,
        ConfirmationService,
        PrimeNGConfig,
    ]
})
export class PrimeComponentsModule {
    constructor(private primengConfig: PrimeNGConfig) {
        this.primengConfig.ripple = true;
    }
}
