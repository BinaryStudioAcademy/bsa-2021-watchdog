import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthenticationService } from '@core/services/authentication.service';

@Injectable({
    providedIn: 'root'
})
export class UnauthorizedGuard implements CanActivate {
    constructor(
        private authService: AuthenticationService,
        private router: Router
    ) {
    }

    canActivate() {
        if (this.authService.isAuthenticated()) {
            this.router.navigate(['home']).then(r => r);
            return false;
        }
        return true;
    }
}
