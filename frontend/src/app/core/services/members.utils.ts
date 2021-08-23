export const clear = (object: any, clearFunc: (value: string) => string = clearString): any => {
    if (object === null) {
        return null;
    }
    if (typeof object === 'string') {
        return clearFunc(object);
    }
    if (Array.isArray(object)) {
        return object.map(o => clear(o));
    }
    if (typeof object === 'object') {
        const newObject = {};
        Object.keys(object).forEach(key => {
            const value = object[key];
            const newKey = clearFunc(key);
            newObject[newKey] = clear(value);
        });
        return newObject;
    }
    return object;

};

export const clearString = (value: string) => {
    switch (value) {
        case 'member.user.firstName':
            return 'userFirstName';

        case 'member.user.email':
            return 'userEmail';

        case 'member.role.name':
            return 'roleName';

        case 'member.isAccepted':
            return 'isAccepted';
        default:
            return value;
    }
}