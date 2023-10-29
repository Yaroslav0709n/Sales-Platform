import React from 'react';
import { BrowserRouter as Router, Routes, Route, useLocation } from 'react-router-dom';

import LoginForm from './pages/Login/LoginForms'
import { UserProvider } from './UserContext';

const App: React.FC = () => {
  return (
    <Router>
      <AppRoutes />
    </Router>
  );
};

const AppRoutes: React.FC = () => {
  // const showHeader = location.pathname !== '/registration' && location.pathname !== '/login' && location.pathname !== '/';

  return (
    <UserProvider>
    <div className='mainContainer'>
      {/* {showHeader && <Header />}
      {showHeader && <Sidebar />} */}
      <Routes>
        <Route path="/" element={<LoginForm />} />
      </Routes>
    </div>
  </UserProvider>
  );
};

export default App;
