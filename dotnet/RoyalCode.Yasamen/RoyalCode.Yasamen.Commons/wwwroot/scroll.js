
let fn = (function () {

    let _scroll = {};
    _scroll._wasScrolled = false;
    _scroll._registry = {};

    _scroll.register = function (listener) {

        const eventHandler = function () {
            const currentScroll = window.scrollY;

            if (currentScroll <= 0) {
                if (_scroll._wasScrolled) {
                    listener.invokeMethod('Scrolled', false);
                    _scroll._wasScrolled = false;
                }
            }
            else {
                if (!_scroll._wasScrolled) {
                    listener.invokeMethod('Scrolled', true);
                    _scroll._wasScrolled = true;
                }
            }
        }

        window.addEventListener('scroll', eventHandler);
        _scroll._registry[listener._id] = function () {
            window.removeEventListener('scroll', eventHandler);
        };
    };

    _scroll.unregister = function (listener) {
        const item = _scroll._registry[listener._id];
        if (item !== undefined) {
            delete _scroll._registry[listener._id];
            item();
        }
    };

    return _scroll;
})();

export function register(listener) { fn.register(listener); }
export function unregister(listener) { fn.unregister(listener); }
