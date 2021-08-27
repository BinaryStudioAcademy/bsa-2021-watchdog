import { Component, OnInit } from '@angular/core';
import { BaseConfigurationComponent } from '../base-configuration.component';
import { index } from './react.constants';

@Component({
    selector: 'app-react',
    templateUrl: './react.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class ReactComponent extends BaseConfigurationComponent implements OnInit {
    index: string;
    ngOnInit(): void {
        this.index = index(this.apiKey);
    }
}
