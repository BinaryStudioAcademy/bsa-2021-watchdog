import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PrimeComponentsModule } from './modules/prime-components/prime-components.module';
import { TimeAgoPipe } from './pipes/time-ago.pipe';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        PrimeComponentsModule
    ],
    declarations: [
        LoadingSpinnerComponent,
        NotFoundComponent,
        TimeAgoPipe,
    ],
    exports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        LoadingSpinnerComponent,
        NotFoundComponent,
        PrimeComponentsModule,
        TimeAgoPipe,
    ]
})
export class SharedModule { }
