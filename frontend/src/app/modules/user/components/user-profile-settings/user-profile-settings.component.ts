import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { User } from '@core/models/user';
import { AuthService } from '@core/services/auth.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';
import { take } from 'rxjs/operators';

@Component({
    selector: 'app-user-profile-settings',
    templateUrl: './user-profile-settings.component.html',
    styleUrls: ['./user-profile-settings.component.sass']
})
export class UserProfileSettingsComponent implements OnInit {
    public user = {} as User;
    userName: string;
    userEmail: string;

    editProfileForm: FormGroup;

    constructor(private authService: AuthService, private userService: UserService,
        private toastNotificationService: ToastNotificationService) { }

    ngOnInit(): void {
        this.editProfileForm = new FormGroup(
            {
                firstName: new FormControl(this.user?.firstName),
                lastName: new FormControl(this.user?.lastName),
                email: new FormControl(this.user?.email)
            }
        );
    }

    submit(editForm) {
        this.user.password = editForm.value.password;
        this.userService.updateUser(this.user)
            .pipe(take(1))
            .subscribe(updatedUser => {
                this.authService.setUser(updatedUser);
                this.updateInfo();
                this.toastNotificationService.success('Information has been updated');
            });
    }

    updateInfo() {
        this.user = this.authService.getUser();
        this.userName = `${this.user.firstName} ${this.user.lastName}`;
        this.userEmail = this.user.email;
    }
}
