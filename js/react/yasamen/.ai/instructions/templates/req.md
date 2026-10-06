# Template: `req-{slug}.md`

Caminho: `.ai/specs/spec-{slug}/req-{slug}.md`.

Regras do template:
- Gerar o documento sem marcador, sem `Responde:`, sem placeholder, sem citação (`>`) e sem checklist deste template.
- `[ELICITAR]`: obter do humano. `[DERIVAR]`: propor a partir de fonte verificada.
- Escrever critério de aceite em `Dado / Quando / Então`.
- Numerar critérios como `CA<n>`, a partir do próximo ID de `dec-{slug}.md`.
- Escrever uma informação por campo.

## Shape

```md
# Requirements — <Nome>

| Campo | Valor |
|---|---|
| Spec | spec-<slug> |
| Status | Draft |
| Prioridade | P1 |
| Roadmap | <seção do roadmap> |
| Domínio | src/lib/components/<dominio>/ |

## Objetivo
[ELICITAR]
Responde: quem obtém qual resultado observável?
<uma frase>

## Escopo
[ELICITAR]
Responde: quais comportamentos entram?
- <comportamento>
- <comportamento>

## Fora de escopo
[ELICITAR]
Responde: o que não entra nesta spec?
- <item>

## Casos de uso
[ELICITAR]
Responde: qual o uso principal, uma variação e um caso de borda?
- **Principal:** <descrição>
- **Variação:** <descrição>
- **Borda:** <descrição>

## Fluxo
[ELICITAR]
Responde: qual o caminho principal, as falhas relevantes, o estado vazio e o cancelamento?
1. <passo>
2. <passo>

## Requisitos funcionais
[DERIVAR]
Responde: quais props, eventos e comportamentos o componente expõe?
- <requisito>

## Acessibilidade
[ELICITAR]
Responde: quais papéis ARIA, teclas e regras de foco e contraste se aplicam?
- **Papel:** <role>
- **Teclado:** <tecla → ação>
- **Foco:** <regra>

## Paridade com o Razor
[DERIVAR]
Responde: qual o componente equivalente em `dotnet/Razor` e quais diferenças existem?
- **Equivalente:** <caminho ou N/A>
- **Diferença:** <descrição>

## Critérios de aceite
[ELICITAR]
Responde: qual comportamento observável prova que o requisito foi atendido?
- [ ] CA<n>: Dado <contexto>, quando <ação>, então <resultado>.
- [ ] CA<n>: Dado <contexto>, quando <ação>, então <resultado>.

## Regras deste documento
- Referenciar `CA<n>` em `test-{slug}.md` e `tasks-{slug}.md`. Não copiar o texto.
- Não alterar critério de aceite aprovado sem registrar `DC<n>` em `dec-{slug}.md`.
- Cada `CA<n>` tem pelo menos um `TC<n>` em `test-{slug}.md`.
```

## Checklist final

- [ ] Todo `CA<n>` é observável e usa `Dado / Quando / Então`.
- [ ] `Fora de escopo` preenchido.
- [ ] Acessibilidade e paridade com o Razor preenchidas ou marcadas `N/A` pelo humano.
- [ ] Nenhuma questão aberta escondida no texto. Questão vive em `dec-{slug}.md`.
