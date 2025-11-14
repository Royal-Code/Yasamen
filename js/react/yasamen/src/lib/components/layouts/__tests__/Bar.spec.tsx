import { describe, it, expect } from 'vitest';
import { render, screen } from '@testing-library/react';
import Bar from '../Bar';

describe('Bar slots', () => {
  it('renders only provided slots', () => {
    render(<Bar><Bar.Start>Left</Bar.Start><Bar.End>Right</Bar.End></Bar>);
    expect(screen.getByText('Left')).toBeTruthy();
    expect(screen.getByText('Right')).toBeTruthy();
    expect(screen.queryByText('Center')).toBeNull();
  });

  it('override last Start wins', () => {
    render(<Bar><Bar.Start>A</Bar.Start><Bar.Start>B</Bar.Start></Bar>);
    expect(screen.getByText('B')).toBeTruthy();
    expect(screen.queryByText('A')).toBeNull();
  });

  it('override last End wins', () => {
    render(<Bar><Bar.End>X</Bar.End><Bar.End>Y</Bar.End></Bar>);
    expect(screen.getByText('Y')).toBeTruthy();
    expect(screen.queryByText('X')).toBeNull();
  });
});
