import { AbstractControl } from '@angular/forms';

export const time = (control: AbstractControl) => {
    const radix = 10;
    const [minutes, seconds] = (control.value as string).split(':').map(x => parseInt(x, radix));
    if (minutes > 59 || seconds > 59) {
        return { invalidTime: true };
    }
    return null;
};

export const json = (control: AbstractControl) => {
    if (control.value === '') {
        return null;
    }
    try {
        JSON.parse(control.value);
    } catch (error) {
        return { invalidFormat: error.message };
    }
    return null;
};

export const xml = (control: AbstractControl) => {
    if (DOMParser) {
        try {
            const obj = (new DOMParser()).parseFromString(control.value, 'application/xml');
            const parserError = obj.getElementsByTagName('parsererror');
            if (parserError.length) {
                const element = parserError[0].getElementsByTagName('div').item(0);
                return { invalidFormat: `XML parse error: ${element.innerText}` };
            }
        } catch (error) {
            return { invalidFormat: error.message };
        }
    }
    return null;
};
