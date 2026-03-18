# Plano de Organização da Camada de IA

## Objetivo

Organizar melhor os artefatos de IA do repositório para suportar estes objetivos:

- ter guides que funcionem como base normativa e também como fonte de instrução para Copilot;
- separar claramente guides para expandir a biblioteca de guides para usar a biblioteca;
- manter instruções operacionais por tarefa e por domínio;
- manter templates e specs por domínio;
- reduzir atrito entre arquivos `.ai`, instruções do Copilot e agentes;
- abrir caminho para novos domínios, como criação de projeto Blazor, API, domínio, EF, mensageria e, no futuro, skills.

---

## Diagnóstico Atual

Hoje a base já tem bastante material útil, mas há 5 problemas de organização:

1. Existem arquivos demais no nível raiz de `.ai`.
2. Há mistura de papéis:
   - guides normativos;
   - instruções operacionais;
   - orquestradores;
   - templates;
   - specs concretas;
   - backlog e documentos de trabalho.
3. Os nomes ainda misturam:
   - domínio;
   - verbo da tarefa;
   - herança histórica;
   - arquivos legados.
4. A camada Copilot ainda carrega agentes e instruções legadas junto com a estrutura nova.
5. Ainda não existe uma separação explícita entre:
   - autoria da biblioteca;
   - uso da biblioteca em apps e telas;
   - scaffolding de novos projetos;
   - futura expansão para backend e outros domínios.

---

## Princípios de Organização

### 1. Domínio antes de tarefa

A navegação principal deve começar pelo domínio:

- `station`
- `lib-spec`
- `screen-spec`
- `yasamen`
- futuros domínios: `app-spec`, `api-spec`, `domain-spec`, `use-case-spec`, `ef-spec`, `messaging-spec`

As tarefas vivem dentro do domínio:

- `plan`
- `create`
- `refine`
- `implement`
- `review`
- `scaffold`

### 2. Guides são normativos

Guides devem responder:

- como pensar;
- quais regras seguir;
- quais padrões existem;
- quais decisões precisam ser tomadas.

Guides não devem virar catálogo solto de prompts.

### 3. Instructions são operacionais

Instructions devem responder:

- como executar uma tarefa;
- qual fluxo seguir;
- que artefatos ler, criar ou atualizar.

### 4. Templates são contratos

Templates devem existir por domínio e por tipo de artefato.

### 5. Agentes devem ser poucos e finos

A lógica deve viver mais nos guides e instructions do que nos agentes.

Agentes ideais:

- `spec-station`
- `lib-spec`
- `screen-spec`
- `yasamen`

Demais agentes devem tender a:

- virar legados temporários;
- ou virar especializações futuras quando houver volume real.

### 6. Skills entram por último

Skills só valem a pena quando:

- o domínio já está estável;
- o fluxo já foi validado com guides e instructions;
- existe ganho real em encapsular conhecimento ou ferramentas.

---

## Estrutura-Alvo Recomendada

Não recomendo um big bang. A estrutura-alvo pode ser perseguida em etapas.

### Camada 1. Entrada

Arquivos de entrada humana e roteamento:

- `.ai/station.md`
- `.ai/lib-spec.md`
- `.ai/screen-spec.md`

Regra:

- manter apenas estes como entradas ativas no topo de `.ai`;
- arquivos antigos como `.ai/spec.md` e `.ai/screen.md` devem continuar só como redirect de compatibilidade.

### Camada 2. Conhecimento normativo

Pasta:

- `.ai/guides/`

Subgrupos recomendados no conteúdo, mesmo que os arquivos não sejam movidos ainda:

- `core`
- `lib-authoring`
- `lib-usage`
- `screen`
- `workflow`
- `future-domains`

### Camada 3. Fluxos operacionais

Pasta:

- `.ai/instructions/`

Agrupamento lógico desejado:

- `station`
- `lib-spec`
- `screen-spec`
- `project-scaffolding`

Mesmo que os arquivos continuem na pasta atual no curto prazo, o README deve mostrar esse agrupamento.

### Camada 4. Templates

Pasta por domínio:

- `.ai/specs/_template/`
- `.ai/screen-specs/_template/`

No futuro:

- `.ai/app-specs/_template/`
- `.ai/api-specs/_template/`

### Camada 5. Artefatos de referência

Hoje já existe:

- `.ai/ui-map/`

Recomendação:

