import React from 'react';
import { BrowserRouter as Router, Routes, Route, useLocation } from 'react-router-dom';
import './assets/global.css'
import Header from './components/Header/Header'
import LoginPage from './pages/Login/LoginPage'
import RegisterPage from './pages/Register/RegisterPage'
import ItemsPage from './pages/Items/ItemsPage'
import { UserProvider } from './UserContext';

const App: React.FC = () => {
  return (
    <Router>
      <AppRoutes />
    </Router>
  );
};

const AppRoutes: React.FC = () => {
  const location = useLocation();
  const showHeader = location.pathname !== '/registration' && location.pathname !== '/login' && location.pathname !== '/';

  return (
    <UserProvider>
      <div>
        {showHeader && <Header />}
        <Routes>
          <Route path="/" element={<LoginPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/registration" element={<RegisterPage />} />
          <Route path="/items" element={<ItemsPage />} />
        </Routes>
      </div>
    </UserProvider>
  );
};

export default App;
