import { Observable, Subject } from "rxjs";
import { Breadcrumb } from "../models/breadcrumb";

export class BaseService {

    private static eventSource = new Subject<Breadcrumb>();

    protected get eventSource() {
        return BaseService.eventSource;
    }

    static event$: Observable<Breadcrumb> = BaseService.eventSource.asObservable();
}