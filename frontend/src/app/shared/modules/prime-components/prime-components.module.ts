import { TabViewModule } from 'primeng/tabview';
import { PasswordModule } from 'primeng/password';
import { CheckboxModule } from 'primeng/checkbox';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationService, MessageService, PrimeNGConfig } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { ScrollTopModule } from 'primeng/scrolltop';
import { ChipModule } from 'primeng/chip';
import { PanelMenuModule } from 'primeng/panelmenu';
import { SidebarModule } from 'primeng/sidebar';
import { DialogModule } from 'primeng/dialog';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { PanelModule } from 'primeng/panel';
import { RippleModule } from 'primeng/ripple';
import { DropdownModule } from 'primeng/dropdown';
import { AvatarModule } from 'primeng/avatar';
import { AvatarGroupModule } from 'primeng/avatargroup';

// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        TabViewModule,
        InputTextModule,
        PasswordModule,
        CheckboxModule,
        PanelMenuModule,
        SidebarModule,
        ToastModule,
        ConfirmDialogModule,
        ScrollTopModule,
        ChipModule,
        DialogModule,
        MessagesModule,
        MessageModule,
        PanelModule,
        RippleModule,
        DropdownModule,
        AvatarModule,
        AvatarGroupModule
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        TabViewModule,
        PasswordModule,
        CheckboxModule,
        PanelMenuModule,
        SidebarModule,
        DialogModule,
        ToastModule,
        ConfirmDialogModule,
        ScrollTopModule,
        ChipModule,
        MessagesModule,
        MessageModule,
        PanelModule,
        RippleModule,
        DropdownModule,
        AvatarModule,
        AvatarGroupModule
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
