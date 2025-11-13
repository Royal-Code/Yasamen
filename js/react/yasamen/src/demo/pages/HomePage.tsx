import { useState } from 'react';
import reactLogo from '../assets/react.svg';
import viteLogo from '/vite.svg';
import Button from '../../lib/components/button/Button';
import { Sizes } from '../../lib/components/commons';

const HomePage: React.FC = () => {
  const [count, setCount] = useState(0);

  return (
    <div>
      <div className="flex gap-4 mb-4">
        <a href="https://vite.dev" target="_blank" rel="noopener noreferrer">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank" rel="noopener noreferrer">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1 className="mb-2">Yasamen Demo</h1>
      <p className="mb-4 text-sm opacity-80">Página inicial contendo o demo básico do React + Vite.</p>
      <div className="card mb-6">
        <Button label={`Count is ${count}`} onClick={() => setCount(count + 1)} outline size={Sizes.Large} />
        <p className="mt-4">
          Edite <code>src/demo/pages/HomePage.tsx</code> e salve para testar HMR.
        </p>
      </div>
      <p className="read-the-docs text-xs opacity-60">
        Clique nos logos para saber mais.
      </p>
    </div>
  );
};

export default HomePage;
