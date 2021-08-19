export interface BreadcrumbAttribute {
    name: string;
    value?: string;
}

export interface BreadcrumbHtmlElement {
    readonly localName: string;
    readonly attributes?: BreadcrumbAttribute[];
    readonly id?: string;
    readonly classList?: string[];
}
