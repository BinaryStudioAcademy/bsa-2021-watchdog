import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestResultPageComponent } from '@modules/home/load-testing/test-result-page/test-result-page.component';
import { TestSettingsComponent } from '@modules/home/load-testing/test-settings/test-settings.component';
import { TestsComponent } from '@modules/home/load-testing/tests/tests.component';

const routes: Routes = [{
    path: '',
    component: TestsComponent,
}, {
    path: 'new',
    component: TestSettingsComponent,
}, {
    path: ':id/edit',
    component: TestSettingsComponent
}, {
    path: ':id',
    component: TestResultPageComponent
}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LoadTestingRoutingModule { }
