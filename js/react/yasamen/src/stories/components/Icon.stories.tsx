import type { Meta, StoryObj } from '@storybook/react';
import { Icon, WellKnownIcons } from '../../lib/components/icon';
import { BsIcons } from '../../lib/components/bsicons';
import './IconStories.css';

/*
  Icon component stories.
  Pattern aligns with Button stories: provide a Playground plus focused showcases.
*/

// Prepare well-known names (filter out legacy misspellings if present)
// Use full BsIcons list for selection (can be large).
const allBootstrapIconValues = Object.values(BsIcons);
// Keep a small curated subset for gallery (avoid rendering thousands at once).
const gallerySubset: (keyof typeof BsIcons)[] = ['Plus', 'Dash', 'Gear', 'XCircle', 'CheckCircle', 'InfoCircle', 'ExclamationTriangle', 'Eye', 'EyeSlash', 'Person', 'PersonGear', 'List'];

// A curated subset of Bootstrap icon keys for gallery / exploration.
const curatedBootstrapKeys: (keyof typeof BsIcons)[] = [
  'Plus', 'Dash', 'Gear', 'GearWideConnected', 'XCircle', 'CheckCircle', 'InfoCircle', 'ExclamationTriangle', 'Eye', 'EyeSlash', 'Person', 'PersonGear', 'List', 'ChevronCompactUp', 'ChevronCompactDown'
];

const meta = {
  title: 'Components/Icon',
  component: Icon,
  parameters: {
    layout: 'centered',
    docs: {
      description: {
        component: 'Wrapper de ícones Bootstrap (fonte ou svg). Usa nomes de BsIcons ou WellKnownIcons. Se inválido, lança erro facilitando detecção precoce.'
      }
    }
  },
  tags: ['autodocs', 'stable'],
  argTypes: {
    name: {
      control: 'select',
      options: allBootstrapIconValues,
      description: 'Nome do ícone (valor retornado por BsIcons).'
    },
    className: { control: 'text', description: 'Classes CSS extras aplicadas ao ícone.' },
    title: { control: 'text', description: 'Atributo title para tooltip/acessibilidade.' }
  },
  args: {
    name: allBootstrapIconValues[0],
    className: '',
    title: 'Icon'
  }
} satisfies Meta<typeof Icon>;

export default meta;
type Story = StoryObj<typeof meta>;

// Playground story with adjustable props.
export const Playground: Story = {};

// Gallery of well-known icons.
export const WellKnownGallery: Story = {
  name: 'Well Known Icons',
  render: () => (
    <div className="ya-icon-grid">
      {gallerySubset.map(key => {
        const value = BsIcons[key];
        return (
          <div key={key} className="ya-icon-item" title={key}>
            <div className="ya-icon-item__glyph">
              <Icon name={value} />
            </div>
            <span>{key}</span>
          </div>
        );
      })}
    </div>
  )
};

// Size scaling demonstration.
export const SizeShowcase: Story = {
  render: () => {
    const sizes = [12, 16, 20, 24, 32, 40, 48];
    return (
      <div className="ya-icon-size-demo">
        {sizes.map(sz => (
          <div key={sz} className="ya-icon-size-demo__item">
            <Icon name={WellKnownIcons.Plus} className={`ya-icon-sz-${sz}`} />
            <span>{sz}px</span>
          </div>
        ))}
      </div>
    );
  }
};

// Curated Bootstrap icon exploration.
export const BootstrapCurated: Story = {
  name: 'Bootstrap Curated',
  render: () => (
    <div className="ya-icon-grid">
      {curatedBootstrapKeys.map(key => {
        const value = BsIcons[key];
        return (
          <div key={key} className="ya-icon-item" title={key}>
            <div className="ya-icon-item__glyph">
              <Icon name={value} />
            </div>
            <span>{key}</span>
          </div>
        );
      })}
    </div>
  )
};

// Story demonstrating invalid icon handling (will throw). We wrap in try/catch to show fallback guidance.
export const InvalidExample: Story = {
  tags: ['negative'],
  render: () => {
    try {
      return <Icon name="__invalid_icon_name__" />;
    } catch (err) {
      return (
        <div className="ya-icon-invalid-wrapper">
          <strong>Invalid Icon Example:</strong>
          <p className="ya-icon-small-text">Tentativa de nome inexistente gerou erro: {(err as Error).message}</p>
          <p className="ya-icon-small-text">Use nomes de <code>WellKnownIcons</code> ou chaves existentes em <code>BsIcons</code>.</p>
        </div>
      );
    }
  }
};
