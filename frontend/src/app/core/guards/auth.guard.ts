import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private authService: AuthService) {}

    public canActivate() {
        return this.checkForActivation();
    }

    private checkForActivation() {
        if (this.authService.isAuthorized()) {
            return true;
        }

        this.router.navigate(['/']);

        return false;
    }
}
