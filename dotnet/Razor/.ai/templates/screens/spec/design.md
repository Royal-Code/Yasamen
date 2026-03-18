# Design - <Nome da Tela>

## Contexto Estrutural

- Shell de referência.
- Justificativa do shell.
- `Page Pattern` principal e justificativa.
- Rota, módulo ou contexto de navegação.

## Quadro As-Is / To-Be

### As-Is

- Estrutura atual da tela, quando existir.
- Principais problemas observados.

### To-Be

- Estrutura alvo da tela.
- Principais mudanças por zona.

## Zonas Funcionais

Para cada zona:

- nome da zona;
- objetivo da zona;
- prioridade na experiência;
- estados relevantes.

## `UIP-*` por Zona

Para cada zona, registrar:

- `UIP-*` selecionado;
- justificativa;
- compatibilidade com o `Page Pattern`;
- observação relevante de estado, responsividade ou interação.

## Mapeamento para Yasamen

Para cada `UIP-*` ou necessidade principal da tela, classificar:

- `Existente`
- `Composição com existentes`
- `Gap de componente`
- `Gap estrutural da tela`

Registrar:

- componente Yasamen ou composição sugerida;
- nota de adaptação relevante do `ui-map.md`, quando ajudar;
- impacto técnico;
- spec filha necessária, quando houver.

## Dependências de Componentes

- Componentes já existentes que a tela reutiliza.
- Componentes ausentes que precisam de spec.
- Ordem recomendada de implementação.
- Bloqueios, paralelismo e risco.

## Estados, Responsividade e Acessibilidade

- Estados de página e de zona.
- Regras Mobile, Tablet e Desktop.
- Foco, ordem lógica e observações mínimas de acessibilidade.

## Estratégia de Protótipo ou Implementação

- Onde a tela será materializada, se isso já estiver decidido.
- Se a saída é apenas handoff técnico, declarar explicitamente.
- Se houver prototipagem em docs ou host navegável, registrar o alvo.
- Registrar convenções locais de rota, menu, layout ou showcase, quando forem relevantes para o projeto.

## Riscos e Questões em Aberto

- Ambiguidades estruturais.
- Gaps de componente ainda não resolvidos.
- Dependências externas ao escopo da tela.

## Validação Esperada

- Verificação da cadeia `Shell -> Screen -> Page Pattern -> Zona -> UIP`.
- Revisão do mapeamento `UIP -> Yasamen`.
- Lista de specs filhas ou gaps que precisam ser tratados antes da implementação.

