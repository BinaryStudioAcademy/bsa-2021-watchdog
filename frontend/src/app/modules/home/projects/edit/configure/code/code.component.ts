import { Input, Component } from '@angular/core';

import { CopyHelper } from '@core/helpers/copyHelper';

@Component({
    selector: 'app-code',
    templateUrl: './code.component.html',
    styleUrls: ['../configure-styles.sass']
})
export class CodeComponent {
    @Input() code: string;
    @Input() languages: string[];

    constructor(public helper: CopyHelper) { }
}
