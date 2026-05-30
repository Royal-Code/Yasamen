# UIP-CONTENT-DETAIL_BLOCK - Blueprint resumido

## Pattern

UIP-CONTENT-DETAIL_BLOCK — Detail Block — ver `uip-content-detail-block.ui-map.md`

## Gap coberto

A lib não tem componente de detail block. O gap é orientar a composição de seções de detalhe com `Box + Bar + <dl>` para grid de rótulo/valor, `Badge` para status, e skeleton de loading.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Box(Border.Box)` como container de seção; `Bar` com título + botão Editar; `<dl class="grid grid-cols-1 sm:grid-cols-2">` com `<dt>/<dd>` para atributos; `Badge` para campos de status.

## Componentes usados

- `Box` — papel: principal (container de seção) — ver `box.sample.md`
- `Bar` — papel: composição (header de seção) — ver `bar.sample.md`
- `Badge` — papel: composição (status de atributo) — ver `badge.sample.md`
- `Stack` — papel: composição (sequência de seções) — ver `stack.sample.md`
- `Button` — papel: composição (ação editar seção) — ver `button.sample.md`

## Recursos visuais

- `text-xs text-dark-400` — rótulo do atributo (`<dt>`)
- `text-sm font-medium text-dark-600` — valor do atributo (`<dd>`)
- `grid grid-cols-1 sm:grid-cols-2 gap-3` — layout responsivo de atributos
- `animate-pulse bg-light-200` — skeleton de loading

## Receita

`Box + Bar + <dl>` por seção; `Badge` para status; `Stack` para múltiplas seções; skeleton `animate-pulse`.

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
else
{
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
                    <dd class="text-sm text-dark-600">
                        @entidade.CriadoEm.ToString("dd/MM/yyyy")
                    </dd>
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
}
```

## Limites

- Sem componente dedicado de detail block — toda estrutura é HTML + Tailwind;
- Edição inline por campo: combinar com `uip-input-inline-editor.blueprint.md`;
- Campos vazios/nulos devem ser tratados explicitamente (mostrar "—" ou ocultar a linha).
