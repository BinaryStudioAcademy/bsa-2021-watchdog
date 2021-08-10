import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { SelectItem } from 'primeng/api/selectitem';

@Component({
    selector: 'app-add-dashboard',
    templateUrl: './dashboard-template.html',
    styleUrls: ['./dashboard-template.sass']
})
export class AddDashboardComponent implements OnInit {
    title: string = 'Add dashboard';
    public formGroup: FormGroup = {} as FormGroup;
    icons: SelectItem[];
    @Output() closeModal = new EventEmitter<void>();
    @Output() save = new EventEmitter<NewDashboard>();
    //fake data
    fakeOrganizationId = 1;
    fakeUserId = 1;
    //TODO Change fake by real data
    constructor() {
        this.icons = [
            { label: 'pi pi-chart-bar', value: 'pi-chart-bar' },
            { label: 'pi pi-chart-line', value: 'pi-chart-line' }
        ];
    }

    ngOnInit() {
        const namePattern = new RegExp('^[a-zA-Z0-9_. ]*$');
        this.formGroup = new FormGroup({
            name: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(namePattern)
                ]
            ),
            icon: new FormControl(
                '',
                [
                    Validators.required
                ]
            ),
        });
    }

    saveHandle(): void {
        const dashboard: NewDashboard = <NewDashboard> this.formGroup.value;
        dashboard.createdBy = this.fakeOrganizationId;
        dashboard.organizationId = this.fakeUserId;
        this.save.emit(dashboard);
    }
}
