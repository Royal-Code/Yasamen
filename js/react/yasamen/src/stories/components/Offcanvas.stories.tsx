import type { Meta, StoryObj } from '@storybook/react';
import React, { useRef } from 'react';
import { Offcanvas, useOffcanvasHandler, type OffcanvasHandler } from '../../lib/components/offcanvas';
import { Button } from '../../lib/components/button';
import { SectionProvider } from '../../lib/components/outlet';
import { Themes } from '../../lib/components/commons';

const meta: Meta<typeof Offcanvas> = {
    title: 'Components/Offcanvas',
    component: Offcanvas,
    parameters: {
        layout: 'fullscreen',
    },
};

export default meta;

type Story = StoryObj<typeof Offcanvas>;

const DrawerInner: React.FC<{ title: string }> = ({ title }) => {
    const handler = useOffcanvasHandler();
    return (
        <div className="p-6 h-full flex flex-col justify-between w-80 bg-white">
            <div className="space-y-4">
                <div className="flex items-center justify-between border-b pb-2">
                    <h3 className="font-bold text-gray-800">{title}</h3>
                    <button onClick={handler.close} className="text-gray-400 hover:text-gray-600 font-bold">
                        &times;
                    </button>
                </div>
                <p className="text-sm text-gray-600">Conteúdo renderizado dentro do painel lateral Offcanvas.</p>
            </div>
            <Button label="Fechar" theme="secondary" block onClick={handler.close} />
        </div>
    );
};

const RightDrawerStory: React.FC = () => {
    const handler = useRef<OffcanvasHandler>({ open: () => {}, close: () => {} }).current;
    return (
        <SectionProvider>
            <div className="p-8">
                <Button label="Abrir Offcanvas (Direita)" theme={Themes.Primary} onClick={() => handler.open()} />
                <Offcanvas id="sb-right-drawer" position="right" handler={handler}>
                    <DrawerInner title="Painel Direito" />
                </Offcanvas>
            </div>
        </SectionProvider>
    );
};

export const RightDrawer: Story = {
    render: () => <RightDrawerStory />
};

const LeftDrawerStory: React.FC = () => {
    const handler = useRef<OffcanvasHandler>({ open: () => {}, close: () => {} }).current;
    return (
        <SectionProvider>
            <div className="p-8">
                <Button label="Abrir Offcanvas (Esquerda)" theme={Themes.Tertiary} onClick={() => handler.open()} />
                <Offcanvas id="sb-left-drawer" position="left" handler={handler}>
                    <DrawerInner title="Painel Esquerdo" />
                </Offcanvas>
            </div>
        </SectionProvider>
    );
};

export const LeftDrawer: Story = {
    render: () => <LeftDrawerStory />
};
