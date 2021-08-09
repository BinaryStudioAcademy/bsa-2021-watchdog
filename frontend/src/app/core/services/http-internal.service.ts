import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from '@env/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class HttpInternalService {
    public baseUrl: string = environment.coreUrl;
    public headers = new HttpHeaders();

    constructor(private http: HttpClient) { }

    public getHeaders(): HttpHeaders {
        return this.headers;
    }

    public getHeader(key: string) {
        return this.headers[key];
    }

    public setHeader(key: string, value: string): void {
        this.headers[key] = value;
    }

    public deleteHeader(key: string): void {
        delete this.headers[key];
    }

    public getRequest<T>(url: string, httpParams?: any): Observable<HttpResponse<T>> {
        return this.http.get<T>(this.buildUrl(url), { headers: this.headers, params: httpParams, observe: 'response' });
    }

    public getFullRequest<T>(url: string, httpParams?: any): Observable<HttpResponse<T>> {
        return this.http.get<T>(this.buildUrl(url), { observe: 'response', headers: this.getHeaders(), params: httpParams });
    }

    public postRequest<T>(url: string, payload: object): Observable<T> {
        return this.http.post<T>(this.buildUrl(url), payload, { headers: this.getHeaders() });
    }

    public patchFullRequest<T>(url: string, payload: object) {
        return this.http.patch<T>(this.buildUrl(url), payload, { headers: this.getHeaders(), observe: 'response' });
    }

    public postFullRequest<T>(url: string, payload: object): Observable<HttpResponse<T>> {
        return this.http.post<T>(this.buildUrl(url), payload, { headers: this.getHeaders(), observe: 'response' });
    }

    public putRequest<T>(url: string, body: any | null): Observable<HttpResponse<T>> {
        return this.http.put<T>(this.buildUrl(url), body, { headers: this.headers, observe: 'response' });
    }

    public putFullRequest<T>(url: string, payload: object): Observable<HttpResponse<T>> {
        return this.http.put<T>(this.buildUrl(url), payload, { headers: this.getHeaders(), observe: 'response' });
    }

    public deleteRequest<T>(url: string, httpParams?: any): Observable<T> {
        return this.http.delete<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
    }

    public deleteFullRequest<T>(url: string, httpParams?: any): Observable<HttpResponse<T>> {
        return this.http.delete<T>(this.buildUrl(url), { headers: this.getHeaders(), observe: 'response', params: httpParams });
    }

    public buildUrl(url: string): string {
        if (url.startsWith('http://') || url.startsWith('https://')) {
            return url;
        }
        return this.baseUrl + url;
    }
}
