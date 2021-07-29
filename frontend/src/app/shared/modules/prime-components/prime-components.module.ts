import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';

// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        InputTextModule,
        ToastModule
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        ToastModule
    ],
    declarations: [],
    providers: [
        MessageService,
        PrimeNGConfig
    ]
})
export class PrimeComponentsModule {
    constructor(private primengConfig: PrimeNGConfig) {
        this.primengConfig.ripple = true;
    }
}
