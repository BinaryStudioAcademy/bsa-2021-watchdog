import { TestsComponent } from './tests/tests.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestSettingsComponent } from './test-settings/test-settings.component';

const routes: Routes = [{
    path: '',
    component: TestsComponent,
}, {
    path: 'new',
    component: TestSettingsComponent,
}, {
    path: 'edit/:id',
    component: TestSettingsComponent
}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LoadTestingRoutingModule { }