- tratá-la como base de referência de produto e cobertura;
- no futuro, mover também protocolos externos adaptados para uma área de referência mais clara.

### Camada 6. Backlog e planos

Hoje:

- `.ai/a_fazer/`

Recomendação:

- manter `a_fazer` por enquanto;
- separar melhor:
  - `planos`
  - `em_estudo`
  - `feito`
  - `referencias_externas`

---

## Convenção de Nomes

### O que manter

Estes nomes estão bons e devem continuar:

- `station`
- `lib-spec`
- `screen-spec`
- `yasamen`

### O que melhorar

#### 1. Root aliases

Manter poucos aliases no topo de `.ai`.

Meta:

- só `station.md`, `lib-spec.md`, `screen-spec.md` como entradas ativas;
- `spec.md` e `screen.md` apenas como legado.

#### 2. Instructions

Hoje os nomes são aceitáveis, mas podem evoluir para um padrão por domínio.

Exemplo conceitual futuro:

- `lib-spec/plan.md`
- `lib-spec/create.md`
- `lib-spec/refine.md`
- `lib-spec/implement.md`
- `lib-spec/select-next.md`
- `lib-spec/scaffold-project.md`

- `screen-spec/plan.md`
- `screen-spec/create.md`
- `screen-spec/refine.md`

Não precisa mover já. Basta assumir esse modelo como direção.

#### 3. Guides

Os guias numerados funcionam, mas dificultam crescimento e agrupamento.

Direção recomendada:

- manter os arquivos atuais no curto prazo para não quebrar links;
- fortalecer um índice temático;
- no médio prazo, avaliar renomear ou espelhar por categoria.

Exemplo de categorias:

- `core/project-structure`
- `core/styles-and-css`
- `lib/component-anatomy`
- `lib/form-components`
- `lib/navigation-patterns`
- `workflow/spec-execution-and-delivery`
- `screen/planning-and-ui-mapping`
- `usage/showcases-and-docs`

#### 4. Agentes

Agentes ativos recomendados:

- `spec-station`
- `lib-spec`
- `screen-spec`
- `yasamen`

Agentes legados ou especializados devem ser reduzidos de protagonismo.

---

## Taxonomia Recomendada

### 1. Guides de autoria da biblioteca

Servem para expandir Yasamen.

Exemplos:

- estrutura de projeto;
- CSS e contrato visual;
- anatomia de componente;
- formulários;
- composição;
- navegação;
- outlets;
- execução de spec.

### 2. Guides de uso da biblioteca

Servem para quem vai usar Yasamen em apps, telas e showcases.

Exemplos esperados:

- como montar um app que consome Yasamen;
- como estruturar shell e layouts;
- como compor telas com os componentes;
- como documentar showcases;
- como integrar temas e estilos da lib em um app.

Este grupo ainda está fraco e precisa crescer.

### 3. Instructions de domínio

Servem para dizer à IA como executar uma tarefa dentro de um domínio.

Domínios já existentes:

- `lib-spec`
- `screen-spec`

Domínios futuros:

- `app-spec`
- `api-spec`
- `domain-spec`

### 4. Templates de domínio

Servem para materializar o contrato de documentação e entrega.

### 5. Agentes finos

Servem como pontos de entrada e conveniência na UI do Copilot.

### 6. Skills

Servem para encapsular domínios maduros ou integrações específicas.

---

## Roadmap por Domínio

## Domínio 1. Governança da Camada de IA

### Objetivo

Ter uma arquitetura compreensível, com poucos pontos de entrada e baixa duplicação.

### Próximos passos

1. Criar um README raiz de `.ai` explicando:
   - o que é guide;
   - o que é instruction;
   - o que é template;
   - o que é spec;
   - o que é agente.
2. Marcar explicitamente o que é ativo e o que é legado.
3. Reduzir o protagonismo dos agentes antigos.
4. Consolidar uma matriz `domínio -> entrada -> instructions -> templates -> agentes`.

## Domínio 2. Lib Authoring

### Objetivo

Guiar criação e evolução da biblioteca Yasamen.

### Estado

É o domínio mais maduro hoje.

### Próximos passos

1. Consolidar a árvore de guides por categoria temática.
2. Criar um README temático para `lib-authoring`.
3. Revisar instruções para remover duplicações restantes.
4. Abrir o próximo domínio associado:
   - `app-spec` ou `project-spec`, para projetos Blazor que usam a lib.

