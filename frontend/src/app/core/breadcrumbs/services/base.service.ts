import { Observable, Subject } from "rxjs";
import { Breadcrumb } from "../models/breadcrumb";

export class BaseService {

    protected eventSource = new Subject<Breadcrumb>();

    event$: Observable<Breadcrumb> = this.eventSource.asObservable();
}