import { Injectable } from '@angular/core';
import { ClickBreadcrumb } from '../models/click-breadcrumbs';
import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root'
})
export class ClickService extends BaseService {
    constructor() {
        super();

        window.onclick = (e) => {
            const event = e as { path: HTMLElement[] };
            if (event.path.some(el => (el.localName === 'button' || el.localName === 'a' || el.localName === 'input'))
                && event.path.every(el => !el.attributes?.getNamedItem('disabled'))) {
                this.eventSource.next(new ClickBreadcrumb(event.path));
            }
        };
    }
}
