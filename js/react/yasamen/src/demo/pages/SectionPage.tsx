import React from 'react';
import { SectionContent } from '../../lib/components/outlet';
import { Button } from '../../lib/components/button';

const InnerOverride: React.FC<{ active: boolean }> = ({ active }) => {
    if (!active) return null;
    return (
        <SectionContent id="header">
            <div className="p-3 rounded bg-primary-50 border border-primary-200">
                <h1 className="text-lg font-semibold text-primary-700">Override Interno (Último Vence)</h1>
                <p className="text-xs text-primary-600">Este conteúdo substitui temporariamente o cabeçalho da página.</p>
            </div>
        </SectionContent>
    );
};

const SectionPage: React.FC = () => {
    const [override, setOverride] = React.useState(false);

    return (
        <div className="space-y-6">
            {/* Cabeçalho principal da página */}
            <SectionContent id="header">
                <div className="p-3 rounded bg-neutral-50 border border-neutral-200">
                    <h1 className="text-xl font-bold">Demo: SectionOutlet</h1>
                    <p className="text-sm text-neutral-600">Conteúdo declarado aqui é renderizado no layout através do <code>&lt;SectionOutlet id="header" /&gt;</code>.</p>
                </div>
            </SectionContent>

            {/* Override condicional */}
            <InnerOverride active={override} />

            <div className="space-y-4">
                <p className="text-sm text-neutral-700 leading-relaxed">
                    O sistema de seções mantém uma pilha por <code>id</code>. Cada <code>&lt;SectionContent id="header" /&gt;</code> montado empilha seu conteúdo. O topo da pilha
                    (último montado) é exibido pelo <code>SectionOutlet</code>. Ao desmontar o topo, o anterior volta automaticamente.
                </p>
                <Button
                    label={override ? 'Remover Override Interno' : 'Adicionar Override Interno'}
                    onClick={() => setOverride(o => !o)}
                    theme={override ? 'neutral' : 'primary'}
                />
                <div className="text-xs text-neutral-500">
                    Estado atual: {override ? 'Override ativo (mostrando cabeçalho interno)' : 'Sem override (mostrando cabeçalho principal)'}
                </div>
            </div>
        </div>
    );
};

export default SectionPage;