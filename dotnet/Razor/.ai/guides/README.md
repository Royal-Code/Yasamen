# Guides — RoyalCode.Razor

> Steering files para desenvolvimento de componentes na biblioteca RoyalCode.Razor (Yasamen Design System).
> Cada guide documenta um aspeto da arquitetura, convenções ou padrões obrigatórios.
> **Toda IA ou desenvolvedor que criar um novo componente DEVE ler os guides relevantes antes de começar.**

---

## Índice de Guides

| Arquivo | Propósito |
|---|---|
| [01-project-structure.md](01-project-structure.md) | Estrutura de projetos, dependências e como criar um novo pacote |
| [02-styles-and-css.md](02-styles-and-css.md) | Sistema de estilos: enums, CssClasses, builders e convenção `ya-` |
| [03-commons-infrastructure.md](03-commons-infrastructure.md) | Projeto Commons: JS modules, EmptyFragment, extensões e DI |
| [04-icons-system.md](04-icons-system.md) | Sistema de ícones: IconFragment, WellKnownIcons, factories |
| [05-animations.md](05-animations.md) | Sistema de animações: AnimationFragment, RotationMotion, RotateEffect |
| [06-component-anatomy.md](06-component-anatomy.md) | Anatomia de um componente: .razor + .razor.cs, parâmetros, CSS, DI |
| [07-form-components.md](07-form-components.md) | Infraestrutura de formulários: FieldBase, FieldGroup, validação, addons |
| [08-service-pattern.md](08-service-pattern.md) | Padrão de serviços DI + Outlet (Notifications, Modals, OffCanvas) |

---

## Como usar os Guides

1. **Antes de criar um componente simples** (leaf, sem estado): leia [06](06-component-anatomy.md) + [02](02-styles-and-css.md)
2. **Antes de criar um componente de formulário**: leia também [07](07-form-components.md) + [03](03-commons-infrastructure.md)
3. **Ao usar ícones**: leia [04](04-icons-system.md)
4. **Ao usar animações**: leia [05](05-animations.md)
5. **Ao criar um serviço DI com outlet** (toast, modal, etc.): leia [08](08-service-pattern.md)
6. **Ao criar um novo pacote/projeto**: leia [01](01-project-structure.md)
