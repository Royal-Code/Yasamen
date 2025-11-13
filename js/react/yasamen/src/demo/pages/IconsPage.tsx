import React, { useState, useMemo } from 'react';
import Icon from '../../lib/components/icon/Icon';
import { WellKnownIcons } from '../../lib/components/icon/well-known-icons';

const allIcons = Object.values(WellKnownIcons);

const IconsPage: React.FC = () => {
  const [filter, setFilter] = useState('');
  const [customName, setCustomName] = useState('');

  const filtered = useMemo(() => {
    return allIcons.filter(n => n.toLowerCase().includes(filter.toLowerCase()));
  }, [filter]);

  return (
    <div className="icons-page">
      <h2 className="mb-2">Icon</h2>
      <p className="mb-4 text-sm opacity-80 max-w-prose">
        O componente <code>Icon</code> renderiza ícones usando um registry configurável. Nesta demo usamos <code>setBootstrapIcons()</code> para mapear nomes conhecidos para ícones do Bootstrap.\n
        Você pode filtrar a lista de ícones conhecidos ou testar um nome custom (caso exista no set Bootstrap).
      </p>

      <div className="flex flex-wrap gap-4 mb-6 text-sm">
        <label className="flex items-center gap-2">
          Filtro:
          <input
            value={filter}
            onChange={e => setFilter(e.target.value)}
            placeholder="filtrar..."
            className="border px-2 py-1 text-xs"
          />
        </label>
        <label className="flex items-center gap-2">
          Ícone custom:
          <input
            value={customName}
            onChange={e => setCustomName(e.target.value)}
            placeholder="ex: plus-circle"
            className="border px-2 py-1 text-xs"
          />
        </label>
      </div>

      {customName && (
        <div className="mb-8">
          <h3 className="text-sm mb-2 opacity-70">Custom</h3>
          <div className="flex items-center gap-3 p-3 border rounded-md">
            <Icon name={customName} className="text-2xl" />
            <code>{customName}</code>
          </div>
        </div>
      )}

      <h3 className="text-sm mb-2 opacity-70">Well Known Icons ({filtered.length})</h3>
      <div className="grid sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-6 gap-4">
        {filtered.map(name => (
          <div key={name} className="flex flex-col items-center gap-2 p-3 border rounded-md text-center">
            <Icon name={name} className="text-xl" aria-hidden="true" />
            <code className="text-xs break-all">{name}</code>
          </div>
        ))}
        {filtered.length === 0 && <p className="text-xs opacity-60">Nenhum ícone encontrado.</p>}
      </div>
    </div>
  );
};

export default IconsPage;
