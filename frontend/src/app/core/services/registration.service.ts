import { Injectable } from '@angular/core';
import { FullRegistrationDto } from '@modules/registration/DTO/fullRegistrationDto';
import { PartialRegistrationDto } from '@modules/registration/DTO/partialRegistrationDto';
import { User } from '@shared/models/user/user';
import { HttpInternalService } from './http-internal.service';
import { clear } from './registration.utils';

@Injectable({
    providedIn: 'root'
})
export class RegistrationService {
    private apiPrefix = 'registration';

    constructor(private http: HttpInternalService) { }

    public performFullRegistration(fullRegistrationDto: FullRegistrationDto) {
        const dto = clear(fullRegistrationDto);
        return this.http.postRequest<User>(`/${this.apiPrefix}/full`, dto);
    }

    public performPartialRegistration(partialRegistrationDto: PartialRegistrationDto) {
        return this.http.postRequest<User>(`/${this.apiPrefix}/partial`, partialRegistrationDto);
    }
}
