import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { User } from '@shared/models/user/user';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';

@Component({
    selector: 'app-user-profile-settings',
    templateUrl: './user-profile-settings.component.html',
    styleUrls: ['./user-profile-settings.component.sass']
})
export class UserProfileSettingsComponent extends BaseComponent implements OnInit {
    public user: User;

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
        this.editProfileForm = new FormGroup(
            {
                firstName: new FormControl(this.user?.firstName),
                lastName: new FormControl(this.user?.lastName),
                email: new FormControl(this.user?.email)
            }
        );
    }

    onSubmit() {
        this.userService.updateUser(this.user)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.toastNotificationService.success('Information has been updated');
            });
    }
}
