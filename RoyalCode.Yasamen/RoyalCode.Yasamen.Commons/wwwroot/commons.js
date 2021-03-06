
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