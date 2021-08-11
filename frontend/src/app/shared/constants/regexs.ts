export const regexs = {
    firstName: /^[a-zA-Z-]*$/,
    lastName: /^[a-zA-Z- ]*$/,
    email: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
    password: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&'*+—/=?^`{|}~])[A-Za-z\d!#$%&'*+—/=?^`{|}~]+$/,

    organizationName: /^[\w\s-!#$%&'*+—/=?^`{|}~]+$/,
    organizationSlag: /^[\w-]+$/,

    dashboardName: /^[a-zA-Z0-9_. ]*$/,

    projectName: /^[a-zA-Z0-9-_]+$/,
    teamName: /^[\w-]+$/,
};
