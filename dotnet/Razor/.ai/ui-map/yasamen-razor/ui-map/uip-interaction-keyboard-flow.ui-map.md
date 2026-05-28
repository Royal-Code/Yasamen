# UIP-INTERACTION-KEYBOARD_FLOW - Keyboard Flow

## Componentes

**Principais**: nenhum dedicado para gestão de fluxo de teclado.

**Composição**:

1. Button / IconButton
- `cobertura`: recebe foco via tab nativo; ring de foco semitransparente (`focus-within:ring-{tema}-300/50`) aplicado automaticamente pelo CSS ya-btn; ripple acessível por teclado (Enter/Space dispara o onClick do botão HTML);
- `limitações`: nenhum gerenciamento de focus trap, roving focus, tab order explícito ou atalho de teclado;
- `nota`: 5;
- `justificativa`: foco visual está correto por padrão, mas não há API para controlar o fluxo de teclado.

2. FieldText / FieldAction
- `cobertura`: inputs HTML nativos — tab order natural, focus ring do browser aplicável;
- `limitações`: sem gestão de foco programático ou customização de tab index via API de componente;
- `nota`: 5;
- `justificativa`: fluxo de teclado básico funciona por padrão nos inputs.

3. Modal
- `cobertura`: overlay bloqueante — o foco deve ser gerenciado pelo desenvolvedor ao abrir; sem focus trap automático nativo [inferido: foco não é capturado automaticamente no modal pela lib];
- `limitações`: sem focus trap explícito — foco pode sair do modal pelo tab; sem retorno de foco ao elemento de origem ao fechar;
- `nota`: 3;
- `justificativa`: foco precisa ser gerenciado pelo app — a lib não provê focus trap.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `focus trap em Modal/OffCanvas`: sem suporte nativo — implementar via `@onkeydown` + lógica de foco em C# ou JS interop;
  - `atalhos de teclado`: nenhum suporte — implementar via `@onkeydown` global ou `EventListener` JS;
  - `roving focus em listas/menus`: não suportado — implementar com `tabindex` dinâmico;
  - `skip links`: implementar com `<a href="#conteudo-principal">` HTML puro + CSS para mostrar no foco;
  - `foco retornado após fechar modal`: não automático — chamar `.FocusAsync()` via referência de elemento após fechar modal.

- `tipo de adaptação`: nova implementação com composição + estilos
- `o que precisa ser feito`:
  - O CSS da biblioteca já estiliza corretamente o foco (ring semitransparente) nos componentes `ya-*` — nenhuma customização de foco visual necessária;
  - Para focus trap em modais: implementar com JS interop ou biblioteca de acessibilidade;
  - Para atalhos: usar `@onkeydown` na janela com lógica de dispatch;
  - Para tab order explícito: usar `tabindex` via `AdditionalAttributes` nos componentes.

## Como usar

### Foco visual (nativo — sem código adicional)

```razor
@* Focus ring é automático em todos os ya-* components *@
<Button Style="Themes.Primary" Label="Ação" OnClick="Executar" />
@* Ao receber foco por tab: ring-primary-300/50 aplicado via CSS ya-btn *@
```

### Tabindex explícito via AdditionalAttributes

```razor
<Button Style="Themes.Secondary" Label="Secundário"
        AdditionalAttributes="@(new Dictionary<string,object>{{"tabindex","2"}})" />
```

### Atalho de teclado global (implementação manual)

```razor
@code {
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("window.addEventListener", "keydown", 
                DotNetObjectReference.Create(this));
    }

    [JSInvokable]
    public Task OnKeyDown(string key)
    {
        if (key == "F2") { /* abrir criação */ }
        return Task.CompletedTask;
    }
}
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem focus trap automático em Modal/OffCanvas; sem gestão de roving focus; sem atalhos de teclado nativos; sem retorno automático de foco; todo teclado flow além do tab-order natural dos elementos HTML requer implementação manual ou biblioteca JS;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - A biblioteca fornece o visual de foco correto automaticamente (ring semitransparente) em todos os componentes interativos — base adequada;
  - Para keyboard flow completo (focus trap, roving focus, atalhos, skip links), toda a lógica precisa ser implementada pelo app;
  - Nota 3 reflete que apenas o foco visual padrão é nativo — todo o comportamento de fluxo de teclado requer implementação customizada.
