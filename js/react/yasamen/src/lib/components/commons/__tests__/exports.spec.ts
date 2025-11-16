import { describe, it, expect } from 'vitest';
import { BgColors, ButtonClasses, IconButtonClasses, RippleClasses, StackClasses, BarClasses } from '../index';

describe('Commons exports', () => {
  it('exports BgColors with primary', () => {
    expect(BgColors.primary || BgColors.Primary).toBeDefined();
  });
  it('exports ButtonClasses primary variant', () => {
    // primary might be key stored under Themes.Primary constant; ensure some primary class exists
    const anyPrimary = Object.values(ButtonClasses).find(v => typeof v === 'string' && v.includes('ya-btn-primary'));
    expect(anyPrimary).toBeDefined();
  });
  it('exports IconButtonClasses base', () => {
    expect(IconButtonClasses.Base).toBe('ya-i-btn');
  });
  it('exports RippleClasses animation', () => {
    expect(RippleClasses.Animation).toBe('ya-ripple-animation');
  });
  it('exports StackClasses gap small', () => {
    expect(StackClasses.Gap.small).toBeDefined();
  });
  it('exports BarClasses base', () => {
    expect(BarClasses.Base).toBe('ya-bar');
  });
});
