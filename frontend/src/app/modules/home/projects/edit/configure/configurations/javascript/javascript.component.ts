import { Component, OnInit } from '@angular/core';
import { BaseConfigurationComponent } from '../base-configuration.component';

@Component({
    selector: 'app-javascript',
    templateUrl: './javascript.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class JavascriptComponent extends BaseConfigurationComponent implements OnInit {
    index: string;
    ngOnInit(): void {
        this.index = `import * as Watchdog from '@watchdog-bsa/watchdog-js';

Watchdog.init('${this.apiKey}');
Watchdog.enableCustomErrorHandling();`;
    }
}
