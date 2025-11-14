import { describe, it, expect } from 'vitest';
import React from 'react';
import { bsIconFactory } from '../../../bsicons/bs-icon-factory';
import { setIconFactory, getIconRenderer, tryGetIconRenderer } from '../icon-registry';
import type { IconFactory } from '../icon-factory';

describe('Icon Factory / Registry', () => {
  it('bsIconFactory returns null for invalid icon', () => {
    expect(bsIconFactory('___nao_existe')).toBeNull();
  });

  it('custom factory registers and resolves icon', () => {
    const factory: IconFactory = (name) => {
      if (name === 'ok') {
        return (cls) => React.createElement('i', { className: cls ? cls + ' custom-ok' : 'custom-ok' });
      }
      return null;
    };
    setIconFactory(factory);
    const renderer = getIconRenderer('ok');
    const el = renderer('x', {} as any);
    expect(el.props.className).toContain('custom-ok');
  });

  it('getIconRenderer throws for unknown', () => {
    expect(() => getIconRenderer('unknown-123')).toThrow();
  });

  it('tryGetIconRenderer returns fallback for unknown', () => {
    const r = tryGetIconRenderer('unknown-123');
    const el = r('', {} as any);
    expect(el.type).toBe(React.Fragment); // NoIconRenderer returns Fragment wrapping SVG
  });
});
