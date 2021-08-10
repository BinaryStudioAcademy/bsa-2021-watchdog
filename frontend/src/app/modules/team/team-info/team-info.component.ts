import { Subject } from "rxjs";
import { ToastNotificationService } from "@core/services/toast-notification.service";
import { BaseComponent } from "@core/components/base/base.component";
import { TeamService } from "@core/services/team.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Team } from "@shared/models/team/team";

@Component({
    selector: 'app-team-info',
    templateUrl: './team-info.component.html',
    styleUrls: ['./team-info.component.sass']
})
export class TeamInfoComponent extends BaseComponent implements OnInit {
    team: Team;
    isSettings: boolean = false;
    isLoading: boolean = false;

    reset: Subject<void> = new Subject<void>();
    save: Subject<void> = new Subject<void>();

    @ViewChild("saveBut") saveButton: ElementRef<HTMLButtonElement>;
    constructor(
        private activatedRoute: ActivatedRoute,
        public teamService: TeamService,
        private router: Router,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.isLoading = true;
        this.activatedRoute.paramMap
            .pipe(this.untilThis)
            .subscribe(param => {
                this.teamService.getTeam(param.get('id'))
                    .pipe(this.untilThis)
                    .subscribe(team => {
                        this.team = team;
                        this.isLoading = false;
                    }, error => {
                        this.toastService.error(error);
                        this.isLoading = false;
                    });
            });
    }

    resetButtonsState(event: any) {
        if (event.index === 2) {
            this.isSettings = true;
        }
        else this.isSettings = false;
    }

    pickCanSaveState(state: boolean) {
        this.saveButton.nativeElement.disabled = !state;
    }

    removed() {
        this.router.navigate(['home/teams']);
    }
}
