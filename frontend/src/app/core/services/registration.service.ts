import { Injectable } from '@angular/core';
import { FullRegistrationDto } from '@modules/registration/DTO/full-registration-dto';
import { FullRegistrationWithJoinDto } from '@modules/registration/DTO/full-registration-with-join-dto';
import { PartialRegistrationDto } from '@modules/registration/DTO/partial-registration-dto';
import { PartialRegistratioWithJoinDto } from '@modules/registration/DTO/partial-registration-with-join';
import { User } from '@shared/models/user/user';
import { Observable } from 'rxjs';
import { CoreHttpService } from './core-http.service';
import { clear } from './registration.utils';

@Injectable({
    providedIn: 'root'
})
export class RegistrationService {
    private apiPrefix = 'registration';

    constructor(private http: CoreHttpService) { }

    public performFullRegistration(fullRegistrationDto: FullRegistrationDto) {
        const dto = clear(fullRegistrationDto);
        return this.http.postRequest<User>(`/${this.apiPrefix}/full`, dto);
    }

    public performFullRegistrationWithJoin(registrationDto: FullRegistrationWithJoinDto) {
        const dto = clear(registrationDto);
        return this.http.postRequest<User>(`/${this.apiPrefix}/fullWithJoin`, dto);
    }

    public performPartialRegistration(partialRegistrationDto: PartialRegistrationDto) {
        return this.http.postRequest<User>(`/${this.apiPrefix}/partial`, partialRegistrationDto);
    }

    public performPartialRegistrationWithJoin(registrationDto: PartialRegistratioWithJoinDto) {
        return this.http.postRequest<User>(`/${this.apiPrefix}/partialWithJoin`, registrationDto);
    }

    public joinToOrganization(userId: number, organizationSlug: string): Observable<User> {
        return this.http.postRequest(`/${this.apiPrefix}/joinToOrganization`, { userId, organizationSlug });
    }
}
