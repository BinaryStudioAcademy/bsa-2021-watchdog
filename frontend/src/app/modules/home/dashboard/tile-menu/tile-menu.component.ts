import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-tile-menu[dashboardId]',
    templateUrl: './tile-menu.component.html',
    styleUrls: ['./tile-menu.component.sass']
})
export class TileMenuComponent implements OnInit {
    menuListItems: MenuItem[];
    menuValueItems: MenuItem[];
    menuChartItems: MenuItem[];
    menuTextItems: MenuItem[];
    selectedItem?: string;

    @Output()
    closeMenu: EventEmitter<boolean> = new EventEmitter();

    @Input() dashboardId: number;

    constructor(private toastNotifications: ToastNotificationService) {

    }

    ngOnInit(): void {
        this.initFakeData(); // remove this
    }

    initFakeData() {
        this.menuTextItems = [
            {
                label: 'Errors per app',
                icon: 'pi pi-fw pi-ban'
            },
            {
                label: 'Error count',
                icon: 'pi pi-fw pi-align-justify'
            },
            {
                label: 'Audit log',
                icon: 'pi pi-fw pi-user'
            },
            {
                label: 'Events',
                icon: 'pi pi-fw pi-bell'
            },
            {
                separator: true
            },
            {
                label: 'Special',
                icon: 'pi pi-fw pi-power-off'
            }
        ];
        this.menuListItems = [...this.menuTextItems];
        this.menuChartItems = [...this.menuTextItems];
        this.menuValueItems = [...this.menuTextItems];
    }

    tileSelected(event?: any): void {
        const selectedItemText = <string>event.target.innerText;
        if (!selectedItemText || selectedItemText.includes('\n')) {
            return;
        }
        this.selectedItem = selectedItemText;
    }

    clearDashboardTiles() {
        // not implemented
        this.toastNotifications.warning('Tiles Cleared');
    }

    resetDashboardTiles() {
        // not implemented
        this.toastNotifications.warning('Tiles Reset');
    }

    saveChanges() {
        // not implemented
        this.toastNotifications.success('Saved');
        this.closeMenu.emit(true);
    }

    discardChanges() {
        this.closeMenu.emit(true);
    }
}
