# FieldText - Sample

## Contrato de uso

**Entrada pública**: `<FieldText>` — namespace `RoyalCode.Razor.Forms`
**Grupo**: UI-INPUT
**Propósito**: Wrapper decorativo para texto estático dentro de grupos de campo — prefixo/sufixo textual. Aplica classe `ya-field-text`. **NÃO é um input**.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-INPUT-INPUT_FIELD
**Setup necessário**: `<YasamenStyles />` no `<head>`; usado exclusivamente dentro de `TextField`

## Regras rápidas

- **Use para**: prefixo ou sufixo textual fixo em `TextField` (ex: `https://`, `@`, `.com`, `kg`, `%`)
- **Evite quando**: o adorno é um badge colorido — use `FieldBadge`; quando é um botão de ação — use `FieldAction`; para input com binding — use `TextField`
- **Cuidado**: nunca usar com `@bind-Value` — é apenas um `<div>` estático, não aceita binding

## Exemplos

### `UIP-INPUT-INPUT_FIELD` — Prefixo e sufixo textual em TextField

Use nos slots `Prepend` ou `Append` de `TextField` para decorar o campo com texto fixo.

```razor
@* Prefixo de protocolo *@
<TextField @bind-Value="model.Site" Label="Site do projeto">
    <Prepend>
        <FieldText>https://</FieldText>
    </Prepend>
</TextField>

@* Sufixo de domínio *@
<TextField @bind-Value="model.Usuario" Label="Usuário">
    <Append>
        <FieldText>@empresa.com.br</FieldText>
    </Append>
</TextField>

@* Prefixo e sufixo combinados *@
<TextField @bind-Value="model.Slug" Label="URL da página">
    <Prepend>
        <FieldText>/produtos/</FieldText>
    </Prepend>
    <Append>
        <FieldText>.html</FieldText>
    </Append>
</TextField>
```

**API usada**: `ChildContent` (conteúdo textual)

## API relevante

- **Props/parâmetros**: `ChildContent: RenderFragment` (EditorRequired) — texto estático a exibir
- **Slots**: -
