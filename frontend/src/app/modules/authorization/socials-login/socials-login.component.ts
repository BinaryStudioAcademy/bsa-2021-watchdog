import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-socials-login',
    templateUrl: './socials-login.component.html',
    styleUrls: ['./socials-login.component.sass']
})
export class SocialsLoginComponent {

    constructor(
        private authService: AuthenticationService,
        private router: Router
    ) { }

    signInWithGitHub() {
        this.authService.signInWithGitHub(['home']);
    }

    signInWithGoogle() {
        this.authService.signInWithGoogle(['home']);
    }

    signInWithFacebook() {
        this.authService.signInWithFacebook(['home']);
    }

}
