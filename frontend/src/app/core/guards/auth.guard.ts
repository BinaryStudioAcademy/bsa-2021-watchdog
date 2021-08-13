import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private authService: AuthenticationService,
        private router: Router
    ) { }

    canActivate() {
        if (this.authService.isAuthenticated()) {
            return true;
        }

        if (this.authService.getUser()) {
            this.router.navigate(['signup']);
            return false;
        }

        this.router.navigate(['signin']);
        return false;
    }
}
