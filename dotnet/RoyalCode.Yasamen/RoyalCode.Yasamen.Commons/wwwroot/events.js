let fn = (function () {

    const _events = {};
    _events._registry = {};

    function getProperties(evt, requiredProperties) {
        let obj = {};

        if (requiredProperties.indexOf(',') > 0) {
            requiredProperties
                .split(',')
                .forEach((name) => getProperty(evt, name, obj));
        } else if (requiredProperties.length > 0) {
            getProperty(evt, requiredProperties, obj)
        }

        const json = JSON.stringify(obj);
        return json;
    }

    function getProperty(evt, name, obj) {
        if (name === 'target') {
            obj[name] = getTargetProperties(evt[name]);
        } else if (evt[name] !== undefined) {
            obj[name] = evt[name];
        }
    }

    function getTargetProperties(target) {

        let attributes = [];
        for (let attr of target.attributes) {
            attributes.push({
                name: attr.name,
                value: attr.value
            });
        }
        
        return {
            id: target.id,
            nodeName: target.nodeName,
            attributes: attributes
        }
    }

    _events.register = function (element, eventName, onlyTarget, preventDefault, stopPropagation, requiredProperties, listener) {

        if (element === null || element === undefined)
            return;

        const eventHandler = async (evt) => {

            if (onlyTarget && evt.target !== element) {
                return;
            }

            if (preventDefault)
                evt.preventDefault();

            if (stopPropagation)
                evt.stopPropagation();

            const json = getProperties(evt, requiredProperties);
            const result = await listener.invokeMethodAsync('OnEventFiredAsync', json);
            if (result !== undefined && result !== null && result.length > 0) {
                console.error(result);
            }
        }

        element.addEventListener(eventName, eventHandler, false);
        _events._registry[listener._id] = function () {
            element.removeEventListener(eventName, eventHandler);
        };
    };

    _events.unregister = function (listener) {
        if (listener === null)
            return;

        const item = _events._registry[listener._id];
        if (item !== undefined) {
            delete _events._registry[listener._id];
            item();
        }
    };

    return _events;

})();

export function register(element, eventName, onlyTarget, preventDefault, stopPropagation, requiredProperties, listener) {
    fn.register(element, eventName, onlyTarget, preventDefault, stopPropagation, requiredProperties, listener);
}

export function unregister(listener) {
    fn.unregister(listener);
}