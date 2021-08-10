import { Injectable } from '@angular/core';
import { FullRegistrationDto } from '@modules/registration/DTO/fullRegistrationDto';
import { PartialRegistrationDto } from '@modules/registration/DTO/partialRegistrationDto';
import { User } from '@shared/models/user/user';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class RegistrationService {
    private apiPrefix = 'registration';

    constructor(private http: HttpInternalService) { }

    public performFullRegistration(fullRegistrationDto: FullRegistrationDto) {
        if (fullRegistrationDto.user.firstName === "") {
            fullRegistrationDto.user.firstName = null;
        }
        if (fullRegistrationDto.user.lastName === "") {
            fullRegistrationDto.user.lastName = null;
        }
        return this.http.postRequest<User>(`/${this.apiPrefix}/full`, fullRegistrationDto);
    }

    public performPartialRegistration(partialRegistrationDto: PartialRegistrationDto) {
        return this.http.postRequest<User>(`/${this.apiPrefix}/partial`, partialRegistrationDto);
    }
}
