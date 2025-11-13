import React from 'react';
import { Bar } from '../../lib/components/layouts';

const BarPage: React.FC = () => {
  return (
    <div className="bar-page">
      <h2 className="mb-2">Bar (Compound)</h2>
      <p className="mb-4 text-sm opacity-80 max-w-prose">
        Demonstração do padrão <code>compound component</code> usando o util <code>createSlot</code> e a função <code>pickSlots</code>.\n
        O componente <code>Bar</code> expõe slots <code>Start</code>, <code>Middle</code> e <code>End</code>. Última ocorrência de um slot vence.
      </p>

      <h3 className="mb-2 text-sm opacity-70">Completo</h3>
      <Bar className="mb-4 p-3 border rounded-md bg-primary-50">
        <Bar.Start><span className="text-xs">Left content</span></Bar.Start>
        <Bar.Center><strong className="text-sm">Center title</strong></Bar.Center>
        <Bar.End><button className="text-xs underline">Action</button></Bar.End>
      </Bar>

      <h3 className="mb-2 text-sm opacity-70">Sem Middle</h3>
      <Bar className="mb-4 p-3 border rounded-md bg-secondary-50">
        <Bar.Start><span className="text-xs">Start only</span></Bar.Start>
        <Bar.End><span className="text-xs">End info</span></Bar.End>
      </Bar>

      <h3 className="mb-2 text-sm opacity-70">Apenas Start</h3>
      <Bar className="mb-4 p-3 border rounded-md bg-info-50">
        <Bar.Start><span className="text-xs">Single slot</span></Bar.Start>
      </Bar>

      <h3 className="mb-2 text-sm opacity-70">Override (último ganha)</h3>
      <Bar className="mb-4 p-3 border rounded-md bg-warning-50">
        <Bar.Start><span className="text-xs">First start</span></Bar.Start>
        <Bar.Start><span className="text-xs">Second start overrides</span></Bar.Start>
        <Bar.End><span className="text-xs">First end</span></Bar.End>
        <Bar.End><span className="text-xs">Final end overrides</span></Bar.End>
      </Bar>

      <h3 className="mb-2 text-sm opacity-70">Com classes adicionais</h3>
      <Bar className="mb-4 p-3 border rounded-md bg-success-100">
        <Bar.Start><span className="text-xs">Extra classes</span></Bar.Start>
        <Bar.Center>
          <span className="text-xs bg-danger-100 mr-2">Mixing className + additional</span>
          <span className="text-xs bg-alert-100 ml-2">Mixing className + additional</span>
        </Bar.Center>
        <Bar.End><span className="text-xs">Done</span></Bar.End>
      </Bar>
    </div>
  );
};

export default BarPage;