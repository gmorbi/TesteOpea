import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Empresas from './components/Empresas/Empresas';

const App = () => {
  return (
    <Router>
        <Routes>
          <Route exact path="/" element={<Empresas/>}/>
        </Routes>
    </Router>
  );
};

export default App;
