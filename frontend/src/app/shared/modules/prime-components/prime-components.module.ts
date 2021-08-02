import { TabViewModule } from 'primeng/tabview';
import { PasswordModule } from 'primeng/password';
import { CheckboxModule } from 'primeng/checkbox';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';

import { DropdownModule } from 'primeng/dropdown';

// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        TabViewModule,
        InputTextModule,
        PasswordModule,
        CheckboxModule,
        ToastModule,
        DropdownModule
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        TabViewModule,
        PasswordModule,
        CheckboxModule,
        ToastModule,
        DropdownModule
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
