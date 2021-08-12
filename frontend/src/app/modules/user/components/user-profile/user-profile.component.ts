import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';
import { User } from '@shared/models/user/user';

@Component({
    selector: 'app-user-profile',
    templateUrl: './user-profile.component.html',
    styleUrls: ['./user-profile.component.sass']
})
export class UserProfileComponent extends BaseComponent implements OnInit {
    isSignByEmailAndPassword: boolean;
    public user: User;

    @Input() editForm: FormGroup;

    constructor(
        private authService: AuthenticationService,
        private userService: UserService,
        private toastNotificationService: ToastNotificationService
    ) {
        super();
        this.user = authService.getUser();
    }

    ngOnInit(): void {
        this.isSignByEmailAndPassword = this.authService.isUserSignByEmailAndPassword();
    }

    updateUser(editForm) {
        this.user = { ...this.user,
            firstName: editForm.value.firstName,
            lastName: editForm.value.lastName,
            email: editForm.value.email };

        this.userService.updateUsersById(this.user.id, this.user)
            .pipe(this.untilThis)
            .subscribe(resp => {
                this.toastNotificationService.success('Profile has been updated');
                console.info(resp);
            });
    }
}
