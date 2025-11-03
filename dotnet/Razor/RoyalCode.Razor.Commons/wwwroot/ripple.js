
export function ripple(el) {

    if (el === null || el === undefined)
        return false;

    const parent = el.parentElement;
    if (parent === null || parent === undefined)
        return false;

    // el: deve ser o span do ripple
    // parent: deve ser o elemento que contém o ripple
    // ao clicar em parent, o efeito ripple deve ser aplicado em el
    parent.addEventListener('click', evt => {
        if (evt.target == el)
            return;

        const rect = parent.getBoundingClientRect();

        let x = evt.clientX - rect.left;
        let y = evt.clientY - rect.top;

        const deltaX = Math.max(x, parent.offsetWidth - x);
        const deltaY = Math.max(y, parent.offsetHeight - y);
        const size = Math.sqrt(Math.pow(deltaX, 2) + Math.pow(deltaY, 2)) * 1.25;

        const currentStyle = globalThis.getComputedStyle(parent, null);
        const display = currentStyle.getPropertyValue('display');
        // se display for flex, verificar alinhamento para ajustar o ponto inicial
        if (display !== null && display.includes('flex')) {
            const ajustX = currentStyle["justify-content"] === "center" ? (size / 2) : 0;
            const ajustY = currentStyle["align-items"] === "center" ? (size / 2) : 0;
            x = x - ajustX;
            y = y - ajustY;
        } else {
            // Centraliza o círculo no ponto do clique
            x = x - size / 2;
            y = y - size / 2;
        }

        // Reinicia animação se já estava ativa
        el.classList.remove('ripple-animation');
        // Força reflow para permitir nova animação
        void el.offsetWidth;

        el.style.left = x + 'px';
        el.style.top = y + 'px';
        el.style.width = size + 'px';
        el.style.height = size + 'px';
        el.classList.add('ripple-animation');
    });

    // quando a animação acabar, remover a classe ripple e resetar as propriedades
    el.addEventListener('animationend', evt => {
        el.classList.remove('ripple-animation');
        el.style.left = '';
        el.style.top = '';
        el.style.width = '';
        el.style.height = '';
    });
}
