import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { CreateProjectComponent } from './create-project/create-project.component';
import { EditProjectComponent } from './edit-project/edit-project.component';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects/projects.component';
import { EditComponent } from './edit/edit.component';
import { ProjectGeneralComponent } from './edit/project-general/project-general.component';
import { ProjectAlertComponent } from './edit/project-alert/project-alert.component';

@NgModule({
    declarations: [
        ProjectsComponent,
        CreateProjectComponent,
        EditProjectComponent,
        EditComponent,
        ProjectGeneralComponent,
        ProjectAlertComponent,
    ],
    imports: [
        SharedModule,
        ProjectsRoutingModule
    ],
})
export class ProjectsModule {
}
