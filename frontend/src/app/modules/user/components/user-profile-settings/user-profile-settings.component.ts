import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { User } from '@core/models/user';
import { AuthService } from '@core/services/auth.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
    selector: 'app-user-profile-settings',
    templateUrl: './user-profile-settings.component.html',
    styleUrls: ['./user-profile-settings.component.sass']
})
export class UserProfileSettingsComponent extends BaseComponent implements OnInit, OnDestroy {
    public user = {} as User;
    userName: string;
    userEmail: string;
    public imageFile: File;
    isEditing: boolean;

    private unsubscribe$ = new Subject<void>();

    editProfileForm: FormGroup;

    constructor(
        private authService: AuthService,
        private userService: UserService,
        private toastNotificationService: ToastNotificationService)
        {
        super();
    }

    // public ngOnInit() {
    //     this.authService
    //         .getUser()
    //         .pipe(takeUntil(this.unsubscribe$))
    //         .subscribe((user) => (this.user = this.userService.getUserById(1)));
    // }

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
            .pipe(this.untilThis)
            .subscribe(resp => {
                this.authService.setUser(resp.body);
                this.updateInfo();
                this.toastNotificationService.success('Information has been updated');
            });
    }

    updateInfo() {
        this.user = this.authService.getUser();
        this.userName = `${this.user.firstName} ${this.user.lastName}`;
        this.userEmail = this.user.email;
    }

    loadUser() {

    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }

    public handleFileInput(target: any) {
        this.imageFile = target.files[0];

        if (!this.imageFile) {
            target.value = '';
            return;
        }

        if (this.imageFile.size / 1000000 > 5) {
            this.toastNotificationService.error(`Image can't be heavier than ~5MB`);
            target.value = '';
            return;
        }

        const reader = new FileReader();
        reader.addEventListener('load', () => (this.user.avatar = reader.result as string));
        reader.readAsDataURL(this.imageFile);
    }

}

