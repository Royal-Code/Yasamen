import type { Meta, StoryObj } from '@storybook/react';
import IconButton from '../../lib/components/iconbutton/iconbutton';
import { Themes } from '../../lib/components/commons/themes';
import { Sizes } from '../../lib/components/commons/sizes';
import { BsIcons } from '../../lib/components/bsicons/bsIcons';
import './ButtonStories.css'; // reuse grid / layout helpers
import './IconButtonStories.css';

/*
  IconButton component stories.
  Pattern follows Button/Icon stories: provide a Playground plus focused showcases.
  NOTE: IconButton exige exatamente UMA das props: icon OU renderer.
        O controle 'icon' inclui uma opção vazia ''. Se você limpar o ícone sem fornecer renderer, a story vai lançar erro.
*/

const allThemes = Object.values(Themes);
const allSizes = Object.values(Sizes) as Sizes[];

// Subset de ícones para controles (evita lista enorme)
const iconOptions = ['', BsIcons.Plus, BsIcons.Dash, BsIcons.Gear, BsIcons.CheckCircle, BsIcons.XCircle, BsIcons.Eye, BsIcons.EyeSlash];

const meta = {
  title: 'Components/IconButton',
  component: IconButton,
  parameters: { layout: 'centered' },
  tags: ['autodocs'],
  argTypes: {
    icon: { control: 'select', options: iconOptions, description: 'Ícone bootstrap (vazio para nenhum — exige renderer alternativo)' },
    theme: { control: 'select', options: allThemes, description: 'Tema visual' },
    size: { control: 'select', options: allSizes, description: 'Escala de tamanho' },
    outline: { control: 'boolean', description: 'Variante outline' },
    active: { control: 'boolean', description: 'Estado ativo' },
    disabled: { control: 'boolean', description: 'Desabilita interação' },
    className: { control: 'text', description: 'Classes extras' },
    onClick: { action: 'clicked' }
    // renderer não exposto via controls; mostrado em story dedicada
  },
  args: {
    icon: BsIcons.Plus,
    theme: Themes.Primary,
    size: Sizes.Medium,
    outline: false,
    active: false,
    disabled: false,
    className: '',
  // onClick action handled via argTypes; no mock fn needed in SB9
  }
} satisfies Meta<typeof IconButton>;

export default meta;

type Story = StoryObj<typeof meta>;

// Playground
export const Playground: Story = {};

// Tema básico
export const Primary: Story = { args: { theme: Themes.Primary } };
export const Secondary: Story = { args: { theme: Themes.Secondary } };
export const Danger: Story = { args: { theme: Themes.Danger } };

// Outline
export const OutlinePrimary: Story = { args: { theme: Themes.Primary, outline: true } };
export const OutlineSecondary: Story = { args: { theme: Themes.Secondary, outline: true } };

// Active
export const ActivePrimary: Story = { args: { theme: Themes.Primary, active: true } };
export const ActiveOutlinePrimary: Story = { args: { theme: Themes.Primary, outline: true, active: true } };

// Disabled
export const Disabled: Story = { args: { disabled: true } };

// Showcase tamanhos
export const SizesShowcase: Story = {
  render: (args) => (
    <div className="ya-story-sizes-flex">
      {allSizes.map(sz => (
        <IconButton key={sz} {...args} size={sz} icon={BsIcons.Plus} aria-label={`Size ${sz}`} />
      ))}
    </div>
  ),
  args: { outline: false }
};

// Vários temas em grid
export const ThemeShowcase: Story = {
  render: (args) => (
    <div className="ya-story-grid">
      <div className="ya-story-box">
        {allThemes.map(th => (
          <IconButton key={th} {...args} theme={th} icon={BsIcons.Gear} aria-label={`Theme ${th}`} />
        ))}
      </div>
    </div>
  ),
  args: { outline: false }
};

// Ícones variados
export const IconVariants: Story = {
  render: (args) => (
    <div className="ya-story-grid">
      <div className="ya-story-box">
        {iconOptions.filter(i => !!i).map(ic => (
          <IconButton key={ic} {...args} icon={ic} aria-label={`Icon ${ic}`} />
        ))}
      </div>
    </div>
  ),
  args: { theme: Themes.Primary }
};

// Uso de renderer custom sem usar ícone (ex: estrela decorativa)
export const CustomRenderer: Story = {
  render: (args) => (
    <IconButton
      {...args}
      icon={undefined}
      renderer={() => <span className="ya-iconbutton-star" aria-hidden="true">★</span>}
      aria-label="Star"
    />
  ),
  args: { theme: Themes.Highlight }
};

// Estado combinado: outline + active
export const ActiveOutlineSecondary: Story = { args: { theme: Themes.Secondary, outline: true, active: true } };

// Nota: Caso selecione icon = '' no Playground sem fornecer renderer, ocorrerá erro (validação interna do componente).
