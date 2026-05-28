# Visual Language Evidence — {biblioteca}

Este template é um **guia de cobertura** para o artefato de auditoria interna. Organizar por eixo visual. Usar tabelas quando o volume de evidência justificar.

Este artefato NÃO é para consumo externo. Serve para rastrear decisões, validar força e resolver disputas.

---

## Fontes analisadas

| Fonte | Tipo | Eixos cobertos | Confiabilidade |
|---|---|---|---|
| `{path ou URI}` | `{token|docs|story|demo|código|screenshot}` | `{eixos}` | `{alta|média|baixa}` |

---

## Evidências por eixo visual

### {Eixo: identidade | hierarquia | spacing | zonas | ações | tipografia | cor | superfície | contenção | estados | responsividade}

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| `{primitiva|aplicada|síntese}` | `{o que foi observado}` | `{path ou URI da fonte}` | `{forte|fraca|inconclusiva}` | `{regra, recomendação, lacuna ou descartada}` |

---

## Contradições

| Tema | Fontes em conflito | Impacto | Decisão |
|---|---|---|---|
| `{tema}` | `{fonte A vs fonte B}` | `{impacto no contrato}` | `{qual prevaleceu e por quê}` |

---

## Lacunas

| Eixo | O que falta | Evidência encontrada | Impacto | Tratamento |
|---|---|---|---|---|
| `{eixo}` | `{gap}` | `{evidência fraca ou nenhuma}` | `{impacto nas etapas seguintes}` | `{pergunta ao humano, risco aceito ou revisão futura}` |

---

## Fontes descartadas ou inacessíveis

| Fonte | Motivo | Impacto |
|---|---|---|
| `{path ou URI}` | `{inacessível|irrelevante|desatualizado}` | `{impacto ou nenhum}` |

---

## Veredito de qualidade

- Cobertura visual: `{suficiente|parcial|insuficiente}` — {justificativa};
- Riscos para consumo externo: `{riscos identificados}`;
- Eixos com evidência forte: `{lista}`;
- Eixos com evidência fraca ou inconclusiva: `{lista}`;
- Pontos que exigem decisão humana: `{pontos ou nenhum}`.
