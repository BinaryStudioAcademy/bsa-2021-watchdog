import { AlertCategory } from "./alert-category";
import { SpecialAlertSetting } from "./special-alert-setting";

export interface AlertSettings {
    alertCategory : AlertCategory,
    specialAlertSetting : SpecialAlertSetting
}