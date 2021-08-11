import { AlertTimeInterval } from './alert-time-interval';
import { SpecialAlertType } from './special-alert-type';

export interface SpecialAlertSetting {
    alertsCount: number,
    specialAlertType: SpecialAlertType,
    alertTimeInterval: AlertTimeInterval
}
