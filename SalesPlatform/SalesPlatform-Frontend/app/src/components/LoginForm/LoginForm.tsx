import React, { useContext, useState } from 'react';
import axios from 'axios';
import styles from './LoginForm.module.css';
import { Link, useNavigate } from 'react-router-dom';
import { UserContext } from '../../UserContext';
import EnterInput from '../../shared/Inputs/EnterInput/EnterInput'
import SubmitButton from '../../shared/Buttons/SubmitButton'

const LoginForm: React.FC = () => {
    const navigate = useNavigate(); 
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { setUserId } = useContext(UserContext);

    const handleLogin = async (event: React.FormEvent<HTMLFormElement>) => {
      event.preventDefault();

      try {
        const response = await axios.post('https://localhost:44301/api/Auth/login', {
          email,
          password,
        });

        const token = response.data.token.replace(/"/g, '')
        localStorage.setItem('accessToken', token);

        setUserId(response.data.id);
        localStorage.setItem('firstName', response.data.firstName);
        localStorage.setItem('lastName', response.data.lastName);

        console.log('Success', response.data);
        navigate('/items')
      } catch (error) {
         console.error('Error', error);
      }
    };


    return (
      <div className={styles.login}>
        <form className={styles.login__form}>
          <h2>Log In</h2>
          <div className={styles["login__form-control"]}>
            <label>
                Email
            </label>
            <EnterInput
                value={email}
                type="text"
                onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div className={styles["login__form-control"]}>
            <label>
                Password
            </label>
            <EnterInput 
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <SubmitButton className={styles["login__form-button"]} type='submit' onClick={(e:any) => handleLogin(e)}>Log In</SubmitButton>
          <div className={styles["login__form-link"]}>
            <Link to="/registration">I don't have an account</Link>
          </div>
        </form>
      </div>
    );
  };
  
export default LoginForm;