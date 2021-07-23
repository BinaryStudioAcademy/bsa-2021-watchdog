import { Injectable, Inject, LOCALE_ID, ComponentFactoryResolver, ApplicationRef, Injector, Type, ComponentRef } from '@angular/core';
import { DOCUMENT } from '@angular/common';


@Injectable({ providedIn: 'root' })
export class HelperService {
    constructor(
        @Inject(DOCUMENT) private document: Document,
        @Inject(LOCALE_ID) private locale: string,
        private appRef: ApplicationRef,
        private injector: Injector
    ) { }

    get Locale(): string {
        return this.locale;
    }

    attachComponentToBody<T>(component: Type<T>, componentFactoryResolver: ComponentFactoryResolver) {
        const componentFactory = componentFactoryResolver.resolveComponentFactory(component);
        const componentRef = componentFactory.create(this.injector);

        this.appRef.attachView(componentRef.hostView);
        this.document.body.appendChild(componentRef.location.nativeElement);

        return componentRef;
    }

    detachComponentFromBody<T>(component: ComponentRef<T>) {
        this.appRef.detachView(component.hostView);
        component.destroy();
    }
}
