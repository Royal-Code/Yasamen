import React from 'react';
import { Routes, Route, Link, useLocation } from 'react-router-dom';
import './App.css';
import HomePage from './pages/HomePage';
import ButtonsPage from './pages/ButtonsPage';
import IconButtonsPage from './pages/IconButtonsPage';
import IconsPage from './pages/IconsPage';
import StackPage from './pages/StackPage';
import LayoutPage from './pages/LayoutPage';
import BarPage from './pages/BarPage';

// Componente de navegação simples
function Nav() {
  const location = useLocation();
  const linkClass = (path: string) => `px-3 py-2 text-sm rounded ${location.pathname === path 
    ? 'bg-primary-500 text-white hover:bg-primary-700 hover:text-primary-100' 
    : 'hover:bg-primary-100'}`;
  return (
    <nav className="flex flex-wrap gap-2 mb-6">
      <Link to="/" className={linkClass('/')}>Home</Link>
      <Link to="/buttons" className={linkClass('/buttons')}>Buttons</Link>
      <Link to="/icon-buttons" className={linkClass('/icon-buttons')}>IconButtons</Link>
      <Link to="/icons" className={linkClass('/icons')}>Icons</Link>
      <Link to="/stack" className={linkClass('/stack')}>Stack</Link>
      <Link to="/layout" className={linkClass('/layout')}>Layout</Link>
      <Link to="/bar" className={linkClass('/bar')}>Bar</Link>
    </nav>
  );
}

const App: React.FC = () => {
  return (
    <div className="p-6 max-w-7xl mx-auto">
      <Nav />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/buttons" element={<ButtonsPage />} />
        <Route path="/icon-buttons" element={<IconButtonsPage />} />
        <Route path="/icons" element={<IconsPage />} />
        <Route path="/stack" element={<StackPage />} />
        <Route path="/layout" element={<LayoutPage />} />
        <Route path="/bar" element={<BarPage />} />
      </Routes>
    </div>
  );
};

export default App;
