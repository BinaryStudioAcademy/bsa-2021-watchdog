import { state } from '@angular/animations';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { UserUpdateDto } from '@core/models/userUpdate';
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
    public oldPassword: string;
    public newPassword: string;
    public confirmPassword: string;

    isSignByEmailAndPassword: boolean;
    user: User;
    users: UserUpdateDto;

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
        this.editForm.statusChanges.pipe(this.untilThis);

        // this.editForm.statusChanges.pipe(this.untilThis)
        // .subscribe(()=>{this.checkSaveStatus();});

        this.isSignByEmailAndPassword = this.authService.isUserSignByEmailAndPassword();
    }

    updateUser() {
        const user = {...this.editForm.value};
        this.userService.updateUsersById(this.user.id, user)
            .pipe(this.untilThis)
            .subscribe(resp => {
                this.toastNotificationService.success('Profile has been updated');
                Object.assign(this.user,resp);
            }, error=> {
                this.toastNotificationService.error(error);
            });
    }

    updatePassword() {
        const pass = {...this.pass.value};

        if (pass.confirmPassword !== pass.newPassword) {
            this.toastNotificationService.error('Сheck if confrim and new password match');
        }
        else {
            const { currentUser } = firebase.auth();
            const credentials = firebase.auth.EmailAuthProvider
                .credential(currentUser.email, pass.oldPassword);

            currentUser.reauthenticateWithCredential(credentials)
                .then(() => {
                    this.authService.updatePassword(pass.confirmPassword);
                    this.toastNotificationService.success('Password has been updated');
                })
                .catch(error => {
                    console.warn(error);
                    this.toastNotificationService.error('Current password is incorrect');
                });
        }


    }

     // if (this.newPassword === this.newPasswordRepeat) {
        //     const { currentUser } = firebase.auth();
        // const credentials = firebase.auth.EmailAuthProvider
        //     .credential(currentUser.email, this.oldPassword);

        // currentUser.reauthenticateWithCredential(credentials)
        //     .then(() => {
        //         this.authService.updatePassword(this.newPassword);
        //         this.toastNotificationService.success('Password has been updated');
        //     })
        //     .catch(error => {
        //         console.warn(error);
        //         this.toastNotificationService.error('Current password is incorrect');
        //     });
        // }
        // else {
        //     this.toastNotificationService.error('Input correct new password');
        // }

    checkSaveStatus() {
        if (this.editForm.untouched || this.editForm.pending || this.editForm.invalid) {
            this.setSaveButtonDisabled(true);
        }
        if (this.editForm.valid && (this.editForm.touched || this.editForm.dirty)) {
            const unsavedChangesProps = Object.keys(this.editForm.controls)
                .filter(key =>
                    this.editForm.controls[key].value !== this.user[key]);

            if (unsavedChangesProps.length > 0) this.setSaveButtonDisabled(false);
            else this.setSaveButtonDisabled(true);
        }
    }

    setSaveButtonDisabled(state:boolean){
        if(this.saveButton){
            this.saveButton.nativeElement.disabled = state;
        }
    }

    reset(){
        this.editForm.reset(this.user);
        this.pass.reset();
    }
}
