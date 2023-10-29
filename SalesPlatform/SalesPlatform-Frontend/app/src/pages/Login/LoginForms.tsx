import React, { useState } from 'react';
import axios from 'axios';
import styles from '../../assets/componentsstyle/login.module.css';

const Login: React.FC = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:44301/api/Auth/login', {
        email,
        password,
      });

      console.log('Success', response.data);
    } catch (error) {
       console.error('Error', error);
    }
  };

  return (
    <form className={styles.container}>
        <h2>Login</h2>
        <input
        type="text"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />
      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button onClick={handleLogin}>Войти</button>
    </form>
  );
};

export default Login;