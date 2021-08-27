import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { BaseComponent } from '@core/components/base/base.component';
import { Member } from '@shared/models/member/member';
import { AuthenticationService } from '../services/authentication.service';

@Injectable({ providedIn: 'root' })
export class ApprovedGuard extends BaseComponent implements CanActivate {
    member: Member;

    constructor(
        private authService: AuthenticationService,
        private router: Router,
    ) {
        super();
    }

    canActivate() {
        this.authService.getMember()
            .subscribe(m => {
                this.member = m;
                debugger;
            })
            debugger;
        if (this.member.isApproved === true) {
            this.router.navigate(['landing']);
            debugger;
            return true;
        }

        if (this.member.isApproved === false) {
            return false;
        }

        this.router.navigate(['**']);
        return false;
    }
}
