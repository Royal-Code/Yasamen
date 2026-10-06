import { describe, it, expect } from 'vitest';
import { render, screen, act } from '@testing-library/react';
import React from 'react';
import { SectionProvider, SectionOutlet } from '../../outlet';
import { Offcanvas, type OffcanvasHandler } from '../Offcanvas';
import { OffcanvasClasses } from '../offcanvas-classes';
import { OffcanvasProvider } from '../OffcanvasProvider';
import { OffcanvasOutlet } from '../OffcanvasOutlet';
import { useOffcanvasHandler } from '../offcanvas-context';

describe('Offcanvas component', () => {
    it('renders closed by default in section outlet', () => {
        render(
            <SectionProvider>
                <Offcanvas id="test-drawer">
                    <div>Drawer Content</div>
                </Offcanvas>
                <SectionOutlet id="test-drawer" />
            </SectionProvider>
        );

        const aside = screen.getByRole('dialog', { hidden: true });
        expect(aside).toBeTruthy();
        expect(aside.classList.contains(OffcanvasClasses.Offcanvas.Base)).toBe(true);
        expect(aside.classList.contains(OffcanvasClasses.Offcanvas.End)).toBe(true);
        expect(aside.classList.contains(OffcanvasClasses.Offcanvas.Closed)).toBe(true);
    });

    it('applies start (left) class when position="left"', () => {
        render(
            <SectionProvider>
                <Offcanvas id="left-drawer" position="left">
                    <div>Left Menu</div>
                </Offcanvas>
                <SectionOutlet id="left-drawer" />
            </SectionProvider>
        );

        const aside = screen.getByRole('dialog', { hidden: true });
        expect(aside.classList.contains(OffcanvasClasses.Offcanvas.Start)).toBe(true);
    });

    it('opens and closes via imperative handler', () => {
        const handler: OffcanvasHandler = { open: () => {}, close: () => {} };

        render(
            <SectionProvider>
                <Offcanvas id="handler-drawer" handler={handler}>
                    <div>Content</div>
                </Offcanvas>
                <SectionOutlet id="handler-drawer" />
            </SectionProvider>
        );

        const aside = screen.getByRole('dialog', { hidden: true });
        expect(aside.classList.contains(OffcanvasClasses.Offcanvas.Closed)).toBe(true);

        act(() => {
            handler.open();
        });

        expect(aside.classList.contains(OffcanvasClasses.Offcanvas.Closed)).toBe(false);

        act(() => {
            handler.close();
        });

        // After close is triggered, it transitions
        expect(aside.classList.contains(OffcanvasClasses.Offcanvas.Open)).toBe(false);
    });

    it('provides active handler to child components via useOffcanvasHandler', () => {
        const ChildCloser: React.FC = () => {
            const h = useOffcanvasHandler();
            return <button onClick={h.close}>Close From Inside</button>;
        };

        const handler: OffcanvasHandler = { open: () => {}, close: () => {} };

        render(
            <SectionProvider>
                <Offcanvas id="child-handler-drawer" handler={handler}>
                    <ChildCloser />
                </Offcanvas>
                <SectionOutlet id="child-handler-drawer" />
            </SectionProvider>
        );

        expect(screen.getByRole('button', { hidden: true, name: 'Close From Inside' })).toBeTruthy();
    });

    it('renders inside OffcanvasProvider and OffcanvasOutlet seamlessly', () => {
        const handler: OffcanvasHandler = { open: () => {}, close: () => {} };

        render(
            <OffcanvasProvider>
                <SectionProvider>
                    <OffcanvasOutlet />
                    <Offcanvas id="outlet-drawer" handler={handler}>
                        <div>Inside Global Outlet</div>
                    </Offcanvas>
                </SectionProvider>
            </OffcanvasProvider>
        );

        const aside = screen.getByRole('dialog', { hidden: true });
        expect(aside.textContent).toContain('Inside Global Outlet');
    });
});
