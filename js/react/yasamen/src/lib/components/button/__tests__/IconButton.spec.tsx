import { describe, it, expect } from 'vitest';
import { render, screen } from '@testing-library/react';
import IconButton from '../IconButton';
import { Themes, IconButtonClasses, Sizes } from '../../commons';
import { type IconRenderer } from '../../icon/factory/icon-renderer';

describe('IconButton component', () => {
  it('throws when neither icon nor renderer provided', () => {
    expect(() => render(<IconButton />)).toThrow();
  });

  it('throws when both icon and renderer provided', () => {
    const renderer: IconRenderer = (cls) => <span className={cls}>R</span>;
    expect(() => render(<IconButton icon="x" renderer={renderer} />)).toThrow();
  });

  it('applies theme + size classes', () => {
    render(<IconButton icon="x" theme={Themes.Alert} size={Sizes.Small} ariaLabel="Fechar" />);
    const btn = screen.getByRole('button', { name: 'Fechar' });
    expect(btn.classList.contains(IconButtonClasses[Themes.Alert])).toBe(true);
    expect(btn.classList.contains(IconButtonClasses.Sizes[Sizes.Small])).toBe(true);
  });

  it('ariaLabel overrides icon name fallback', () => {
    render(<IconButton icon="pencil" ariaLabel="Editar" />);
    const btn = screen.getByRole('button', { name: 'Editar' });
    expect(btn).toBeDefined();
    expect(btn.getAttribute('aria-label')).toBe('Editar');
  });

  it('uses icon name when ariaLabel absent', () => {
    render(<IconButton icon="trash" />);
    const btn = screen.getByRole('button');
    expect(btn.getAttribute('aria-label')).toBe('trash');
  });
});
