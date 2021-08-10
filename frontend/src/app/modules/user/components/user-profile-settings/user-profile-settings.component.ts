import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { User } from '@core/models/user';
import { UserUpdateDto } from '@core/models/userUpdate';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';

@Component({
    selector: 'app-user-profile-settings',
    templateUrl: './user-profile-settings.component.html',
    styleUrls: ['./user-profile-settings.component.sass']
})
export class UserProfileSettingsComponent extends BaseComponent implements OnInit, OnDestroy {
    public user: User;
    public editedUser: User;
    public userUpdate: UserUpdateDto;
    public userUpdateStartState: UserUpdateDto;
    public firstName: string;
    public lastName: string;

    public userId: number = 3;

    editProfileForm: FormGroup;

    constructor(
        private userService: UserService,
        private toastNotificationService: ToastNotificationService
    ) {
        super();
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
        this.user.firstName = editForm.value.firstName;
        this.user.lastName = editForm.value.lastName;
        this.user.email = editForm.value.email;
        this.user.avatar = editForm.value.avatar;

        this.userService.updateUsersById(this.userId, this.user)
            .pipe(this.untilThis)
            .subscribe(resp => {
                this.toastNotificationService.success('Profile has been updated');
                console.info(resp);
            });
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }
}
