# Protocolo: Classificação de complexidade

## Regras

Regras que a IA deve seguir estritamente:
- Classificar a tarefa inteira: investigação, implementação e prova de aceite.
- Usar o nível da parte mais difícil que não pode ser separada sem perder o resultado.
- Dividir a tarefa em entregas verificáveis quando ela misturar parte simples e integração difícil.
- Não elevar o nível por quantidade de arquivos, linhas, tempo ou tecnologia desconhecida.
- Separar a pesquisa inicial e reclassificar com evidência quando a incerteza for tecnológica.
- Registrar a razão decisiva em `tasks-{slug}.md`.
- Reclassificar quando o escopo mudar.

## Perguntas, nesta ordem

1. Comportamento e estado: a tarefa é apresentação conhecida, ou há transições, invariantes, concorrência e compatibilidade?
2. Acoplamento: a mudança fica em fronteira conhecida, ou altera pressupostos de outros componentes, domínios ou consumidores?
3. Regras e incerteza: o contrato está definido, ou é preciso descobrir regra, interpretar decisão ou escolher design?
4. Falha e reversão: o erro é local, ou pode quebrar API pública, tema, layout global ou consumidores?
5. Validação: bastam testes L1 previsíveis, ou é preciso L2, cenários de timing ou prova em consumidor?

## Níveis

| Nível | Critério | Exemplo |
|---|---|---|
| Simples | Escopo fechado, regra pronta, efeito local | Arquivo CSS de componente novo; export; página de demo |
| Média | Regras ou estados conhecidos a ligar; impacto em fronteira próxima | Componente com tema, tamanho e eventos; testes focados |
| Complexa | Dependência entre componentes, invariantes ou efeitos indiretos | Provider com registro e foco; integração com `AppLayout`; máquina de fases |
| Muito Complexa | Vários limites, falhas parciais ou compatibilidade; erro pode quebrar consumidores | Mudança de API pública usada por vários componentes; troca de token global |

## Desempate

Regras que a IA deve seguir estritamente:
- Usar o nível superior quando uma invariante crítica ou uma prova de compatibilidade faz parte do aceite, mesmo com código curto.
