export type BreadcrumbType = 'navigation' | 'debug' | 'error' | 'http-request' | 'user-action';
export type BreadcrumbCategory = 'router' | 'console' | 'http' | 'click' | 'exception';
export type BreadcrumbLevel = 'info' | 'warning' | 'error' | 'debug';

export interface BreadcrumbBody {

}

export interface BreadcrumbModel {
    type: BreadcrumbType,
    category: BreadcrumbCategory,
    level: BreadcrumbLevel,
    time: Date,
    body: string,
}

export class Breadcrumb {
    type: BreadcrumbType;
    category: BreadcrumbCategory;
    level: BreadcrumbLevel;
    time: Date;
    body: BreadcrumbBody;

    constructor(model?: BreadcrumbModel) {
        if (model) {
            this.body = JSON.parse(model.body);
            this.category = model.category;
            this.level = model.level;
            this.time = model.time;
            this.type = model.type;
        } else {
            this.time = new Date();
        }
    }

    toModel(): BreadcrumbModel {
        return { ...this, body: JSON.stringify(this.body) };
    }
}
