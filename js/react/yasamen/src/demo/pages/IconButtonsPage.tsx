import React, { useState } from 'react';
import IconButton from '../../lib/components/button/IconButton';
import { Themes, Sizes } from '../../lib/components/commons';
import { WellKnownIcons } from '../../lib/components/icon/well-known-icons';
import { BsIcons } from '../../lib/components/bsicons';

const themeValues = Object.values(Themes);
const sizeValues = Object.values(Sizes);

const IconButtonsPage: React.FC = () => {
  const [active, setActive] = useState(false);
  const [disabled, setDisabled] = useState(false);
  const [iconName, setIconName] = useState(WellKnownIcons.Add);

  return (
    <div className="icon-buttons-page">
      <h2 className="mb-2">IconButton</h2>
      <p className="mb-4 text-sm opacity-80 max-w-prose">
        O componente <code>IconButton</code> é uma variação compacta contendo apenas ícone. Suporta tema, tamanho, estados ativo e disabled e versão outline.
      </p>

      <div className="flex gap-6 mb-6 text-sm">
        <label className="flex items-center gap-1">
          <input type="checkbox" checked={active} onChange={e => setActive(e.target.checked)} /> active
        </label>
        <label className="flex items-center gap-1">
          <input type="checkbox" checked={disabled} onChange={e => setDisabled(e.target.checked)} /> disabled
        </label>
        <label className="flex items-center gap-2">
          Ícone:
          <select value={iconName} onChange={e => setIconName(e.target.value)} className="border px-1 py-0.5 text-xs">
            {Object.values(BsIcons).map(v => (
              <option key={v} value={v}>{v}</option>
            ))}
          </select>
        </label>
      </div>

      <h3 className="mb-2">Sem Outline</h3>
      <div className="overflow-auto mb-10">
        <table className="min-w-full border text-sm border-collapse">
          <thead>
            <tr>
              <th className="border px-2 py-1 text-left">Tamanho / Tema</th>
              {themeValues.map(t => (
                <th key={t} className="border px-2 py-1">{t}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {sizeValues.map(sz => (
              <tr key={sz}>
                <td className="border px-2 py-1 font-medium">{sz}</td>
                {themeValues.map(theme => (
                  <td key={theme} className="border px-2 py-1">
                    <IconButton
                      icon={iconName}
                      theme={theme}
                      size={sz}
                      active={active}
                      disabled={disabled}
                    />
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <h3 className="mb-2">Com Outline</h3>
      <div className="overflow-auto mb-10">
        <table className="min-w-full border text-sm border-collapse">
          <thead>
            <tr>
              <th className="border px-2 py-1 text-left">Tamanho / Tema</th>
              {themeValues.map(t => (
                <th key={t} className="border px-2 py-1">{t}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {sizeValues.map(sz => (
              <tr key={sz}>
                <td className="border px-2 py-1 font-medium">{sz}</td>
                {themeValues.map(theme => (
                  <td key={theme} className="border px-2 py-1">
                    <IconButton
                      icon={iconName}
                      theme={theme}
                      size={sz}
                      outline
                      active={active}
                      disabled={disabled}
                    />
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <h3 className="mb-2">Navegação</h3>
      <p className="mb-4 text-xs opacity-70">Exemplo usando navigateTo para ir à página de Botões.</p>
      <IconButton
        icon={WellKnownIcons.Menu}
        theme={Themes.Info}
        size={Sizes.Large}
        active={active}
        disabled={disabled}
        navigateTo="/buttons"
        aria-label="Ir para Botões"
      />
    </div>
  );
};

export default IconButtonsPage;
