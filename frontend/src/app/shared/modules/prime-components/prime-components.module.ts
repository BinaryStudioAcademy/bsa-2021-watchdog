import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationService, MessageService, PrimeNGConfig } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { ScrollTopModule } from 'primeng/scrolltop';
import { ChipModule } from 'primeng/chip';
import { MenuModule } from 'primeng/menu';
import { AvatarModule } from 'primeng/avatar';
import { DropdownModule } from 'primeng/dropdown';
import { InputSwitchModule } from 'primeng/inputswitch';
import { PanelMenuModule } from 'primeng/panelmenu';
import { SidebarModule } from 'primeng/sidebar';
import { DialogModule } from 'primeng/dialog';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { PanelModule } from 'primeng/panel';
import { RippleModule } from 'primeng/ripple';

// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        InputTextModule,
        PanelMenuModule,
        SidebarModule,
        ToastModule,
        ConfirmDialogModule,
        ScrollTopModule,
        ChipModule,
        MenuModule,
        AvatarModule,
        DropdownModule,
        InputSwitchModule,
        DialogModule,
        MessagesModule,
        MessageModule,
        PanelModule,
        RippleModule,
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        PanelMenuModule,
        SidebarModule,
        DialogModule,
        ToastModule,
        ConfirmDialogModule,
        ScrollTopModule,
        ChipModule,
        MenuModule,
        AvatarModule,
        DropdownModule,
        InputSwitchModule,
        MessagesModule,
        MessageModule,
        PanelModule,
        RippleModule,
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
