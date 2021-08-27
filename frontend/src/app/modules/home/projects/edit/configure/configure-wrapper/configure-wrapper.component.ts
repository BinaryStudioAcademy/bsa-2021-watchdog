import { Component, Input } from '@angular/core';
import { Project } from '@shared/models/projects/project';

@Component({
    selector: 'app-configure-wrapper[project]',
    templateUrl: './configure-wrapper.component.html',
    styleUrls: ['../configure-styles.sass']
})
export class ConfigureWrapperComponent {
    @Input() project: Project;
}
