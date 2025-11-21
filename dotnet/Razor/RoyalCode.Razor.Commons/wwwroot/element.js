
export function getProperty(element, property) {
    if (!element)
        return null;
    return element[property];
}

export function setProperty(element, property, value) {
    if (!element)
        return;
    element[property] = value;
}

export function invokeVoidMethod(element, methodName, args) {
    if (!element)
        return;
    element[methodName](...args);
}

export function invokeMethod(element, methodName, readProperties, args) {
    if (!element)
        return null;
    var result = element[methodName](...args);
    var returnObj = {};
    for (var i = 0; i < readProperties.length; i++) {
        var prop = readProperties[i];
        returnObj[prop] = element[prop];
    }
    return returnObj;
}

export function getRect(element) {
    if (!element)
        return null;
    const r = element.getBoundingClientRect();
    return {
        x: r.x,
        y: r.y,
        width: r.width,
        height: r.height,
        top: r.top,
        right: r.right,
        bottom: r.bottom,
        left: r.left
    };
}

/**
 * Selects the text of an input or textarea element or the content of a contenteditable element.
 * @param {any} element
 * @returns
 */
export function selectText(element) {
    if (!element)
        return;

    if (element.select) {
        element.select();
        return;
    }

    if (window.getSelection && document.createRange) {
        var range = document.createRange();
        range.selectNodeContents(element);
        var sel = window.getSelection();
        sel.removeAllRanges();
        sel.addRange(range);
        return;
    }
}