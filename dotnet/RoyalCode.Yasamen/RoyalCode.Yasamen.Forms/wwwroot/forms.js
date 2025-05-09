
const registry = {};

function closest(el, name) {

    if (el === null || el === undefined)
        return false;

    if (el.nodeName === name)
        return el;
    if (el === document)
        return false;
    return closest(el.parentElement, name);
}

function blur(form, el) {

    if (form === null || form === undefined || el === null || el === undefined)
        return false;

    let focusable = form.querySelectorAll('input:enabled:not([readonly]),select:enabled:not([readonly]),button:enabled:not(.field-button),textarea:enabled:not([readonly])');
    let match = false;
    for (let item of focusable) {
        if (item.offsetParent === null)
            continue;
        if (match === true) {
            item.focus();
            return true;
        } else if (item === el) {
            match = true;
        }
    }
    return false;
}

export function blurOnPressEnter(el) {
    let form = closest(el, 'FORM');
    if (form === false) {
        return;
    }

    el.addEventListener('keydown', evt => {
        if (evt.keyCode === 13) {
            let blured = blur(form, el);
            if (blured) {
                evt.preventDefault();
                return false;
            }
        }
    });
};

export function registerInputLength(element, listener) {

    if (element === null || element === undefined)
        return;

    const eventHandler = async (evt) => {

        const result = await listener.invokeMethodAsync('OnEventFiredAsync', evt.target.value.length.toString());
        if (result !== undefined && result !== null && result.length > 0) {
            console.error(result);
        }
    }

    element.addEventListener("input", eventHandler, false);
    registry[listener._id] = function () {
        element.removeEventListener("input", eventHandler);
    };
};

export function unregisterInputLength(listener) {
    if (listener === null)
        return;

    const item = registry[listener._id];
    if (item !== undefined) {
        delete registry[listener._id];
        item();
    }
}
