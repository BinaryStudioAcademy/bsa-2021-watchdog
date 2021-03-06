import { Organization } from '@shared/models/organization/organization';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';
import { User } from '@shared/models/user/user';
import firebase from 'firebase/app';

@Component({
    selector: 'app-user-profile',
    templateUrl: './user-profile.component.html',
    styleUrls: ['./user-profile.component.sass']
})
export class UserProfileComponent extends BaseComponent implements OnInit {
    isSignByEmailAndPassword: boolean;
    user: User;
    organization: Organization;
    editForm: FormGroup = new FormGroup({});
    pass: FormGroup = new FormGroup({});

    @ViewChild('saveBut') saveButton: ElementRef<HTMLButtonElement>;

    constructor(
        private authService: AuthenticationService,
        private userService: UserService,
        private toastNotificationService: ToastNotificationService
    ) {
        super();
    }

    ngOnInit(): void {
        this.user = this.authService.getUser();
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(org => {
                this.organization = org;
            });
        this.editForm.statusChanges.pipe(this.untilThis);
        this.isSignByEmailAndPassword = this.authService.isUserSignByEmailAndPassword();
    }

    updateUser() {
        const user = {
            ...this.editForm.value,
            trelloUserId: this.editForm.controls.trelloUserId.value
        };
        if (user.firstName === this.user.firstName
            && user.lastName === this.user.lastName
            && user.email === this.user.email
            && user.trelloUserId === this.user.trelloUserId) {
            this.toastNotificationService.error("You haven't changed anything to make changes");
        } else {
            this.userService.updateUsersById(this.user.id, user)
                .pipe(this.untilThis)
                .subscribe(resp => {
                    this.toastNotificationService.success('Profile has been updated');
                    Object.assign(this.user, resp);
                    this.authService.setUser(this.user);
                }, error => {
                    this.toastNotificationService.error(error);
                });
        }
    }

    updatePassword() {
        const pass = { ...this.pass.value };
        if (pass.confirmPassword !== pass.newPassword && pass.newPassword !== pass.oldPassword) {
            this.toastNotificationService.error('Check if confirm and new password match');
        }
        if (pass.newPassword === pass.oldPassword) {
            this.toastNotificationService.error('The old password is equal to the new one. Enter another new password');
        }
        if (pass.confirmPassword === pass.newPassword && pass.newPassword !== pass.oldPassword) {
            const { currentUser } = firebase.auth();
            const credentials = firebase.auth.EmailAuthProvider
                .credential(currentUser.email, pass.oldPassword);

            currentUser.reauthenticateWithCredential(credentials)
                .then(() => {
                    this.authService.updatePassword(pass.confirmPassword);
                    this.toastNotificationService.success('Password has been updated');
                    this.pass.reset();
                })
                .catch(error => {
                    console.warn(error);
                    this.toastNotificationService.error('Current password is incorrect');
                });
        }
    }

    updateAll() {
        if (this.editForm.dirty && this.editForm.valid && this.pass.pristine) {
            this.updateUser();
        }
        if (this.pass.dirty && this.pass.valid && this.editForm.pristine) {
            this.updatePassword();
        }
        if (this.editForm.dirty && this.pass.dirty && this.editForm.valid && this.pass.valid) {
            const checkPassFields = { ...this.pass.value };
            const checkUserFields = { ...this.editForm.value };
            if (checkPassFields.oldPassword == null || checkPassFields.newPassword == null
                || checkPassFields.confirmPassword == null) {
                this.toastNotificationService.warning('Fill in all three fields to change your password');
            }
            if (checkUserFields.email === this.user.email && checkUserFields.firstName === this.user.firstName
                && checkUserFields.lastName === this.user.lastName && checkUserFields.trelloUserId === this.user.trelloUserId) {
                this.updatePassword();
            }
            if (checkUserFields.email !== this.user.email || checkUserFields.firstName !== this.user.firstName
                || checkUserFields.lastName !== this.user.lastName || checkUserFields.trelloUserId !== this.user.trelloUserId) {
                this.updateUser();
                this.updatePassword();
            }
        }
        if (this.editForm.pristine && this.pass.pristine) {
            this.toastNotificationService.warning('No field has been changed');
        }
    }

    reset() {
        this.editForm.reset(this.user);
        this.pass.reset();
    }
}
