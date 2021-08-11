import { regexs } from '@shared/constants/regexs';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { uniqueTeamNameValidator } from '@shared/validators/unique-team-name.validator';
import { BaseComponent } from '@core/components/base/base.component';
import { UpdateTeam } from '@shared/models/team/update-team';
import { TeamService } from '@core/services/team.service';
import { Observable } from 'rxjs';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Team } from '@shared/models/team/team';

@Component({
    selector: 'app-team-settings',
    templateUrl: './team-settings.component.html',
    styleUrls: ['./team-settings.component.sass']
})
export class TeamSettingsComponent extends BaseComponent implements OnInit {
    @Input() team: Team;
    @Input() reset: Observable<void>;
    @Input() save: Observable<void>;
    @Output() canSave: EventEmitter<boolean> = new EventEmitter<boolean>();

    formGroup: FormGroup = new FormGroup({});
    isLoading: boolean = false;

    constructor(
        private fb: FormBuilder,
        private teamService: TeamService,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: new FormControl(this.team.name, [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(50),
                Validators.pattern(regexs.teamName),
            ], [
                uniqueTeamNameValidator(this.team, this.teamService)
            ])
        });

        this.save.pipe(this.untilThis).subscribe(() => {
            this.isLoading = true;
            const teamValues: UpdateTeam = { ...this.formGroup.value };
            this.teamService.updateTeam(this.team.id, teamValues)
                .pipe(this.untilThis)
                .subscribe(updatedTeam => {
                    Object.assign(this.team, updatedTeam);
                    this.isLoading = false;
                    this.canSave.emit(false);
                    this.toastService.success('Team was saved!');
                }, error => {
                    this.isLoading = false;
                    this.canSave.emit(true);
                    this.toastService.error(error);
                });
        });

        this.reset.subscribe(() => {
            this.formGroup.reset(this.team);
        });

        this.formGroup.statusChanges.subscribe(() => {
            this.checkSaveStatus();
        });
    }

    checkSaveStatus() {
        if (this.formGroup.untouched || this.formGroup.pending || this.formGroup.invalid) {
            this.canSave.next(false);
        }
        if (this.formGroup.valid && (this.formGroup.touched || this.formGroup.dirty)) {
            const unsavedChangesProps = Object.keys(this.formGroup.controls)
                .filter(key =>
                    this.formGroup.controls[key].value !== this.team[key]);

            if (unsavedChangesProps.length > 0) this.canSave.next(true);
            else this.canSave.next(false);
        }
    }

    get name() {
        return this.formGroup.controls.name;
    }
}
