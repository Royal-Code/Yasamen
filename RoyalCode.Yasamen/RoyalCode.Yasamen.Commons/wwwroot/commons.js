
export function getProperty(reference, property) {
    if (reference !== undefined) {
        return reference[property];
    }
}

export function setProperty(reference, property, value) {
    if (reference !== undefined) {
        reference[property] = value;
    }
}

export function readProperty(path) {
    let names = path.indexOf('.') > 0 ? path.split('.') : [path];
    let value = window;
    for (let i = 0; i < names.length; i++) {
        if (value !== undefined)
            value = value[names[i]];
    }
    return value;
}

export function callMethod(reference, method, timeout) {
    if (reference !== undefined) {
        if (typeof reference[method] === 'function') {
            let args = arguments.length <= 3 ? [] : Array.prototype.slice.call(arguments, 3);
            if (timeout > 0) {
                setTimeout(() => reference[method].apply(reference, args), timeout);
            } else {
                return reference[method].apply(reference, args);
            }
        }
    }
}

// functions to manage local storage

export function setLocalStorageItem(key, value) {
    localStorage.setItem(key, value);
}

export function getLocalStorageItem(key) {
    return localStorage.getItem(key);
}

export function removeLocalStorageItem(key) {
    localStorage.removeItem(key);
}

// functions to manage session storage

export function setSessionStorageItem(key, value) {
    sessionStorage.setItem(key, value);
}

export function getSessionStorageItem(key) {
    return sessionStorage.getItem(key);
}

export function removeSessionStorageItem(key) {
    sessionStorage.removeItem(key);
}
