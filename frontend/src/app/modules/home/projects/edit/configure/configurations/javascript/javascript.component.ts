import { Component, OnInit } from '@angular/core';
import { BaseConfigurationComponent } from '../base-configuration.component';
import { index } from './javascript.constants';

@Component({
    selector: 'app-javascript',
    templateUrl: './javascript.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class JavascriptComponent extends BaseConfigurationComponent implements OnInit {
    index: string;
    ngOnInit(): void {
        this.index = index(this.apiKey);
    }
}
