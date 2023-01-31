
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

    _toggle.toggle = function (element, cssClas, add) {
        if (add) {
            console.log('toggle add ' + cssClas + ' to ' + element );
            element.classList.add(cssClas);
        } else {
            console.log('toggle remove ' + cssClas + ' to ' + element);
            element.classList.remove(cssClas);
        }
    };

    return _toggle;
})();

export function between(element, cssClassTrue, cssClassFalse, toggle) {
    fn.between(element, cssClassTrue, cssClassFalse, toggle);
}
export function toggle(element, cssClas, add) {
    fn.toggle(element, cssClas, add);
}