import React, { useState } from 'react';
import Stack from '../../lib/components/layouts/Stack';
import { Orientations, Sizes, ContentJustify } from '../../lib/components/commons';

const gapValues = Object.values(Sizes);
const justifyValues = Object.values(ContentJustify);

function DemoBox({ label }: { label: string }) {
  return <div className="px-3 py-2 rounded bg-primary-500 text-white text-xs">{label}</div>;
}

const StackPage: React.FC = () => {
  const [orientation, setOrientation] = useState(Orientations.Vertical);
  const [gap, setGap] = useState(Sizes.Medium);
  const [justify, setJustify] = useState(ContentJustify.Start);

  return (
    <div className="stack-page">
      <h2 className="mb-2">Stack</h2>
      <p className="mb-4 text-sm opacity-80 max-w-prose">
        O componente <code>Stack</code> organiza elementos em linha ou coluna com controle de espaçamento (<code>gap</code>) e alinhamento (<code>justify</code>).\n
        Utilize os selects para alterar dinamicamente as propriedades e observar o resultado.
      </p>

      <div className="flex flex-wrap gap-4 mb-8 text-sm">
        <label className="flex items-center gap-2">
          Orientação:
          <select value={orientation} onChange={e => setOrientation(e.target.value)} className="border px-2 py-1 text-xs">
            {Object.values(Orientations).map(o => <option key={o}>{o}</option>)}
          </select>
        </label>
        <label className="flex items-center gap-2">
          Gap:
          <select value={gap} onChange={e => setGap(e.target.value)} className="border px-2 py-1 text-xs">
            {gapValues.map(g => <option key={g}>{g}</option>)}
          </select>
        </label>
        <label className="flex items-center gap-2">
          Justify:
          <select value={justify} onChange={e => setJustify(e.target.value)} className="border px-2 py-1 text-xs">
            {justifyValues.map(j => <option key={j}>{j}</option>)}
          </select>
        </label>
      </div>

      <div className="mb-10 p-4 border rounded-md">
        <Stack orientation={orientation} gap={gap} justify={justify}>
          <DemoBox label="Item 1" />
          <DemoBox label="Item 2" />
          <DemoBox label="Item 3" />
          <DemoBox label="Item 4" />
        </Stack>
      </div>

      <h3 className="mb-2">Gaps Disponíveis</h3>
      <p className="mb-4 text-xs opacity-70">Visualização rápida de cada gap com orientação fixa horizontal.</p>
      <div className="space-y-6 mb-12">
        {gapValues.map(g => (
          <div key={g} className="p-3 border rounded-md">
            <p className="text-xs mb-2 opacity-60">gap = {g}</p>
            <Stack orientation={Orientations.Horizontal} gap={g} justify={ContentJustify.Start}>
              <DemoBox label="A" />
              <DemoBox label="B" />
              <DemoBox label="C" />
            </Stack>
          </div>
        ))}
      </div>

      <h3 className="mb-2">Justify</h3>
      <p className="mb-4 text-xs opacity-70">Exemplos principais de alinhamento em horizontal.</p>
      <div className="grid md:grid-cols-2 gap-6">
        {[ContentJustify.Start, ContentJustify.Center, ContentJustify.End, ContentJustify.Between, ContentJustify.Around, ContentJustify.Evenly].map(j => (
          <div key={j} className="p-3 border rounded-md">
            <p className="text-xs mb-2 opacity-60">justify = {j}</p>
            <Stack orientation={Orientations.Horizontal} gap={Sizes.Small} justify={j}>
              <DemoBox label="1" />
              <DemoBox label="2" />
              <DemoBox label="3" />
            </Stack>
          </div>
        ))}
      </div>
    </div>
  );
};

export default StackPage;
