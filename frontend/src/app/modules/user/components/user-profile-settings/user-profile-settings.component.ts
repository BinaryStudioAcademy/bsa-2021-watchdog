import { HttpResponse } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
    public userUpdate: UserUpdateDto;
    public userUpdateStartState: UserUpdateDto;
    public firstName: string;
    public lastName: string;
    public email: string;
    public userId: number = 3;

    editProfileForm: FormGroup;

    constructor(
        private userService: UserService,
        private fb: FormBuilder,
        private toastNotificationService: ToastNotificationService
    ) {
        super();
    }

    ngOnInit(): void {
        this.editProfileForm = this.fb.group({
            firstName: ['', [Validators.required, Validators.maxLength(32)]],
            lastName: ['', [Validators.required, Validators.maxLength(32)]],
            email: ['', [Validators.required, Validators.maxLength(32)]]
        });

        this.userService.getUserById(this.userId)
            .subscribe(
                (resp) => {
                    this.Initialize(resp);
                },
                (error) => {
                    console.error(error.message);
                }
            );
    }

    submit(editForm) {
        this.getValuesForUpdateInfo();
        this.userService.updateUser(this.userUpdate)
            .subscribe(resp => {
                this.toastNotificationService.success('Information has been updated');
                window.location.reload();
            },
            error => {
                this.toastNotificationService.error('An error occured while updating the profile');
            });
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }

    private Initialize(resp: HttpResponse<User>) {
        this.userUpdateStartState = resp.body;
        this.editProfileForm.patchValue({
            firstName: this.userUpdateStartState.firstName,
            lastName: this.userUpdateStartState.lastName,
            email: this.userUpdateStartState.email
        });
    }

    private getValuesForUpdateInfo() {
        this.userUpdate = {
            id: this.userId,
            firstName: this.editProfileForm.get('firstName').value,
            lastName: this.editProfileForm.get('lastName').value,
            email: this.editProfileForm.get('email').value
        };
    }
}
