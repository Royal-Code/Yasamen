# UIP-CONTENT-RICH_TEXT_BLOCK - Blueprint

## Identificação
- **Pattern**: UIP-CONTENT-RICH_TEXT_BLOCK - Rich Text Block.
- **Nível final**: resumido.
- **Cobertura atual**: 4.
- **Meta de cobertura proposta**: 7.
- **Evidências usadas**: `ui-map.md`, `ui_content.pattern.md`, samples de `Box`, HTML semântico, `Button`, `Badge`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen não tem componente editorial, mas `Box` e HTML semântico permitem bloco de leitura. Como o reboot tem lacunas de variáveis tipográficas, o blueprint recomenda classes confirmadas.

## Decisão arquitetural principal
Criar `[API proposta] RichTextBlock` como wrapper visual para conteúdo já sanitizado/renderizado pelo app.

## Componentes reaproveitados
`Box`, `Button`, `Badge`, `Feedback` e HTML semântico.

## Bloco principal de código

```razor
@* [API proposta] RichTextBlock *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <article class="max-w-3xl space-y-4 text-dark-700 leading-base">
        <h1 class="text-2xl font-medium text-dark-900">@Title</h1>
        @ChildContent
    </article>
</Box>
```

## Exemplo principal de uso
Use para ajuda, política, descrição longa e conteúdo documental. Para pares label/valor, usar `DetailBlock`.

## Justificativa breve da cobertura proposta
A meta é 7 porque a biblioteca sustenta contorno e tipografia básica, mas não fornece rich text, sanitização, markdown ou mídia.

## Limitações remanescentes
- Sanitização e renderização de HTML/Markdown são externas.
- Imagens e embeds precisam regras próprias.
- Tipografia global do reboot tem lacunas.

## Pontos de adaptação
- Usar largura máxima de leitura.
- Evitar depender de variáveis CSS não confirmadas.
- Validar conteúdo vindo de usuário antes de renderizar.
