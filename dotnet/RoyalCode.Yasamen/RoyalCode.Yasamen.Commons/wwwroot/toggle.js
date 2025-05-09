
let fn = (function () {

    let _toggle = {};

    _toggle.between = function (element, cssClassTrue, cssClassFalse, toggle) {
        if (toggle) {
            element.classList.remove(cssClassFalse);
            element.classList.add(cssClassTrue);
        } else {
            element.classList.add(cssClassFalse);
            element.classList.remove(cssClassTrue);
        }
    };

    _toggle.toggle = function (element, cssClass, add) {
        if (add) {
            console.log('toggle add ' + cssClass + ' to ' + element );
            element.classList.add(cssClass);
        } else {
            console.log('toggle remove ' + cssClass + ' to ' + element);
            element.classList.remove(cssClass);
        }
    };

    return _toggle;
})();

export function between(element, cssClassTrue, cssClassFalse, toggle) {
    fn.between(element, cssClassTrue, cssClassFalse, toggle);
}
export function toggle(element, cssClass, add) {
    fn.toggle(element, cssClass, add);
}

export function bodyToggle(cssClass, add) {
    fn.toggle(document.body, cssClass, add);
}