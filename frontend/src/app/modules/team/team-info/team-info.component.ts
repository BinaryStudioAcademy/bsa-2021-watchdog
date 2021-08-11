import { ConfirmWindowService } from "@core/services/confirm-window.service";
import { Subject } from "rxjs";
import { ToastNotificationService } from "@core/services/toast-notification.service";
import { BaseComponent } from "@core/components/base/base.component";
import { TeamService } from "@core/services/team.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Team } from "@shared/models/team/team";
import { PrimeIcons } from "primeng/api";

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
        private toastService: ToastNotificationService,
        private confirmService: ConfirmWindowService
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
        this.isSettings = event.index === 2 ? true : false;
    }

    setSaveState(state: boolean) {
        this.saveButton.nativeElement.disabled = !state;
    }

    removeTeam() {
        this.confirmService.confirm({
            title: "Remove Team #" + this.team.name,
            message: "Are you sure, you want to delete this team?",
            icon: PrimeIcons.BAN,
            acceptButton: { label: "Yes", class: "p-button-outlined p-button-danger" },
            cancelButton: { label: "No", class: "p-button-outlined p-button-secondary" },
            accept: () => {
                this.isLoading = true;
                this.teamService.removeTeam(this.team.id)
                    .pipe(this.untilThis)
                    .subscribe(() => {
                        this.isLoading = false;
                        this.router.navigate(['home/teams']).then(() => {
                            this.toastService.success("Team was removed!");
                        });
                    }, error => { this.toastService.error(error) });
            }
        });
    }
}