## Domínio 3. Lib Usage

### Objetivo

Guiar criação de projetos e telas que consomem Yasamen.

### Estado

Ainda embrionário. Hoje parte disso aparece em:

- `screen-spec`
- `showcases-and-docs`
- `create-library-project`, mas este é focado em pacote da biblioteca, não em app consumidor.

### Próximos passos

1. Criar guides de uso da biblioteca:
   - consumir CSS e temas;
   - configurar app host;
   - montar shell/layout;
   - usar showcases como referência.
2. Formalizar um domínio novo para apps:
   - `app-spec`
   - ou `blazor-app-spec`
3. Criar instrução para:
   - novo projeto Blazor que usa Yasamen;
   - nova solução demo/host;
   - novo app cliente/servidor.

## Domínio 4. Screen Planning

### Objetivo

Planejar telas usando shell, page pattern, catálogo e mapeamento Yasamen.

### Estado

A estrutura base já existe.

### Próximos passos

1. Criar as primeiras `screen specs` reais.
2. Validar o fluxo com casos concretos.
3. Identificar gaps recorrentes de componentes a partir das telas.
4. Decidir depois se faz sentido subir para jornadas e capacidades.

## Domínio 5. Project Scaffolding

### Objetivo

Criar projetos novos de forma consistente.

### Estado

Só o caso de biblioteca Razor está formalizado.

### Próximos passos

1. Manter `create-library-project.md` como scaffolding técnico de pacote da biblioteca.
2. Criar no futuro:
   - `create-blazor-app-project.md`
   - ou um domínio `app-spec`.
3. Separar claramente:
   - projeto da biblioteca;
   - projeto consumidor da biblioteca;
   - host de docs/showcase;
   - apps de demonstração.

## Domínio 6. Copilot

### Objetivo

Ter poucos agentes e regras claras.

### Próximos passos

1. Fixar os agentes ativos:
   - `spec-station`
   - `lib-spec`
   - `screen-spec`
   - `yasamen`
2. Marcar os demais como legados ou especializados.
3. Fazer a UI do Copilot apontar mais para os orquestradores do que para agentes antigos.

## Domínio 7. Future Backend Domains

### Objetivo

Preparar expansão futura sem poluir a estrutura atual.

### Próximos passos

1. Não criar todos os domínios futuros agora.
2. Formalizar primeiro apenas quando houver demanda real:
   - `app-spec`
   - `api-spec`
   - `domain-spec`
   - `use-case-spec`
   - `ef-spec`
   - `messaging-spec`
3. Repetir o mesmo modelo:
   - guide de domínio;
   - instructions;
   - template;
   - orquestrador;
   - agente fino.

## Domínio 8. Skills

### Objetivo

Encapsular conhecimento estável e reutilizável.

### Próximos passos

1. Não começar por skill.
2. Primeiro estabilizar:
   - guides;
   - instructions;
   - fluxos;
   - naming.
3. Só depois escolher domínios maduros para skill.

---

## Ordem Recomendada de Execução

1. Governança da camada de IA
2. Lib usage e novo domínio de app/projeto consumidor
3. Consolidação de `screen-spec` com casos reais
4. Limpeza da camada Copilot
5. Domínios futuros
6. Skills

---

## Recomendação Prática Imediata

Para prosseguir com os objetivos de hoje, eu recomendo este recorte:

1. Não fazer renomeação em massa agora.
2. Criar primeiro uma arquitetura conceitual clara no README raiz de `.ai`.
3. Separar explicitamente:
   - guides de autoria da biblioteca;
   - guides de uso da biblioteca;
   - instruções de fluxo;
   - scaffolding técnico.
4. Escolher o próximo domínio novo a formalizar:
   - eu sugiro `app-spec` ou `blazor-app-spec`, porque ele cobre o caso de criar projeto que usa a lib.
5. Só depois reavaliar se vale mover arquivos ou renomear pastas.

---

## Critério de Sucesso

Esta reorganização estará boa quando:

- um humano souber por onde começar sem adivinhar;
- o Copilot tiver poucos agentes ativos e com papel claro;
- guides, instructions e templates estiverem claramente separados;
- o domínio de uso da biblioteca estiver tão claro quanto o domínio de autoria da biblioteca;
- o próximo domínio puder ser adicionado sem reabrir a organização toda.
