# Button - Sample

## Visão geral
- **Propósito**: botão textual para ações primárias, secundárias, destrutivas, navegação e submit.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-ACTION-ACTION_BAR, PP-FORM, UIP-FEEDBACK-CONFIRMATION_DIALOG
- **Variações demonstradas**: tema, tamanho, outline, submit, evento de clique.

## Exemplos

### UIP-ACTION-ACTION_BAR

**Objetivo**: expor ação primária e secundária em barra operacional.

```razor
<Bar AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <Start><h2 class="font-medium">Pedidos</h2></Start>
    <End>
        <Button Label="Novo" Style="Themes.Primary" Size="Sizes.Small" OnClick="@Create" />
        <Button Label="Exportar" Style="Themes.Secondary" Size="Sizes.Small" Outline="true" />
    </End>
</Bar>

@code {
    private Task Create(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `Label`, `Style`, `Size`, `Outline`, `OnClick`.  
**Eventos relevantes**: `OnClick` dispara ao clicar.  
**Por que atende o pattern**: deixa a ação principal visível e rebaixa a ação alternativa.

### PP-FORM

**Objetivo**: submeter formulário com CTA primário.

```razor
<EditForm Model="model" OnValidSubmit="SaveAsync">
    <TextField Label="Nome" @bind-Value="model.Name" />
    <Button Label="Salvar" Type="ButtonTypes.Submit" Style="Themes.Primary" />
</EditForm>

@code {
    private FormModel model = new();
    private Task SaveAsync() => Task.CompletedTask;
    private sealed class FormModel { public string Name { get; set; } = string.Empty; }
}
```

**Props usadas**: `Type`, `Style`, `Label`.  
**Eventos relevantes**: sem evento direto; submit é tratado pelo `EditForm`.  
**Por que atende o pattern**: conecta captura textual e submissão controlada.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Label` | `string` | sempre que houver texto visível | define o rótulo do botão |
| `Style` | `Themes` | para semântica visual | muda cor e peso |
| `Size` | `Sizes` | para densidade | muda padding e fonte |
| `Outline` | `bool` | ação de menor peso | reduz competição com CTA |
| `Block` | `bool` | mobile ou ação de largura total | ocupa toda a largura |
| `NavigateTo` | `string?` | ação de navegação | navega sem handler custom |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnClick` | clique no botão | executar ação ou abrir overlay |

## Limitações
- `Label` é obrigatório por atributo nos usos observados.
- Loading visual não foi confirmado no `Button`.

## Combinações frágeis
- Misturar muitos `Themes` no mesmo grupo reduz hierarquia.
