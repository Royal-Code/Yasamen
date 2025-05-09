
export function setProperty(el, name, value) {
    if (el === null || el === undefined)
        return;

    el.style.setProperty(name, value);
}

export function getProperty(el, name) {
    if (el === null || el === undefined)
        return;

    return el.style.getProperty(name);
}

export function setVariable(el, name, value) {
    if (el === null || el === undefined)
        return;
    
    if (!name.startsWith('--'))
        name = "--" + name;
    
    el.style.setProperty(name, value);
}

export function setDocumentVariable(name, value)
{
    document.documentElement.style.setProperty(name, value);
}

export function getVariable(el, name) {
    if (el === null || el === undefined)
        return;
    
    if (!name.startsWith('--'))
        name = "--" + name;

    let value = el.style.getProperty(name);
    
    if (value === undefined)
        value = getDocumentVariable(name);

    if (value === undefined)
        value = lookupVariable(el.parent(), name);
    
    return value;
}

export function getDocumentVariable(name)
{
    if (!name.startsWith('--'))
        name = "--" + name;

    return getComputedStyle(document.documentElement).getPropertyValue(name);
}

export function lookupVariable(el, name)
{
    while (el !== undefined)
    {
        let value = getVariable(el, name);
        if (value !== undefined)
            return value;
        
        el = el.parent();
    }
}