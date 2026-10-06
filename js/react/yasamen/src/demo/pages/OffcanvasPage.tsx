import React, { useRef } from 'react';
import { Button } from '../../lib/components/button';
import { Offcanvas, useOffcanvasHandler, type OffcanvasHandler } from '../../lib/components/offcanvas';
import { Stack } from '../../lib/components/layouts';

// Conteúdo interno com botão de fechar consumindo o contexto do handler
const DrawerContent: React.FC<{ title: string; description: string }> = ({ title, description }) => {
    const handler = useOffcanvasHandler();
    return (
        <div className="p-6 h-full flex flex-col justify-between w-80 bg-white">
            <div className="space-y-4">
                <div className="flex items-center justify-between border-b pb-3">
                    <h3 className="text-lg font-semibold text-gray-800">{title}</h3>
                    <button
                        onClick={handler.close}
                        className="text-gray-400 hover:text-gray-700 text-xl font-bold cursor-pointer"
                        aria-label="Fechar"
                    >
                        &times;
                    </button>
                </div>
                <p className="text-sm text-gray-600 leading-relaxed">{description}</p>
                <div className="space-y-2 pt-2">
                    <div className="p-3 bg-gray-50 rounded text-xs text-gray-500">
                        Item de menu 1
                    </div>
                    <div className="p-3 bg-gray-50 rounded text-xs text-gray-500">
                        Item de menu 2
                    </div>
                    <div className="p-3 bg-gray-50 rounded text-xs text-gray-500">
                        Configurações do sistema
                    </div>
                </div>
            </div>
            <div className="pt-4 border-t">
                <Button label="Fechar Painel" theme="secondary" block onClick={handler.close} />
            </div>
        </div>
    );
};

const OffcanvasPage: React.FC = () => {
    const leftHandler = useRef<OffcanvasHandler>({ open: () => {}, close: () => {} }).current;
    const rightHandler = useRef<OffcanvasHandler>({ open: () => {}, close: () => {} }).current;

    return (
        <div className="p-8 space-y-6 max-w-4xl">
            <div>
                <h1 className="text-2xl font-bold text-gray-900">Offcanvas / Drawer</h1>
                <p className="text-gray-600 mt-1">
                    Painéis laterais retráteis que deslizam a partir da esquerda ou direita da tela com suporte a backdrop e animações.
                </p>
            </div>

            <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-100 space-y-4">
                <h2 className="text-lg font-semibold text-gray-800">Ações de Abertura</h2>
                <Stack orientation="horizontal" gap="md">
                    <Button
                        label="Abrir Painel Esquerdo"
                        theme="primary"
                        onClick={() => leftHandler.open()}
                    />
                    <Button
                        label="Abrir Painel Direito"
                        theme="tertiary"
                        onClick={() => rightHandler.open()}
                    />
                </Stack>
            </div>

            {/* Offcanvas Esquerdo */}
            <Offcanvas id="demo-offcanvas-left" position="left" handler={leftHandler}>
                <DrawerContent
                    title="Menu de Navegação"
                    description="Este painel abriu a partir da borda esquerda da tela (position='left')."
                />
            </Offcanvas>

            {/* Offcanvas Direito */}
            <Offcanvas id="demo-offcanvas-right" position="right" handler={rightHandler}>
                <DrawerContent
                    title="Filtros & Configurações"
                    description="Este painel abriu a partir da borda direita da tela (position='right')."
                />
            </Offcanvas>
        </div>
    );
};

export default OffcanvasPage;
