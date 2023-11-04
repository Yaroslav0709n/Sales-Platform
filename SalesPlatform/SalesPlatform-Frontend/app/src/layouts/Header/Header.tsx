import React, { useContext, useEffect, useState } from 'react';
import { UserContext } from '../../UserContext';
import { Link, useNavigate } from 'react-router-dom';
import styles from './Header.module.css'
import {
	Headers,
  Navigation,
  Title,
  UserInfo,
  UserName,
  Button,

} from './Header.elements';

const Header: React.FC = () => {
  const { userId } = useContext(UserContext);
  const [firstName, setFirstName] = useState(localStorage.getItem('firstName') || '');
  const [lastName, setLastName] = useState(localStorage.getItem('lastName') || '');
  const navigate = useNavigate();
  const [showSubMenu, setShowSubMenu] = useState(false);

  const toggleSubMenu = () => {
    setShowSubMenu(!showSubMenu);
  };

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
        <Title>Sales Platform</Title>
        <Navigation>
          <ul>
          <li onMouseEnter={toggleSubMenu} onMouseLeave={toggleSubMenu}>
            <Link to="/items">Advertisements</Link>
            {showSubMenu && (
              <ul className={styles.submenu}>
                <li className={styles.submenu__list}>
                  <Link to="/useritems">My Advertisements</Link>
                </li>
                <li className={styles.submenu__list}>
                  <Link to="/createitem">Create Advertisements</Link>
                </li>
              </ul>
            )}
          </li>
            <li>
              <Link to="/profile">Profile</Link>
            </li>
            <li>
              <Link to="/favourites">Favourites</Link>
            </li>
          </ul>
        </Navigation>
        <UserInfo>
          <UserName>{`${firstName} ${lastName}`}</UserName>
          <Button onClick={handleLogout}>
            Logout
          </Button>
        </UserInfo>
    </Headers>
  );
};

export default Header;