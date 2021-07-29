import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

    public getHeader(key: string): string {
        return this.headers[key];
    }

    public setHeader(key: string, value: string): void {
        this.headers[key] = value;
    }

    public deleteHeader(key: string): void {
        delete this.headers[key];
    }

    public getRequest<T>(url: string, httpParams?: any): Observable<T> {
        return this.http.get<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
    }

    public postRequest<T>(url: string, payload: object): Observable<T> {
        return this.http.post<T>(this.buildUrl(url), payload, { headers: this.getHeaders() });
    }

    public putRequest<T>(url: string, payload: object): Observable<T> {
        return this.http.put<T>(this.buildUrl(url), payload, { headers: this.getHeaders() });
    }

    public deleteRequest<T>(url: string, httpParams?: any): Observable<T> {
        return this.http.delete<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
    }

    public buildUrl(url: string): string {
        if (url.startsWith('http://') || url.startsWith('https://')) {
            return url;
        }
        return this.baseUrl + url;
    }
}
