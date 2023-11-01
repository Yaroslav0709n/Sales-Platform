import React, { useContext, useEffect, useState } from 'react';
import { UserContext } from '../../UserContext';
import { useNavigate } from 'react-router';
import {
	Headers,

} from './Header.elements';
import axios from 'axios';

const Header: React.FC = () => {
  const { userId } = useContext(UserContext);
  const [firstName, setFirstName] = useState(localStorage.getItem('firstName') || '');
  const [lastName, setLastName] = useState(localStorage.getItem('lastName') || '');
  
  const navigate = useNavigate();

  useEffect(() => {
    if (userId) {
      localStorage.setItem('firstName', firstName);
      localStorage.setItem('lastName', lastName);
    }
  }, [userId, firstName, lastName]);
  
  const handleLogout = async () => {
    try {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('firstName');
        localStorage.removeItem('lastName');
        navigate('/login');
      } catch (error) {
        console.error('Error during logout', error);
      }
  };

  
  return (
    <Headers>
        <h1>Sales Platform</h1>
        <div>{`${firstName} ${lastName}`}</div>
        <button onClick={handleLogout}>
            Logout
        </button>
    </Headers>
  );
};

export default Header;