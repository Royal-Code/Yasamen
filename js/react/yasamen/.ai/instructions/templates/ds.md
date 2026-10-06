# Template: `ds-{slug}.md`

Caminho: `.ai/specs/spec-{slug}/ds-{slug}.md`.

Regras do template:
- Gerar o documento sem marcador, sem `Responde:`, sem placeholder e sem checklist deste template.
- `[ELICITAR]`: obter do humano. `[DERIVAR]`: propor a partir de fonte verificada (código, `.ai/rules/`, Razor).
- Numerar riscos como `R<n>`, a partir do próximo ID de `dec-{slug}.md`.
- Escrever contrato de API em bloco TypeScript.

## Shape

```md
# Design — <Nome>

| Campo | Valor |
|---|---|
| Spec | spec-<slug> |
| Requisitos | req-<slug>.md |

## Arquitetura
[DERIVAR]
Responde: quais componentes, slots, contextos e providers compõem a solução?
- **Raiz:** `<Nome>`
- **Slots:** `<Nome>.<Slot>`
- **Contexto:** `<nome>-context.ts`

## Contrato público
[DERIVAR]
Responde: qual a assinatura TypeScript exportada?
```typescript
export interface <Nome>Props extends React.HTMLAttributes<HTMLElement> {
    theme?: Themes;
    size?: Sizes;
    className?: string;
}
```

## Temas e tamanhos
[ELICITAR]
Responde: quais temas e tamanhos o componente suporta?
- **Temas:** <lista ou ausência justificada>
- **Tema padrão:** <valor>
- **Tamanhos:** <lista ou ausência justificada>

## Classes CSS
[DERIVAR]
Responde: quais classes `ya-*` o componente define?
- **Arquivo:** `src/lib/styles/css/components/<nome>.css`
- **Mapeamento:** `src/lib/components/<dominio>/<nome>-classes.ts`
- **Base:** `ya-<nome>`
- **Variantes:** <lista de classes>

## Tokens
[DERIVAR]
Responde: quais tokens `@theme` e utilitários o CSS usa?
- **Cores:** <tokens>
- **Espaçamento:** <tokens>
- **Z-index:** <utilitário>

## Exportação e integração
[DERIVAR]
Responde: onde o componente é exportado e com quais módulos integra?
- **Export:** `src/lib/components/<dominio>/index.ts`, `src/lib/index.ts`
- **Integra com:** <módulo>

## Compatibilidade
[DERIVAR]
Responde: a mudança altera export, prop, classe `ya-*` ou token existente?
- **Altera API existente:** sim | não
- **Detalhe:** <descrição ou N/A>

## Riscos
[DERIVAR]
Responde: quais riscos técnicos e dependências não resolvidas existem?
- R<n>: <risco> — **Mitigação:** <ação>
- R<n>: <risco> — **Mitigação:** <ação>

## Regras deste documento
- Referenciar `CA<n>` de `req-{slug}.md`. Não copiar o texto.
- Alterar contrato público aprovado somente com `DC<n>` em `dec-{slug}.md`.
- Seguir `.ai/rules/` em toda decisão de código, CSS e tokens.
```

## Checklist final

- [ ] Contrato público compila como TypeScript.
- [ ] Toda classe `ya-*` segue `.ai/rules/css-contract.md`.
- [ ] Seção `Compatibilidade` preenchida.
- [ ] Todo risco tem mitigação.
