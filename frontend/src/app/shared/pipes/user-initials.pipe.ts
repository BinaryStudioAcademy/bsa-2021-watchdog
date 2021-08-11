import { User } from "@shared/models/user/user";
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'userInitials'
})
export class UserInitialsPipe implements PipeTransform {
    transform(value: User): string {
        return value.firstName.substr(0, 1).toUpperCase() + value.lastName.substr(0, 1).toUpperCase();
    }
}
