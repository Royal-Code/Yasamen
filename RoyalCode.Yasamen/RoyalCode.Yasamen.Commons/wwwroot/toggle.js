
var fn = (function () {

    var _toggle = {};

    _toggle.between = function (element, cssClassTrue, cssClassFalse, toggle) {
        if (toggle) {
            element.classList.remove(cssClassFalse);
            element.classList.add(cssClassTrue);
        } else {
            element.classList.add(cssClassFalse);
            element.classList.remove(cssClassTrue);
        }
    };

    return _toggle;
})();

export function between(element, cssClassTrue, cssClassFalse, toggle) {
    fn.between(element, cssClassTrue, cssClassFalse, toggle);
};