import { ButtonOptions } from './button-options';

export type ClickFunction = () => void;

export interface ConfirmOptions {
    title: string,
    message: string,
    icon?: string,
    isClosable?: boolean,
    acceptButton?: ButtonOptions,
    cancelButton?: ButtonOptions,
    accept?: ClickFunction,
    cancel?: ClickFunction,
}
