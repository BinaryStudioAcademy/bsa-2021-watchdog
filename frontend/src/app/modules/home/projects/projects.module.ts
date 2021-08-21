import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { CreateProjectComponent } from './create-project/create-project.component';
import { EditProjectComponent } from './edit-project/edit-project.component';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects/projects.component';

@NgModule({
    declarations: [
        ProjectsComponent,
        CreateProjectComponent,
        EditProjectComponent,
    ],
    imports: [
        SharedModule,
        ProjectsRoutingModule
    ],
})
export class ProjectsModule {
}
