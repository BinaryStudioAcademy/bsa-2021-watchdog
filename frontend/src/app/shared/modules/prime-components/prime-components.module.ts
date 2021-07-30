import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {ButtonModule} from 'primeng/button';
import {InputTextModule} from 'primeng/inputtext';
import {TabViewModule} from 'primeng/tabview';
import {PasswordModule} from 'primeng/password';
import {CheckboxModule} from 'primeng/checkbox';


// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        TabViewModule,
        InputTextModule,
        PasswordModule,
        CheckboxModule
    ],
    exports: [
        ButtonModule,
        InputTextModule,
        TabViewModule,
        PasswordModule,
        CheckboxModule,
    ],
    declarations: []
})
export class PrimeComponentsModule {
}