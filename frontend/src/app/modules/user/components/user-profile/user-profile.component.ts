import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-user-profile',
    templateUrl: './user-profile.component.html',
    styleUrls: ['./user-profile.component.sass']
})
export class UserProfileComponent implements OnInit {
    isSignByEmailAndPassword: boolean;

    constructor(private authService: AuthenticationService) {

    }
    ngOnInit(): void {
        this.isSignByEmailAndPassword = this.authService.isUserSignByEmailAndPassword();
    }
}
