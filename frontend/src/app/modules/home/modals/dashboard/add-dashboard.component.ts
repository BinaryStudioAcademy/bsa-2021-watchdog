import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { regexs } from '@shared/constants/regexs';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { Organization } from '@shared/models/organization/organization';
import { User } from '@shared/models/user/user';
import { SelectItem } from 'primeng/api/selectitem';

@Component({
    selector: 'app-add-dashboard',
    templateUrl: './dashboard-template.html',
    styleUrls: ['./dashboard-template.sass']
})
export class AddDashboardComponent implements OnInit {
    title: string = 'Add dashboard';
    public formGroup: FormGroup = {} as FormGroup;
    selectedIcon: SelectItem;
    icons: SelectItem[];
    @Output() closeModal = new EventEmitter<void>();
    @Output() save = new EventEmitter<NewDashboard>();

    user: User;
    organization: Organization;

    constructor(
        private authService: AuthenticationService
    ) {
        this.icons = [
            { label: 'pi pi-chart-bar', value: 'pi-chart-bar' },
            { label: 'pi pi-chart-line', value: 'pi-chart-line' }
        ];
    }

    ngOnInit() {
        this.user = this.authService.getUser();
        this.authService.getOrganization()
            .subscribe(organization => {
                this.organization = organization;
            });
        this.formGroup = new FormGroup({
            name: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.dashboardName)
                ]
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
        this.save.emit(dashboard);
    }
}
