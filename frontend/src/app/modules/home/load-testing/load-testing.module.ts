import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { LoadTestingRoutingModule } from './load-testing-routing.module';
import { TestSettingsComponent } from './test-settings/test-settings.component';
import { TestsComponent } from './tests/tests.component';

@NgModule({
    declarations: [
        TestSettingsComponent,
        TestsComponent
    ],
    imports: [
        SharedModule,
        LoadTestingRoutingModule,
    ]
})
export class LoadTestingModule { }
