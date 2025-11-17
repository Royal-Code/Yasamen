import React from 'react';
import { Routes, Route } from 'react-router-dom';
import './App.css';
import HomePage from './pages/HomePage';
import ButtonsPage from './pages/ButtonsPage';
import IconButtonsPage from './pages/IconButtonsPage';
import IconsPage from './pages/IconsPage';
import StackPage from './pages/StackPage';
import LayoutPage from './pages/LayoutPage';
import SectionPage from './pages/SectionPage';
import BarPage from './pages/BarPage';
import ModalPage from './pages/ModalPage';
import DemoMainLayout from './layout/DemoMainLayout';
import { Status404 } from '../lib/components/status';


const App: React.FC = () => (
  <Routes>
    <Route element={<DemoMainLayout />}>
      <Route path="/" element={<HomePage />} />
      <Route path="/buttons" element={<ButtonsPage />} />
      <Route path="/icon-buttons" element={<IconButtonsPage />} />
      <Route path="/icons" element={<IconsPage />} />
      <Route path="/stack" element={<StackPage />} />
      <Route path="/layout" element={<LayoutPage />} />
      <Route path="/section" element={<SectionPage />} />
      <Route path="/bar" element={<BarPage />} />
      <Route path="/modal" element={<ModalPage />} />
    </Route>
    <Route element={<DemoMainLayout />}>
      <Route path="*" element={<Status404 />} />
    </Route>
  </Routes>
);

export default App;
