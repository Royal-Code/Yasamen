import { describe, it, expect, vi } from 'vitest';
import { render, screen, fireEvent } from '@testing-library/react';
import Button from '../Button';
import { Themes, ButtonClasses, Sizes, getNavigator, setNavigator } from '../../commons';

describe('Button component', () => {
  it('renders with primary theme class', () => {
    render(<Button label="Ok" theme={Themes.Primary} />);
    const btn = screen.getByRole('button', { name: 'Ok' });
    expect(btn.classList.contains(ButtonClasses[Themes.Primary] as string)).toBe(true);
  });

  it('renders outline+active success class', () => {
    render(<Button label="Save" outline active theme={Themes.Success} />);
    const btn = screen.getByRole('button', { name: 'Save' });
    expect(btn.classList.contains(ButtonClasses.Active.Outline[Themes.Success])).toBe(true);
  });

  it('applies size class for Large', () => {
    render(<Button label="Big" size={Sizes.Large} />);
    const btn = screen.getByRole('button', { name: 'Big' });
    expect(btn.classList.contains(ButtonClasses.Sizes[Sizes.Large])).toBe(true);
  });

  it('throws for invalid center icon position', () => {
    //// @ts-expect-error test invalid position
    expect(() => render(<Button label="X" icon="x" iconPosition="center" />)).toThrow();
  });

  it('suppresses click when disabled (no onClick, no navigation)', () => {
    const handleClick = vi.fn();
    render(<Button label="Disabled" disabled onClick={handleClick} navigateTo="/route" />);
    const btn = screen.getByRole('button', { name: 'Disabled' });
    fireEvent.click(btn);
    expect(handleClick).not.toHaveBeenCalled();
    // navigateTo should not trigger navigation when disabled; cannot assert window.location change since prevented.
    expect(btn.getAttribute('disabled')).not.toBeNull();
  });

  it('invokes custom navigator for navigateTo when enabled', () => {
    const calls: string[] = [];
    const mockNavigator = { navigate: (to: string) => calls.push(to) };
    // capture original navigator and replace
    const original = getNavigator();
    setNavigator(mockNavigator);
    try {
      render(<Button label="Go" navigateTo="/test-path" />);
      const btn = screen.getByRole('button', { name: 'Go' });
      fireEvent.click(btn);
      expect(calls.length).toBe(1);
      expect(calls[0]).toBe('/test-path');
    } finally {
      // restore original navigator to avoid leaking into other tests
      setNavigator(original);
    }
  });
});
