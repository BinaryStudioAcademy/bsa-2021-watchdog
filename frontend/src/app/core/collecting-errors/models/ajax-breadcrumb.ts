import { Breadcrumb, BreadcrumbBody } from "./breadcrumb";

export class AjaxBreadcrumbBody<T = any, K = any> extends BreadcrumbBody {
    request: {
        method: string
        url: string,
        body?: T
    }
    response: {
        status: number,
        body?: K
    }
}

export class AjaxBreadcrumb<T = any, K = any> extends Breadcrumb {
    body: AjaxBreadcrumbBody<T, K>;
    constructor (url: string, method: string, requestBody: T, status: number, responseBody: K) {
        super();
        this.type = 'http-request';
        this.category = 'http';
        this.level = 'info';
        this.body = {
            request: {
                method: method,
                url: url,
                body: requestBody
            },
            response: {
                status: status,
                body: responseBody
            }
        };
    }
}