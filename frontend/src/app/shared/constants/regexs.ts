export const regexs = {
    firstName: /^[a-zA-Z- ]*$/,
    lastName: /^[a-zA-Z- ]*$/,
    email: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
    password: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[_!#$%&'*+—/=?^`{|}~.,:;`"\\№@()<>[\]])[A-Za-z\d_!#$%&'*+—/=?^`{|}~.,:;`"\\№@()<>[\]]+$/,

    organizationName: /^[\w\s-!#$%&'*+—/=?^`{|}~]+$/,
    organizationSlag: /^[\w-]+$/,

    dashboardName: /^[a-zA-Z0-9-_. ]*$/,

    projectName: /^[a-zA-Z0-9-_ ]+$/,
    projectDescription: /^[a-zA-Z0-9-_!#$%&'*+—/=?^`{|}~.,:;`"\\№@()<>[\] ](.|\n)+$/,
    projectApiKey: /^[0-9A-Za-z-_]+$/,

    tileName: /^[a-zA-Z0-9-_. ]*$/,
    teamName: /^[\w-]+$/,
    issueEventIdGuid: /^[({]?[a-fA-F0-9]{8}[-]?([a-fA-F0-9]{4}[-]?){3}[a-fA-F0-9]{12}[})]?$/,

    testName: /^[a-zA-Z0-9-_ ]+$/,
};
