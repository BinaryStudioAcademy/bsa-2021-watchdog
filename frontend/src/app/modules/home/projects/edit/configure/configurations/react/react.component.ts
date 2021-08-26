import { Component, OnInit } from '@angular/core';
import { BaseConfigurationComponent } from '../base-configuration.component';

@Component({
    selector: 'app-react',
    templateUrl: './react.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class ReactComponent extends BaseConfigurationComponent implements OnInit {
    index: string;
    ngOnInit(): void {
        this.index = `import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import * as Watchdog from '@watchdog-bsa/watchdog-js';

Watchdog.init('${this.apiKey}');
Watchdog.enableCustomErrorHandling();

ReactDOM.render(<App />, document.getElementById("root"));

// Can also use with React Concurrent Mode
// ReactDOM.createRoot(document.getElementById('root')).render(<App />);`;
    }
}
