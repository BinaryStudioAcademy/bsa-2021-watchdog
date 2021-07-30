import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {ButtonModule} from 'primeng/button';
import {InputTextModule} from 'primeng/inputtext';
import {PanelMenuModule} from "primeng/panelmenu";
import {SidebarModule} from "primeng/sidebar";
import {DropdownModule} from 'primeng/dropdown';
import {DialogModule} from 'primeng/dialog';

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
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        PanelMenuModule,
        SidebarModule,
        DropdownModule,
        DialogModule,
    ],
    declarations: []
})
export class PrimeComponentsModule {
}
