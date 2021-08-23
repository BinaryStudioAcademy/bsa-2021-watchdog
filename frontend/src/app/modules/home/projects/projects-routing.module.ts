import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateProjectComponent } from './create-project/create-project.component';
import { EditProjectComponent } from './edit-project/edit-project.component';
import { EditComponent } from './edit/edit.component';
import { ProjectsComponent } from './projects/projects.component';

const routes: Routes = [{
    path: '',
    component: ProjectsComponent
}, {
    path: 'create',
    component: CreateProjectComponent
}, {
    path: ':id',
    component: EditComponent
}, {
    path: '',
    redirectTo: 'projects'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProjectsRoutingModule { }
