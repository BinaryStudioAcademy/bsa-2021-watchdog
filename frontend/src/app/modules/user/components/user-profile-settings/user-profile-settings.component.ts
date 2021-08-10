import { AuthenticationService } from '@core/services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { User } from '@shared/models/user/user';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';

@Component({
    selector: 'app-user-profile-settings',
    templateUrl: './user-profile-settings.component.html',
    styleUrls: ['./user-profile-settings.component.sass']
})
export class UserProfileSettingsComponent extends BaseComponent implements OnInit {
    public user: User;

    //fake tets user with id = 1
    public userId: number = 1;

    editProfileForm: FormGroup;

    constructor(
        private authService: AuthenticationService,
        private userService: UserService,
        private toastNotificationService: ToastNotificationService
    ) {
        super();
        this.user = authService.getUser();
    }

    ngOnInit(): void {
        this.loadUser();
    }

    submit(editForm) {
        this.updateUser(editForm);
    }

    loadUser() {
        this.userService.getUserById(this.userId).subscribe((data: User) => {
            this.user = data;
        });
    }

    updateUser(editForm) {
        this.user = { ...this.user,
            firstName: editForm.value.firstName,
            lastName: editForm.value.lastName,
            email: editForm.value.email,
            avatarUrl: editForm.value.avatarUrl };

        this.userService.updateUsersById(this.userId, this.user)
            .pipe(this.untilThis)
            .subscribe(resp => {
                this.toastNotificationService.success('Profile has been updated');
                console.info(resp);
            });
    }
}
