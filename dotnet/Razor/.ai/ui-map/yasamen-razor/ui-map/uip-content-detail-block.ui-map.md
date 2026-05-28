# UIP-CONTENT-DETAIL_BLOCK - Detail Block

## Componentes

**Principais**:

1. Box
- `cobertura`: container de seção de detalhe com borda e padding; agrupa atributos de uma seção lógica; `Border=BorderBuilder.Box` para delimitação;
- `nota`: 8;
- `justificativa`: container de seção de detalhe — separa visualmente grupos de atributos.

**Composição**:

1. Bar
- `cobertura`: header da seção de detalhe com título + ação de edição de seção (`EndContent`);
- `nota`: 8;
- `justificativa`: cabeçalho de seção com ação inline de edição localizada.

2. AsideBox (quando disponível) ou Container+Slot
- `cobertura`: layout de 2 colunas (rótulo + valor) para atributos lado a lado; Container com `cols-2` para grid de atributos;
- `nota`: 6;
- `justificativa`: grid de rótulo/valor lado a lado em desktop.

3. Stack
- `cobertura`: empilhamento de pares rótulo+valor em coluna única (mobile ou seção estreita);
- `nota`: 8;
- `justificativa`: sequência vertical de atributos com espaçamento coerente.

4. Badge
- `cobertura`: status e tags como parte dos atributos; `Themes.*` para semântica de estado;
- `nota`: 9;
- `justificativa`: indicador visual de status por atributo.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `layout rótulo/valor lado a lado responsivo`: usar `<dl class="grid grid-cols-1 sm:grid-cols-2 gap-3">` + `<dt>`/`<dd>`;
  - `skeleton de loading`: `<div class="animate-pulse bg-light-100 h-4 rounded w-32">`;
  - `edição inline de seção`: combinar com `UIP-INPUT-INLINE_EDITOR` por campo.

- `tipo de adaptação`: composição direta
- `o que precisa ser feito`:
  - `Box` como container de seção; `Bar` com título de seção + botão de editar;
  - Grid de rótulo/valor: HTML `<dl>` + Tailwind grid ou pares `<div class="flex gap-2">` + `<dt>`/`<dd>`;
  - `Badge` para status; `Stack` para layout coluna única mobile.

## Como usar

### Bloco de detalhe com seções

```razor
<Stack Gap="Gaps.Medium">
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        <Bar AdditionalClasses="mb-3">
            <StartContent>
                <h3 class="text-sm font-semibold text-dark-600">Dados gerais</h3>
            </StartContent>
            <EndContent>
                <Button Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                        Label="Editar" OnClick="EditarDadosGerais" />
            </EndContent>
        </Bar>
        <dl class="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div>
                <dt class="text-xs text-dark-400">Nome</dt>
                <dd class="text-sm font-medium text-dark-600">@entidade.Nome</dd>
            </div>
            <div>
                <dt class="text-xs text-dark-400">Documento</dt>
                <dd class="text-sm text-dark-600">@entidade.Documento</dd>
            </div>
            <div>
                <dt class="text-xs text-dark-400">Status</dt>
                <dd>
                    <Badge Style="@(entidade.Ativo ? Themes.Success : Themes.Danger)"
                           Text="@(entidade.Ativo ? "Ativo" : "Inativo")" />
                </dd>
            </div>
            <div>
                <dt class="text-xs text-dark-400">Criado em</dt>
                <dd class="text-sm text-dark-600">@entidade.CriadoEm.ToString("dd/MM/yyyy")</dd>
            </div>
        </dl>
    </Box>

    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        <Bar AdditionalClasses="mb-3">
            <StartContent>
                <h3 class="text-sm font-semibold text-dark-600">Endereço</h3>
            </StartContent>
            <EndContent>
                <Button Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                        Label="Editar" OnClick="EditarEndereco" />
            </EndContent>
        </Bar>
        <dl class="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div class="sm:col-span-2">
                <dt class="text-xs text-dark-400">Logradouro</dt>
                <dd class="text-sm text-dark-600">@entidade.Logradouro</dd>
            </div>
            <div>
                <dt class="text-xs text-dark-400">Cidade</dt>
                <dd class="text-sm text-dark-600">@entidade.Cidade</dd>
            </div>
            <div>
                <dt class="text-xs text-dark-400">Estado</dt>
                <dd class="text-sm text-dark-600">@entidade.Estado</dd>
            </div>
        </dl>
    </Box>
</Stack>
```

### Estado de loading com skeleton

```razor
@if (carregando)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        <div class="space-y-3">
            <div class="animate-pulse bg-light-200 h-4 rounded w-1/3"></div>
            <div class="animate-pulse bg-light-100 h-3 rounded w-2/3"></div>
            <div class="animate-pulse bg-light-100 h-3 rounded w-1/2"></div>
        </div>
    </Box>
}
```

## Decisão de uso

- `nota geral`: 6;
- `limitações`: sem componente dedicado de detail block; grid rótulo/valor requer HTML `<dl>` + Tailwind; skeleton manual; edição inline por seção é composição adicional;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Box` + `Bar` + HTML `<dl>` + `Badge` cobrem todas as variantes de detail block;
  - Composição direta e semântica — `<dl>/<dt>/<dd>` é o HTML correto para atributos;
  - Nota 6 reflete cobertura funcional com necessidade de composição manual de grid de atributos.
