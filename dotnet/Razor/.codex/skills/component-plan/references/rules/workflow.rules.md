# Regras Gerais para o Workflow

[INSTRUÇÃO] O fluxo sempre produz artefatos para consumo por IA em implementação posterior, não documentação narrativa solta.

[INSTRUÇÃO] O fluxo padrão é `plan-spec` seguido de `create-spec`.

[INSTRUÇÃO] Não implementar código de componente, pacote, CSS, showcase ou teste durante esta skill.

[INSTRUÇÃO] Resolver diretório de trabalho:
- se o humano informar diretório explícito, usar;
- caso contrário, usar `.ai/specs/lib/{slug}/`, onde `slug` é o nome do componente em dash-case;
- criar o diretório somente quando a etapa ativa exigir persistência de artefato.

[INSTRUÇÃO] Criar artefatos no diretório de trabalho:
- `planning.md` ao final de `plan-spec`;
- `requirements.md`, `design.md`, `tasks.md` e `delivery.md` ao final de `create-spec`.

[INSTRUÇÃO] Se o diretório de trabalho já contiver artefatos finais e o humano não pediu recriação, refino ou sobrescrita, parar e perguntar como seguir.

[INSTRUÇÃO] Ao concluir uma etapa:
- apresentar ao humano o resumo semântico da etapa;
- pedir avaliação quando o protocolo exigir validação humana;
- falar sobre a próxima etapa e perguntar se pode prosseguir, exceto quando houver pedido explícito para executar até o final sem parar e não houver bloqueios.

[INSTRUÇÃO] O arquivo `planning.md` é artefato de transição obrigatório. Não iniciar `create-spec` sem ele, salvo se o humano fornecer um plano aprovado equivalente e autorizar explicitamente o uso dele como substituto.

[INSTRUÇÃO] A pausa entre etapas só é dispensada quando houver pedido explícito do humano para executar até o final sem parar, conforme regra de override do `kernel.rules.md`.

[INSTRUÇÃO] Não duplicar instruções internas de skill em artefatos finais. Artefatos finais devem conter decisões da spec, não explicações sobre a skill.

[INSTRUÇÃO] Não referenciar arquivos de instrução antigos do workspace como fonte operacional. Usar protocolos, rules e templates desta skill como fonte operacional.
