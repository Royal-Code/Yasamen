# SHP-FOCUSED - Focused

## Componentes por zona funcional

### Zona: Shell (estrutura mínima)

1. HTML layout centralizado (estrutura raiz)
- `cobertura`: `min-h-screen flex items-center justify-center bg-light-50`; sem sidebar, sem header de navegação; área central contida (`max-w-sm w-full`);
- `nota`: 8;
- `justificativa`: shell focado — HTML/Tailwind simples, sem necessidade de AppLayout.

### Zona: Conteúdo (PP-AUTH dominante)

1. Box + EditForm + FieldText + Button (PP-AUTH)
- `cobertura`: zona central de login, registro, recuperação de senha, verificação;
- `nota`: 9;
- `justificativa`: PP-AUTH — o padrão mais comum no SHP-FOCUSED — excelente cobertura.

2. Feedback Style=Danger (UIP-FEEDBACK-ERROR_STATE)
- `cobertura`: erro de credencial, conta bloqueada, sessão expirada;
- `nota`: 9;
- `justificativa`: feedback de erro em tela focada.

3. Feedback Style=Success (confirmação)
- `cobertura`: "E-mail de recuperação enviado", "Conta criada com sucesso";
- `nota`: 9;
- `justificativa`: feedback de sucesso em tela focada.

### Zona: Marca e rodapé

1. HTML (logo e título)
- `cobertura`: logo da aplicação + nome acima da zona central;
- `nota`: 7;
- `justificativa`: marca mínima do shell focado.

2. HTML links (rodapé legal)
- `cobertura`: links para "Privacidade" e "Termos" no rodapé;
- `nota`: 7;
- `justificativa`: rodapé legal.

**Descartados**: AppLayout, AppSideBar, Breadcrumb, Bar (navegação).

## Estrutura de shell

```razor
@* FocusedLayout.razor — shell de tarefa única *@
@inherits LayoutComponentBase

<div class="min-h-screen bg-light-50 flex flex-col items-center justify-center px-4 py-8">
    @* Logo (opcional) *@
    <div class="mb-8 text-center">
        <div class="w-12 h-12 rounded-xl bg-primary-500 mx-auto mb-3
                    flex items-center justify-center">
            <span class="text-white font-bold text-xl">A</span>
        </div>
        <p class="text-sm text-dark-400">AppName</p>
    </div>

    @* Área central da tarefa *@
    <div class="w-full max-w-sm">
        @Body
    </div>

    @* Rodapé legal *@
    <div class="mt-8 text-center">
        <p class="text-xs text-dark-300">
            <a href="/privacidade" class="hover:underline">Privacidade</a>
            &middot;
            <a href="/termos" class="hover:underline">Termos</a>
        </p>
    </div>
</div>
```

```razor
@* Exemplo de uso: erro 404 em shell focado *@
@page "/404"
@layout FocusedLayout

<Box Border="BorderBuilder.Box" AdditionalClasses="p-8 text-center">
    <div class="text-6xl text-dark-300 mb-4">404</div>
    <h1 class="text-xl font-semibold text-dark-700 mb-2">Página não encontrada</h1>
    <p class="text-sm text-dark-400 mb-6">
        A página que você procura não existe ou foi movida.
    </p>
    <Button Style="Themes.Primary" Label="Voltar ao início"
            OnClick='() => Nav.NavigateTo("/")' />
</Box>
```

```razor
@* Exemplo de uso: gate de consentimento *@
@page "/consentimento"
@layout FocusedLayout

@code {
    private bool aceito;
}

<Box Border="BorderBuilder.Box" AdditionalClasses="p-6">
    <h1 class="text-xl font-semibold text-dark-700 mb-3">
        Termos de uso atualizados
    </h1>
    <p class="text-sm text-dark-500 mb-4">
        Revisamos nossa Política de Privacidade. Leia e aceite para continuar.
    </p>
    <div class="bg-light-50 rounded-md p-4 max-h-40 overflow-y-auto text-xs
                text-dark-500 mb-4 border border-light-200">
        @* Conteúdo dos termos *@
        Lorem ipsum...
    </div>
    <FieldCheckbox @bind-Value="aceito" Label="Li e aceito os Termos de Uso" />
    <Bar AdditionalClasses="mt-4">
        <EndContent>
            <Button Style="Themes.Default" Label="Sair"
                    OnClick='() => Nav.NavigateTo("/logout")' />
            <Button Style="Themes.Primary" Label="Aceitar e continuar"
                    Disabled="@(!aceito)"
                    OnClick="AceitarTermos" />
        </EndContent>
    </Bar>
</Box>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: sem componente de shell focado nativo — mas o padrão é tão simples que HTML/Tailwind puro é o melhor approach; sem splash screen animada nativa;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - Layout HTML `flex items-center justify-center` + `Box` + componentes de formulário cobrem SHP-FOCUSED com excelente qualidade;
  - É o shell mais simples de todos — a lib tem exatamente os componentes necessários (`Box`, `FieldText`, `Button`, `Feedback`);
  - Nota 9 reflete cobertura excelente — PP-AUTH dentro de SHP-FOCUSED é um dos cenários mais naturais e bem suportados pela lib.
