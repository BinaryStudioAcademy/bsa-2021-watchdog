import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export class HttpInternalService {
    protected headers = new HttpHeaders();

    constructor(protected http: HttpClient, protected baseUrl: string) { }

    protected getHeaders(): HttpHeaders {
        return this.headers;
    }

    protected getHeader(key: string): string {
        return this.headers[key];
    }

    protected setHeader(key: string, value: string): void {
        this.headers[key] = value;
    }

    protected deleteHeader(key: string): void {
        delete this.headers[key];
    }

    public getRequest<T>(url: string, httpParams?: any): Observable<T> {
        return this.http.get<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
    }

    public postRequest<T>(url: string, payload: object, httpParams?: any): Observable<T> {
        return this.http.post<T>(this.buildUrl(url), payload, { headers: this.getHeaders(), params: httpParams });
    }

    public putRequest<T>(url: string, payload: object, httpParams?: any): Observable<T> {
        return this.http.put<T>(this.buildUrl(url), payload, { headers: this.getHeaders(), params: httpParams });
    }

    public patchRequest<T>(url: string, payload: object) {
        return this.http.patch<T>(this.buildUrl(url), payload, { headers: this.getHeaders() });
    }

    public deleteRequest<T>(url: string, httpParams?: any): Observable<T> {
        return this.http.delete<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
    }

    protected buildUrl(url: string): string {
        return this.baseUrl + url;
    }
}
