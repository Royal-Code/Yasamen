
// Startup flag to prevent multiple calls
let registered = false;

// Custom event name
const CHAR_COUNT_EVENT_NAME = 'inputCharCount';
const ARROW_UP_DOWN_EVENT_NAME = 'arrowUpDown';
const TRANSITION_ENDED_EVENT_NAME = 'transitionEnded';
const TRANSITIONEND_EVENT_NAME = 'transitionend';

export function afterWebStarted(blazor) {
    if (registered === false) {
        registerInputCharCount(blazor);
        registered = true;
    }
}

export function afterStarted(blazor) {
    afterWebStarted(blazor);
}

function registerInputCharCount(blazor) {
    initializeInputCharCount();
    blazor.registerCustomEventType(CHAR_COUNT_EVENT_NAME, {
        browserEventName: CHAR_COUNT_EVENT_NAME,
        createEventArgs: event => {
            const detail = event.detail || {};
            return {
                charCount: detail.charCount || 0
            };
        }
    });
    blazor.registerCustomEventType(ARROW_UP_DOWN_EVENT_NAME, {
        browserEventName: ARROW_UP_DOWN_EVENT_NAME,
        createEventArgs: event => {
            const detail = event.detail || {};
            return {
                key: detail.key || ''
            };
        }
    });
    blazor.registerCustomEventType(TRANSITION_ENDED_EVENT_NAME, {
        browserEventName: TRANSITIONEND_EVENT_NAME,
        createEventArgs: event => {
            return {
                elapsedTime: event.elapsedTime || 0,
                propertyName: event.propertyName || '',
                dataRef: event.target?.dataset?.ref || '',
                elementId: event.target?.id || ''
            };
        }
    });
}

// Custom event to count characters in inputs
// This script adds a custom event that counts the characters in inputs,
// and triggers an event when the input value changes.
function initializeInputCharCount() {

    

    // Function that triggers the custom event inputCharCount
    function dispatchCharCountEvent(inputElement) {
        const charCount = inputElement.value.length;
        const parent = inputElement.parentElement;
        if (!parent)
            return;

        const event = new CustomEvent(CHAR_COUNT_EVENT_NAME, {
            detail: { charCount },
            bubbles: true, // caso você queira capturar em elementos ancestrais
        });

        parent.dispatchEvent(event);
    }

    // Function that triggers the custom event arrowUpDown
    function dispatchArrowUpDownEvent(inputElement, event) {

        const arrowEvent = new CustomEvent(ARROW_UP_DOWN_EVENT_NAME, {
            detail: { key: event.key },
            bubbles: true, // caso você queira capturar em elementos ancestrais
        });

        inputElement.dispatchEvent(arrowEvent);
    }

    // Function to add listeners to an input
    function addListeners(input) {

        // adds the listener for character counting
        if (!input.__charCountListenerAttached) {
            input.addEventListener('input', () => dispatchCharCountEvent(input));
            input.__charCountListenerAttached = true; // evita adicionar múltiplos listeners
        }

        // adds the listener for ArrowUp and ArrowDown key events,
        // for inputs that have role="combobox"
        if (!input.__arrowUpDownListenerAttached && (input.getAttribute('role') === 'combobox')) {
            input.addEventListener('keydown', (event) => {

                let key = event.keyCode || event.which;
                if (key !== 32 && key !== 38 && key !== 40) {
                    return;
                }

                event.preventDefault();

                dispatchArrowUpDownEvent(input, event);
            });
            input.__arrowUpDownListenerAttached = true; // evita adicionar múltiplos listeners
        }
    }

    // Adds listeners for all existing inputs
    function initialize() {
        const inputs = document.querySelectorAll('input');
        inputs.forEach(addListeners);
    }

    // Observes the DOM for dynamically added inputs
    const observer = new MutationObserver(mutations => {
        mutations.forEach(mutation => {
            mutation.addedNodes.forEach(node => {
                if (node.nodeType !== 1) return;

                if (node.tagName === 'INPUT') {
                    addListeners(node);
                } else {
                    // Se o nó é um container, procura inputs dentro dele
                    const nestedInputs = node.querySelectorAll?.('input');
                    nestedInputs?.forEach(addListeners);
                }
            });
        });
    });

    // Start the observer to monitor the entire page
    observer.observe(document.documentElement, {
        childList: true,
        subtree: true,
    });

    // Initializes the inputs already present in the DOM
    initialize();
};
