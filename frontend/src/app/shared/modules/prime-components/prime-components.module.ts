import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {ButtonModule} from 'primeng/button';
import {InputTextModule} from 'primeng/inputtext';


// import and export here all required modules from primeng
@NgModule({
    imports: [
        CommonModule,
        ButtonModule,
        InputTextModule,
    ],
    exports: [
        ButtonModule,
        InputTextModule,
    ],
    declarations: []
})
export class PrimeComponentsModule {
}
