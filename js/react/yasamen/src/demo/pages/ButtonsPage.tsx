import React, { useState } from 'react';
import Button from '../../lib/components/button/Button';
import { Themes, Sizes, Positions } from '../../lib/components/commons';
import { WellKnownIcons } from '../../lib/components/icon/well-known-icons';

const themeValues = Object.values(Themes);
const sizeValues = Object.values(Sizes);

const ButtonsPage: React.FC = () => {
  const [outline, setOutline] = useState(false);
  const [active, setActive] = useState(false);
  const [disabled, setDisabled] = useState(false);

  return (
    <div className="buttons-page">
      <h2 className="mb-2">Button</h2>
      <p className="mb-4 text-sm opacity-80 max-w-prose">
        O componente <code>Button</code> representa um botão estilizado com suporte a tema, tamanho, ícone opcional, estado ativo, variante outline e navegação integrada via <code>navigateTo</code>.\n
        A tabela abaixo mostra combinações de temas (colunas) e tamanhos (linhas). Use os checkboxes para alternar estados.
      </p>

      <div className="flex gap-6 mb-6 text-sm">
        <label className="flex items-center gap-1">
          <input type="checkbox" checked={outline} onChange={e => setOutline(e.target.checked)} /> outline
        </label>
        <label className="flex items-center gap-1">
          <input type="checkbox" checked={active} onChange={e => setActive(e.target.checked)} /> active
        </label>
        <label className="flex items-center gap-1">
          <input type="checkbox" checked={disabled} onChange={e => setDisabled(e.target.checked)} /> disabled
        </label>
      </div>

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
                    <Button
                      label={theme}
                      theme={theme}
                      size={sz}
                      outline={outline}
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

      <h3 className="mb-2">Variações com Ícones</h3>
      <div className="grid md:grid-cols-2 gap-6 mb-12">
        <div>
          <p className="mb-2 text-xs uppercase opacity-60">Ícone na esquerda</p>
          {themeValues.slice(0,5).map(theme => (
            <div key={theme} className="mb-2">
              <Button
                label={`Add (${theme})`}
                theme={theme}
                size={Sizes.Medium}
                outline={outline}
                active={active}
                disabled={disabled}
                icon={WellKnownIcons.Add}
                iconPosition={Positions.Start}
              />
            </div>
          ))}
        </div>
        <div>
          <p className="mb-2 text-xs uppercase opacity-60">Ícone na direita</p>
          {themeValues.slice(5,10).map(theme => (
            <div key={theme} className="mb-2">
              <Button
                label={`Save (${theme})`}
                theme={theme}
                size={Sizes.Medium}
                outline={outline}
                active={active}
                disabled={disabled}
                icon={WellKnownIcons.Save}
                iconPosition={Positions.End}
              />
            </div>
          ))}
        </div>
      </div>

      <h3 className="mb-2">Bloco / Navegação</h3>
      <p className="mb-4 text-xs opacity-70">Exemplo usando <code>block</code> e <code>navigateTo</code> (usa o registry configurado via <code>useSetupReactRouterNavigator</code>).</p>
      <div className="max-w-sm">
        <Button
          label="Ir para Ícones"
          theme={Themes.Info}
          size={Sizes.Large}
          outline={outline}
          active={active}
          disabled={disabled}
          icon={WellKnownIcons.Search}
          iconPosition={Positions.Start}
          block
          navigateTo="/icons"
        />
      </div>
    </div>
  );
};

export default ButtonsPage;
