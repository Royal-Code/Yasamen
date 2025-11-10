import type { Meta, StoryObj } from '@storybook/react';
import Icon from '../../lib/components/icon/icon';
import { WellKnownIcons } from '../../lib/components/icon/wellKnownIcons';
import { BsIcons } from '../../lib/components/bsicons/bsIcons';
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
    layout: 'centered'
  },
  tags: ['autodocs'],
  argTypes: {
    name: {
      control: 'select',
      options: allBootstrapIconValues,
      description: 'Bootstrap icon name (value from BsIcons)'
    },
    className: { control: 'text', description: 'Extra CSS class names applied to the underlying <i> or <svg>' },
    title: { control: 'text', description: 'Title attribute for accessibility tooltip' }
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
  render: () => {
    try {
      return <Icon name="__invalid_icon_name__" />;
    } catch (err) {
      return <div className="ya-icon-invalid-wrapper">
        <strong>Invalid Icon Example:</strong>
        <p className="ya-icon-small-text">Tentativa de renderizar um nome inexistente gerou erro: {(err as Error).message}</p>
        <p className="ya-icon-small-text">Use sempre nomes de <code>WellKnownIcons</code> ou chaves existentes em <code>BsIcons</code>.</p>
      </div>;
    }
  }
};
