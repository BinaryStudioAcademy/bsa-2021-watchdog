import { ToastNotificationService } from "@core/services/toast-notification.service";
import { SpinnerService } from "@core/services/spinner.service";
import { BaseComponent } from "@core/components/base/base.component";
import { TeamService } from "@core/services/team.service";
import { ActivatedRoute } from "@angular/router";
import { Component, OnInit } from '@angular/core';
import { Team } from "@shared/models/team/team";

@Component({
    selector: 'app-team-info',
    templateUrl: './team-info.component.html',
    styleUrls: ['./team-info.component.sass']
})
export class TeamInfoComponent extends BaseComponent implements OnInit {
    team: Team;
    constructor(
        private router: ActivatedRoute,
        public teamService: TeamService,
        private spinnerService: SpinnerService,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.spinnerService.show(true);
        this.router.paramMap.pipe(this.untilThis)
            .subscribe(param => {
                this.teamService.getTeam(param.get('id'))
                    .subscribe(team => {
                        this.team = team;
                        this.spinnerService.hide();
                    }, error => {
                        this.spinnerService.hide();
                        this.toastService.error(error);
                    });
            })
    }
}
