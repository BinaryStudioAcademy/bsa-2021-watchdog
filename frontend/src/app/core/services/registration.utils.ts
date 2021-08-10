export const clear = <T>(object: T): T => {
    if (!object) {
        return null;
    }
    const newObject = {} as T;
    Object.keys(object).forEach(key => {
        const value = object[key];
        if (value === '') {
            newObject[key] = null;
        } else if (typeof value === 'object'){
            newObject[key] = clear(value);
        } else {
            newObject[key] = value;
        }});
    return newObject;
}