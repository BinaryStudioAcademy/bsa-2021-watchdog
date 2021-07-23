import { Injectable, ComponentRef, ComponentFactoryResolver } from '@angular/core';
import { HelperService } from './helper.service';
import { LoadingSpinnerComponent } from '@shared/components/loading-spinner/loading-spinner.component';

@Injectable({ providedIn: 'root' })
export class SpinnerService {
    private spinnerComponentrRef: ComponentRef<LoadingSpinnerComponent>;

    constructor(
        private componentFactoryResolver: ComponentFactoryResolver,
        private helper: HelperService,
    ) { }

    show(overlay?: boolean) {
        if (!this.spinnerComponentrRef || this.spinnerComponentrRef.hostView.destroyed) {
            this.spinnerComponentrRef = this.helper.attachComponentToBody(LoadingSpinnerComponent, this.componentFactoryResolver);
        }

        this.spinnerComponentrRef.instance.overlay = overlay;
        return this.spinnerComponentrRef;
    }

    hide() {
        if (this.spinnerComponentrRef && !this.spinnerComponentrRef.hostView.destroyed) {
            this.helper.detachComponentFromBody(this.spinnerComponentrRef);
        }
    }
}
