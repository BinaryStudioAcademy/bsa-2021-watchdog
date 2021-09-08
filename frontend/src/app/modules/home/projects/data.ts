import { AlertCategory } from '@shared/models/alert-settings/alert-category';
import { AlertTimeInterval } from '@shared/models/alert-settings/alert-time-interval';
import { SpecialAlertType } from '@shared/models/alert-settings/special-alert-type';

export class Data {
    alertCategories = [
        { value: AlertCategory.None, label: 'None' },
        { value: AlertCategory.EveryNew, label: 'Permanent' },
        { value: AlertCategory.Special, label: 'Custom' }
    ];

    alertTypes = [
        { value: SpecialAlertType.OccurrencesOf, label: 'occurrences of' },
        { value: SpecialAlertType.UsersAffectedBy, label: 'users affected by' }
    ];

    alertTimeIntervals = [
        { value: AlertTimeInterval.OneMinute, label: 'one minute' },
        { value: AlertTimeInterval.FiveMinutes, label: '5 minutes' },
        { value: AlertTimeInterval.FifteenMinutes, label: '15 minutes' },
        { value: AlertTimeInterval.OneHour, label: 'one hour' },
        { value: AlertTimeInterval.OneDay, label: 'one day' },
        { value: AlertTimeInterval.OneWeek, label: 'one week' },
        { value: AlertTimeInterval.ThirtyDays, label: '30 days' }
    ];

    initAlertCategory = AlertCategory.None;
    initAlertsCount = 10;
    initSpecialAlertType = SpecialAlertType.OccurrencesOf;
    initAlertTimeInterval = AlertTimeInterval.OneMinute;
}
