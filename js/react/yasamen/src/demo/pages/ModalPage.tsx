import React from 'react';
import { Button } from '../../lib/components/button';
import { useModal } from '../../lib/components/modal/use-modal';
import { Sizes, Themes } from '../../lib/components/commons';

// Conteúdo do Modal B recebe onClose diretamente
const ModalBContent: React.FC<{ onClose: () => void }> = ({ onClose }) => (
  <div className="p-6 bg-white rounded shadow-md space-y-4">
    <h2 className="text-lg font-semibold">Modal B (Aninhado)</h2>
    <p className="text-sm opacity-80">Aberto de dentro do Modal A. Feche para retornar ao A.</p>
    <Button label="Fechar B" theme={Themes.Alert} size={Sizes.Small} onClick={onClose} />
  </div>
);

// Modal A com registro do Modal B (recebe onClose para fechar A)
const ModalAContent: React.FC<{ onClose: () => void }> = ({ onClose }) => {
  const [bContent, setBContent] = React.useState<React.ReactNode>(null);
  const modalB = useModal('demo-modal-b', { content: bContent, closeable: true });

  React.useEffect(() => {
    setBContent(<ModalBContent onClose={modalB.close} />);
  }, [modalB.close]);

  return (
    <div className="p-6 bg-white rounded shadow-md space-y-4">
      <h2 className="text-lg font-semibold">Modal A</h2>
      <p className="text-sm opacity-80">Este modal registra dinamicamente o Modal B para demonstrar empilhamento e nesting.</p>
      <div className="flex gap-3 flex-wrap">
        <Button label="Abrir Modal B" onClick={modalB.open} theme={Themes.Primary} size={Sizes.Small} />
        <Button label="Fechar A" onClick={onClose} theme={Themes.Secondary} size={Sizes.Small} />
      </div>
    </div>
  );
};

const ModalCContent: React.FC<{ onClose: () => void }> = ({ onClose }) => (
  <div className="p-6 bg-white rounded shadow-md space-y-4">
    <h2 className="text-lg font-semibold">Modal C</h2>
    <p className="text-sm opacity-80">Modal independente aberto a partir da página principal.</p>
    <Button label="Fechar C" theme={Themes.Secondary} size={Sizes.Small} onClick={onClose} />
  </div>
);

const ModalPage: React.FC = () => {
  // Top-level modals A & C
  // Modal A
  const [aContent, setAContent] = React.useState<React.ReactNode>(null);
  const modalA = useModal('demo-modal-a', { content: aContent, closeable: true });
  React.useEffect(() => {
    setAContent(<ModalAContent onClose={modalA.close} />);
  }, [modalA.close]);

  // Modal C (corrige uso antes de declarar)
  const [cContent, setCContent] = React.useState<React.ReactNode>(null);
  const modalC = useModal('demo-modal-c', { content: cContent, closeable: true });
  React.useEffect(() => {
    setCContent(<ModalCContent onClose={modalC.close} />);
  }, [modalC.close]);

  // Sem eventos globais: interações locais usam diretamente os métodos dos hooks.

  return (
    <div className="space-y-6">
      <h1 className="text-xl font-semibold">Demo de Modais</h1>
      <p className="text-sm opacity-80">Exemplos de abertura sequencial e aninhada usando o sistema de modais. A ordem e comportamento de fechamento/apertura demonstra a lógica do reducer.</p>
      <div className="flex flex-wrap gap-4">
        <Button label="Abrir Modal A" onClick={modalA.open} theme={Themes.Primary} size={Sizes.Medium} />
        <Button label="Abrir Modal C" onClick={modalC.open} theme={Themes.Tertiary} size={Sizes.Medium} />
      </div>
      <div className="text-xs opacity-70 space-y-2">
        <p><strong>Fluxo:</strong> Abrir A, dentro dele abrir B. Fechar B retorna a A. Abrir C enquanto A aberto fecha A e abre C (fila/pending).</p>
        <p><strong>Nota:</strong> Este exemplo usa eventos globais simples para demonstrar fechamento; em produção use callbacks diretos ou contexto adicional.</p>
      </div>
    </div>
  );
};

export default ModalPage;
