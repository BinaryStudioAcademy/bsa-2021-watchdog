import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApprovedGuard } from '@core/guards/approved.guard';
import { CreateProjectComponent } from './create-project/create-project.component';
import { EditComponent } from './edit/edit.component';
import { ProjectsComponent } from './projects/projects.component';

const routes: Routes = [{
    path: '',
    component: ProjectsComponent
}, {
    path: 'create',
    canActivate: [ApprovedGuard],
    component: CreateProjectComponent
}, {
    path: 'edit/:id',
    canActivate: [ApprovedGuard],
    component: EditComponent
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProjectsRoutingModule { }
