import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-base-configuration[apiKey]',
    template: '',
})
export class BaseConfigurationComponent {
    @Input() apiKey: string;
}
