
const registry = {};

export function register(element, listener) {

    if (element === null || element === undefined)
        return;

    const eventHandler = async (evt) => {

        // check if the click target is the element or a child of the element
        let elementClicked = evt.target === element || element.contains(evt.target);

        let targetsClicked = "";
        let targetElements = registry[listener._id]["_targetElements"];
        if (targetElements !== undefined && targetElements.length > 0) {
            // check if the click target is one of the target elements or a child of the target elements
            for (const item of targetElements) {
                console.log("Checking target element: " + item.id, item.element);
                if (evt.target === item.element || item.element.contains(evt.target)) {
                    console.log("Target element clicked: " + item.id, item.element);
                    targetsClicked += item.id + ";";
                }
            }
        }

        // notify the listener
        let result = await listener.invokeMethodAsync('OnClickedAsync', elementClicked, targetsClicked);
        if (result !== undefined && result !== null && result.length > 0) {
            console.error(result);
        }
    }

    // get the body element
    let body = document.getElementsByTagName("body")[0];
    // if the body element don't exists then return
    if (body === null || body === undefined)
        return;

    // listen for click event
    body.addEventListener("click", eventHandler, false);

    // add the listener to the list
    registry[listener._id] = function () {
        body.removeEventListener("click", eventHandler);
    };
}

export function addTargetElement(listener, targetElement, id) {
    if (listener === null)
        return;

    const item = registry[listener._id];
    if (item === undefined) 
        return;

    if (item["_targetElements"] === undefined)
        item["_targetElements"] = [];

    item["_targetElements"].push({
        element: targetElement,
        id: id
    });
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