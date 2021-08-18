import { toBreadcrumbHtmlElement } from "../utils/wathdog.utils";
import { Breadcrumb, BreadcrumbBody } from "./breadcrumb";

export class BreadcrumbAttribute {
    name: string;
    value?: string;
}

export class BreadcrumbHtmlElement {
    readonly localName: string;
    readonly attributes?: BreadcrumbAttribute[];
    readonly id?: string;
    readonly classList?: string[]
}

export class ClickBreadcrumbBody extends BreadcrumbBody {
    path: BreadcrumbHtmlElement[];
}

export class ClickBreadcrumb extends Breadcrumb {
    body: ClickBreadcrumbBody;
    constructor (path: HTMLElement[]) {
        super();
        this.type = 'user-action';
        this.category = 'click';
        this.level = 'info';
        this.body = {
            path: path.filter(el => el.localName && el.localName !== 'html' && el.localName !== 'body').map(el => toBreadcrumbHtmlElement(el))
        };
    }
}

