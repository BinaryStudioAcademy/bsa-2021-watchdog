import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '@core/models/user';
import { AuthService } from '@core/services/auth.service';
import { UserService } from '@core/services/user.service';
import { Subject } from 'rxjs';
import { take } from 'rxjs/operators';

@Component({
    selector: 'app-user-password-settings',
    templateUrl: './user-password-settings.component.html',
    styleUrls: ['./user-password-settings.component.sass']
})
export class UserPasswordSettingsComponent implements OnInit {

    public user = {} as User;

    changePasswordForm: FormGroup;

    constructor(private authService: AuthService, private userService: UserService) {
        this.user = this.authService.getUser();
        this.changePasswordForm = new FormGroup(
            {
                currentPassword: new FormControl(),
                newPassword: new FormControl()
            }
        );
    }

    ngOnInit(): void {
        this.user = this.authService.getUser();
    }

    submit(editForm) {
        this.user.password = editForm.value.newPassword
        this.userService.updateUser(this.user)
            .pipe(take(1))
            .subscribe(updatedUser =>
                this.authService.setUser(updatedUser)
            );
    }

    changePasswordVisibility(button: HTMLElement) {

        let input: Element = button.previousElementSibling;
        let icon: Element = button.firstElementChild;
        let iconClass: string = 'pi pi pi-eye';
        let inputType: string = 'password';

        if (input.getAttribute('type') === "password") {
            iconClass = 'pi pi-eye-slash';
            inputType = 'text';
        }
        icon.setAttribute('class', iconClass)
        input.setAttribute('type', inputType)
    }

}
