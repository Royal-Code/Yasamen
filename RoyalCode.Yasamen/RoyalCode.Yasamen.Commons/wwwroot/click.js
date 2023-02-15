
var registry = [];

export function register(element, listener) {

    if (element === null || element === undefined)
        return;

    const eventHandler = async (evt) => {

        // check if the click target is the element or a child of the element
        let elementClicked = evt.target === element || element.contains(evt.target);

        // notify the listener
        var result = await listener.invokeMethodAsync('OnClickedAsync', elementClicked);
        if (result !== undefined && result !== null && result.length > 0) {
            console.error(result);
        }
    }

    // get the body element
    var body = document.getElementsByTagName("body")[0];
    // if the body element dont exists then return
    if (body === null || body === undefined)
        return;

    // listen for click event
    body.addEventListener("click", eventHandler, false);

    // add the listener to the list
    registry[listener._id] = function () {
        body.removeEventListener("click", eventHandler);
    };
}

export function unregister(listener) {

    if (listener === null)
        return;

    const item = registry[listener._id];
    if (item !== undefined) {
        delete registry[listener._id];
        item();
    }
}