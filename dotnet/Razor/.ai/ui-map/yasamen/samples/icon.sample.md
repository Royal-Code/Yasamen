# Icon - Sample

## Visão geral
- **Propósito**: renderizar ícone por enum registrado ou fragment.
- **Complexidade**: 4
- **Patterns cobertos**: UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-EMPTY_STATE, UIP-CONTENT-MEDIA_VIEWER
- **Variações demonstradas**: enum e classes adicionais.

## Exemplos

### UIP-ACTION-ACTION_BAR

**Objetivo**: ícone dentro de botão custom.

```razor
<Button Label="Pesquisar" Style="Themes.Primary">
    <Icon Kind="BsIconNames.Search" AdditionalClasses="me-2" />
</Button>
```

**Props usadas**: `Kind`, `AdditionalClasses`.  
**Eventos relevantes**: nenhum direto.  
**Por que atende o pattern**: reforça ação com símbolo reconhecível.

### Conteúdo informativo

**Objetivo**: ícone em estado vazio.

```razor
<Box AdditionalClasses="p-8 text-center bg-white border border-light-300 rounded-md">
    <Icon Kind="BsIconNames.InfoCircle" AdditionalClasses="text-info-500 text-2xl" />
    <p class="mt-3">Nenhum resultado.</p>
</Box>
```

**Props usadas**: `Kind`, `AdditionalClasses`.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: dá pista visual sem criar novo componente.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Kind` | `Enum` | ícone registrado | renderiza ícone |
| `Fragment` | `IconFragment?` | ícone custom | render alternativo |
| `AdditionalClasses` | `string?` | tamanho/cor | aparência |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | ícone visual |

## Limitações
- Depende de factory/registro de ícones.

## Combinações frágeis
- Ícone sem texto pode não comunicar ação sozinho.
