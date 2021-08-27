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
            .pipe(this.untilThis)
            .subscribe(m => {
                this.member = m;
            })
        if (this.member.isApproved === true) {
            return true;
        }

        if (this.member.isApproved === false) {
            this.router.navigate(['landing']);
            return false;
        }
    }
}
