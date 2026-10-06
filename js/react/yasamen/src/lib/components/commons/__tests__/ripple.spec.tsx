import { describe, it, expect, vi, beforeEach } from 'vitest';
import { render } from '@testing-library/react';
import Button from '../../button/Button';

// Tests rely on spying add/removeEventListener to ensure cleanup.

describe('Ripple behavior', () => {
  let addSpy: ReturnType<typeof vi.spyOn>;
  let removeSpy: ReturnType<typeof vi.spyOn>;

  beforeEach(() => {
    addSpy = vi.spyOn(HTMLElement.prototype, 'addEventListener');
    removeSpy = vi.spyOn(HTMLElement.prototype, 'removeEventListener');
  });

  it('adds click and animationend listeners on mount and cleans on unmount', () => {
    const { unmount } = render(<Button label="RippleTest" />);
    const clickAdds = addSpy.mock.calls.filter(c => c[0] === 'click').length;
    const animAdds = addSpy.mock.calls.filter(c => c[0] === 'animationend').length;
    expect(clickAdds > 0).toBe(true);
    expect(animAdds > 0).toBe(true);
    unmount();
    const clickRemoves = removeSpy.mock.calls.filter(c => c[0] === 'click').length;
    const animRemoves = removeSpy.mock.calls.filter(c => c[0] === 'animationend').length;
    expect(clickRemoves > 0).toBe(true);
    expect(animRemoves > 0).toBe(true);
  });
});
