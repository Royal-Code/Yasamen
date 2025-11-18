import React from 'react';
import { Button } from '../../lib/components/button';
import { Sizes, Themes } from '../../lib/components/commons';
import Modal, { type ModalHandler } from '../../lib/components/modal/Modal';

// Conteúdo do Modal B
const ModalBContent: React.FC<{ onClose: () => void }> = ({ onClose }) => (
  <div className="p-6 bg-white rounded shadow-md space-y-4">
    <h2 className="text-lg font-semibold">Modal B (Aninhado)</h2>
    <p className="text-sm opacity-80">Aberto de dentro do Modal A. Feche para retornar ao A.</p>
    <Button label="Fechar B" theme={Themes.Alert} size={Sizes.Small} onClick={onClose} />
  </div>
);

// Conteúdo do Modal A (abre Modal B via handler)
const ModalAContent: React.FC<{ onClose: () => void; openB: () => void; }> = (
  { onClose, openB }) => (
  <div className="p-6 bg-white rounded shadow-md space-y-4">
    <h2 className="text-lg font-semibold">Modal A</h2>
    <p className="text-sm opacity-80">Demonstra nesting: abre Modal B e mantém stack.</p>
    <div className="flex gap-3 flex-wrap">
      <Button label="Abrir Modal B" onClick={openB} theme={Themes.Primary} size={Sizes.Small} />
      <Button label="Fechar A" onClick={onClose} theme={Themes.Secondary} size={Sizes.Small} />
    </div>
  </div>
);

const ModalCContent: React.FC<{ onClose: () => void }> = ({ onClose }) => (
  <div className="p-6 bg-white rounded shadow-md space-y-4">
    <h2 className="text-lg font-semibold">Modal C</h2>
    <p className="text-sm opacity-80">Modal independente aberto a partir da página principal.</p>
    <Button label="Fechar C" theme={Themes.Secondary} size={Sizes.Small} onClick={onClose} />
  </div>
);

const ModalPage: React.FC = () => {
  // Handlers para controlar modais via API do componente
  const modalAHandler = React.useRef<ModalHandler>({ open: () => {}, close: () => {} });
  const modalBHandler = React.useRef<ModalHandler>({ open: () => {}, close: () => {} });
  const modalCHandler = React.useRef<ModalHandler>({ open: () => {}, close: () => {} });

  return (
    <div className="space-y-6">
      <h1 className="text-xl font-semibold">Demo de Modais</h1>
      <p className="text-sm opacity-80">Exemplos de abertura sequencial e aninhada usando o novo componente Modal com stack e fases.</p>
      <div className="flex flex-wrap gap-4">
        <Button label="Abrir Modal A" onClick={() => modalAHandler.current.open()} theme={Themes.Primary} size={Sizes.Medium} />
        <Button label="Abrir Modal C" onClick={() => modalCHandler.current.open()} theme={Themes.Tertiary} size={Sizes.Medium} />
      </div>
      <div className="text-xs opacity-70 space-y-2">
        <p><strong>Fluxo:</strong> Abrir A, dentro dele abrir B. Fechar B retorna a A. Abrir C enquanto A aberto fecha A e abre C (fila).</p>
        <p><strong>Nota:</strong> Agora usando <code>Modal</code> diretamente em vez de hook <code>useModal</code>.</p>
      </div>

      {/* Modais montados (sempre presentes, controlados por handlers) */}
      <Modal id="demo-modal-a" handler={modalAHandler.current}>
        <ModalAContent
          onClose={() => modalAHandler.current.close()}
          openB={() => modalBHandler.current.open()}
        />
      </Modal>
      <Modal id="demo-modal-b" closeable={false} handler={modalBHandler.current} center>
        <ModalBContent onClose={() => modalBHandler.current.close()} />
      </Modal>
      <Modal id="demo-modal-c" handler={modalCHandler.current} center>
        <ModalCContent onClose={() => modalCHandler.current.close()} />
      </Modal>
    </div>
  );
};

export default ModalPage;
