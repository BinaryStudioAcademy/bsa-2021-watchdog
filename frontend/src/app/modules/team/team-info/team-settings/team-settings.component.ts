import { BaseComponent } from "@core/components/base/base.component";
import { PrimeIcons } from "primeng/api";
import { ConfirmWindowService } from "@core/services/confirm-window.service";
import { UpdateTeam } from "@shared/models/team/update-team";
import { TeamService } from "@core/services/team.service";
import { Observable, of } from "rxjs";
import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { FormGroup, FormBuilder, Validators, FormControl, AsyncValidatorFn, AbstractControl } from "@angular/forms";
import { Team } from '@shared/models/team/team';
import { catchError, delay, map, switchMap, take } from "rxjs/operators";

@Component({
    selector: 'app-team-settings',
    templateUrl: './team-settings.component.html',
    styleUrls: ['./team-settings.component.sass']
})
export class TeamSettingsComponent extends BaseComponent implements OnInit {
    isLoading: boolean = false;
    @Input() team: Team;
    @Input() reset: Observable<void>;
    @Input() save: Observable<void>;

    formGroup: FormGroup = new FormGroup({});
    constructor(private fb: FormBuilder, private teamService: TeamService, private confirmService: ConfirmWindowService) { super(); }

    @Output() canSave: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() wasRemoved: EventEmitter<void> = new EventEmitter<void>();

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: new FormControl(this.team.name, [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(50),
                Validators.pattern(new RegExp('^[\\w_-]+$')),
            ], [this.validateName])
        });

        this.save.subscribe(() => {
            this.isLoading = true;
            const updatedTeam: UpdateTeam = { ...this.formGroup.value };
            this.teamService.updateTeam(this.team.id, updatedTeam)
                .subscribe((t) => {
                    Object.assign(this.team, t);
                    this.isLoading = false;
                    this.canSave.emit(false);
                })
        });
        this.reset.subscribe(() => {
            this.formGroup.reset(this.team);
        });
        this.formGroup.statusChanges.subscribe(() => {
            this.checkSaveStatus();
        });
    }

    removeTeam() {
        this.confirmService.confirm({
            title: "Remove Team #" + this.team.name,
            message: "Are you sure, you want to delete this team?",
            icon: PrimeIcons.BAN,
            acceptButton: { class: "p-button-outlined p-button-danger" },
            cancelButton: { class: "p-button-outlined p-button-secondary" },
            accept: () => {
                this.isLoading = true;
                this.teamService.removeTeam(this.team.id)
                    .subscribe(() => {
                        this.wasRemoved.next();
                        this.isLoading = false;
                    });
            }
        });
    }

    checkSaveStatus() {
        if (this.formGroup.untouched || this.formGroup.pending || this.formGroup.invalid) {
            this.canSave.next(false);
        }
        if (this.formGroup.valid && (this.formGroup.touched || this.formGroup.dirty)) {
            const unsavedChangesProps = Object.keys(this.formGroup.controls).filter(key => this.formGroup.controls[key].value != this.team[key]);

            if (unsavedChangesProps.length > 0) this.canSave.next(true);
            else this.canSave.next(false);
        }
    }

    validateName: AsyncValidatorFn = (control: AbstractControl) => {
        if (this.team?.name === this.name?.value) return of(null);

        return of(control.value).pipe(
            delay(500),
            switchMap((name) => this.teamService.isNameUnique(name).pipe(
                map(isUnique => isUnique ? null : of({ notUnique: true })),
                catchError(error => of({ serverError: true })))), take(1));
    }

    get name() {
        return this.formGroup.controls['name'];
    }
}
