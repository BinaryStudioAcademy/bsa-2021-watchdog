import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '@core/models/user';
import { AuthService } from '@core/services/auth.service';
import { UserService } from '@core/services/user.service';
import { Subject } from 'rxjs';
import { take } from 'rxjs/operators';

@Component({
    selector: 'app-user-profile-settings',
    templateUrl: './user-profile-settings.component.html',
    styleUrls: ['./user-profile-settings.component.sass']
})
export class UserProfileSettingsComponent implements OnInit {

    public user = {
        id: 0,
        email: 'test@test',
        password: 'das',
        firstName: 'test',
        lastName: 'test'
    } as User;
    private unsubscribe$ = new Subject<void>();

    editProfileForm = new FormGroup(
        {
            firstName: new FormControl(this.user?.firstName),
            lastName: new FormControl(this.user?.lastName),
            email: new FormControl(this.user?.email)
        }
    );

    constructor(private authService: AuthService, private userService: UserService) {
        this.authService.login({ email: 'test@test', password: 'test' }).subscribe();
    }

    ngOnInit(): void {
        this.user = this.authService.getUser();
    }

    submit(editForm) {
        console.log(this.editProfileForm.controls['firstName'].valid)
        // this.user.email = editForm.value.email
        // this.user.firstName = editForm.value.firstName
        // this.user.lastName = editForm.value.lastName
        // this.userService.updateUser(this.user)
        //     .pipe(take(1))
        //     .subscribe(updatedUser =>
        //         this.authService.setUser(updatedUser)
        //     );
    }

}
