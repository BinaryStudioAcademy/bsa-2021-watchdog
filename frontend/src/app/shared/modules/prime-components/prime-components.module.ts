import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { ScrollTopModule } from 'primeng/scrolltop';
import { ChipModule } from 'primeng/chip';
import { PanelMenuModule } from 'primeng/panelmenu';
import { SidebarModule } from 'primeng/sidebar';
import { DropdownModule } from 'primeng/dropdown';
import { DialogModule } from 'primeng/dialog';

// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        InputTextModule,
        PanelMenuModule,
        SidebarModule,
        DropdownModule,
        DialogModule,
        ToastModule,
        ScrollTopModule,
        ChipModule
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        PanelMenuModule,
        SidebarModule,
        DropdownModule,
        DialogModule,
        ToastModule,
        ScrollTopModule,
        ChipModule
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
