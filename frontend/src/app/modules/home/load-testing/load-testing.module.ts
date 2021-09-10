import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { TestResultPageComponent } from '@modules/home/load-testing/test-result-page/test-result-page.component';
import { TestSettingsComponent } from '@modules/home/load-testing/test-settings/test-settings.component';
import { LoadTestingRoutingModule } from '@modules/home/load-testing/load-testing-routing.module';
import { TestsComponent } from '@modules/home/load-testing/tests/tests.component';

@NgModule({
    declarations: [
        TestSettingsComponent,
        TestsComponent,
        TestResultPageComponent
    ],
    imports: [
        SharedModule,
        LoadTestingRoutingModule,
    ]
})
export class LoadTestingModule { }
