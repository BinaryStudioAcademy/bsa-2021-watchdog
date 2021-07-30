import { Component } from '@angular/core';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.sass']
})
export class LoginFormComponent {
    public isChecked : boolean;
    public email : String;

    constructor() {
        this.isChecked = false;
    }
}
