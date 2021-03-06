import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { DashboardService } from '@core/services/dashboard.service';
import { regexs } from '@shared/constants/regexs';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { Organization } from '@shared/models/organization/organization';
import { User } from '@shared/models/user/user';
import { createDashboardValidator } from '@shared/validators/unique-dashboard-name.validator';
import { SelectItem } from 'primeng/api/selectitem';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { icons } from './icons-list';

@Component({
    selector: 'app-add-dashboard',
    templateUrl: './dashboard-template.html',
    styleUrls: ['./dashboard-template.sass']
})
export class AddDashboardComponent implements OnInit {
    title: string = 'Add dashboard';
    public formGroup: FormGroup = {} as FormGroup;
    selectedIcon: SelectItem;
    icons: SelectItem[] = icons;
    dashboard = {} as NewDashboard;

    user: User;
    organization: Organization;

    constructor(
        private authService: AuthenticationService,
        private dialogRef: DynamicDialogRef,
        private dashboardService: DashboardService
    ) { }

    ngOnInit() {
        this.user = this.authService.getUser();
        this.authService.getOrganization()
            .subscribe(organization => {
                this.organization = organization;
            });
        this.formGroup = new FormGroup({
            name: new FormControl(
                '', {
                    validators: [
                        Validators.required,
                        Validators.minLength(3),
                        Validators.maxLength(50),
                        Validators.pattern(regexs.dashboardName)
                    ],
                    asyncValidators: [
                        createDashboardValidator(this.dashboard, this.dashboardService, this.organization.id)
                    ]
                }
            )
        });
        this.selectedIcon = { label: 'pi pi-chart-bar', value: 'pi-chart-bar' };
    }

    onSelect(icon: SelectItem): void {
        this.selectedIcon = icon;
    }

    saveHandle(): void {
        const dashboard: NewDashboard = <NewDashboard> this.formGroup.value;
        dashboard.icon = this.selectedIcon.value;
        dashboard.createdBy = this.user.id;
        dashboard.organizationId = this.organization.id;
        this.close(dashboard);
    }

    close(dashboard?: NewDashboard) {
        this.dialogRef.close(dashboard);
    }

    get name() { return this.formGroup.controls.name; }
}
