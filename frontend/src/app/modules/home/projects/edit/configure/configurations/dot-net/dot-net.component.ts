import { Component, Input, OnInit } from '@angular/core';
import * as dotNetConstants from '@modules/home/projects/edit/configure/configurations/dot-net/dot-net.constants';

@Component({
    selector: 'app-dot-net[apiKey]',
    templateUrl: './dot-net.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class DotNetComponent implements OnInit {
    @Input() apiKey: string;
    packageManagerInstallationCommand: string;
    dotnetCliInstallationCommand: string;
    sample: string;
    tryCatchSample: string;

    ngOnInit(): void {
        this.packageManagerInstallationCommand = dotNetConstants.packageManagerInstallationCommand;
        this.dotnetCliInstallationCommand = dotNetConstants.dotnetCliInstallationCommand;
        this.tryCatchSample = dotNetConstants.tryCatchSample;
        this.sample = dotNetConstants.sample(this.apiKey);
    }
}
