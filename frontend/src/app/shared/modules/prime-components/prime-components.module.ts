import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { ScrollTopModule } from 'primeng/scrolltop';
import { ChipModule } from 'primeng/chip';
import { MenuModule } from 'primeng/menu';
import { AvatarModule } from 'primeng/avatar';
import { DropdownModule } from 'primeng/dropdown';
import { InputSwitchModule } from 'primeng/inputswitch';

// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        InputTextModule,
        ToastModule,
        ScrollTopModule,
        ChipModule,
        MenuModule,
        AvatarModule,
        DropdownModule,
        InputSwitchModule,
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        ToastModule,
        ScrollTopModule,
        ChipModule,
        MenuModule,
        AvatarModule,
        DropdownModule,
        InputSwitchModule,
    ],
    declarations: [],
    providers: [
        MessageService,
        PrimeNGConfig,
    ]
})
export class PrimeComponentsModule {
    constructor(private primengConfig: PrimeNGConfig) {
        this.primengConfig.ripple = true;
    }
}
