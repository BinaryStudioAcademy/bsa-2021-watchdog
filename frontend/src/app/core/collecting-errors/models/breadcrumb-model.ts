import { BreadcrumbCategory, BreadcrumbLevel, BreadcrumbType } from "./breadcrumb";

export interface BreadcrumbModel {
    type: BreadcrumbType,
    category: BreadcrumbCategory,
    level: BreadcrumbLevel,
    time: Date,
    body: string,
}