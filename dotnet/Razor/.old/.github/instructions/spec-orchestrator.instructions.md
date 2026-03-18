---
applyTo: ".ai/spec.md"
---

# Instruções para o orquestrador legado de specs e componentes

- Este arquivo ficou legado após a introdução de `.ai/lib-spec.md` e `.ai/station.md`.
- Ele deve rotear a intenção do utilizador para o fluxo mínimo necessário.
- Quando o pedido for de componente novo, o fluxo preferencial continua sendo orientado por spec.
- Em qualquer fluxo de componente ou spec, preserve os checkpoints transversais de `.ai/guides/16-cross-cutting-component-decisions.md`.
- Ele não deve scaffoldar projeto nem executar diretamente quando estiver apenas orquestrando.
- Quando o pedido for explicitamente de pacote ou projeto novo, deve preservar `spec-first` por padrão e encaminhar para `.ai/lib-spec.md`.
- `.ai/instructions/create-library-project.md` só entra direto quando o utilizador pedir scaffolding explícito.
- Não misture planeamento colaborativo com implementação sem pedido explícito.
- Quando o utilizador pedir para planejar a próxima spec, primeiro selecione o alvo e só depois entre no fluxo com gates.
- Os exemplos de uso devem permanecer curtos, concretos e coerentes com os arquivos em `.ai/instructions/`.
