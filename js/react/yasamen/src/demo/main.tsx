import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import './index.css';
import App from './App.tsx';
import { BootstrapIconsProvider } from '../lib/components/bsicons/set-bootstrap-icons.ts';
import { ReactRouterNavigatorProvider } from '../lib/utils/react-router-navigation.ts';

// Icon mapping now initialized inside BootstrapIconsProvider; no direct call here.

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <BrowserRouter>
      <BootstrapIconsProvider />
      <ReactRouterNavigatorProvider />
      <App />
    </BrowserRouter>
  </StrictMode>
);
