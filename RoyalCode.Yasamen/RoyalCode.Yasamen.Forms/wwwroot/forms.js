
export function blurOnPressEnter(el) {
    let form = closest(el, 'FORM');
    if (form === false) {
        return;
    }

    el.addEventListener('keydown', evt => {
        if (evt.keyCode === 13) {
            var blured = blur(form, el);
            if (blured) {
                evt.preventDefault();
                return false;
            }
        }
    });
}

function closest(el, name) {
    if (el.nodeName === name)
        return el;
    if (el === document)
        return false;
    return closest(el.parentElement, name);
}

function blur(form, el) {
    let focusable = form.querySelectorAll('input:enabled:not([readonly]),select:enabled:not([readonly]),button:enabled,textarea:enabled:not([readonly])');
    let match = false;
    for (var item of focusable) {
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