import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import styles from './RegisterForm.module.css';
import EnterInput from '../../shared/Inputs/EnterInput/EnterInput'
import SubmitButton from '../../shared/Buttons/SubmitButton'

 
const RegisterForm: React.FC = () => {
    const navigate = useNavigate(); 
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [city, setCity] = useState('');
    const [password, setPassword] = useState('');

    const handleRegister = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            const response = await axios.post('https://localhost:44301/api/Auth/register',  {
                firstName,
                lastName,
                email,
                phoneNumber,
                city,
                password,
              });

            console.log('Success', response.data);
            navigate('/login')
        } catch (error) {
            console.error('Error registration', error);
        }
    };

    return (
        <div className={styles.register}>
            <form className={styles.register__form}>
                <h2>Sign Up</h2>
                <div className={styles["register__form-control"]}>
                    <label>
                        First Name
                    </label>
                    <EnterInput
                        type="text"
                        value={firstName}
                        onChange={(e) => setFirstName(e.target.value)}
                    />
                </div>
                <div className={styles["register__form-control"]}>
                    <label>
                        Last Name
                    </label>
                    <EnterInput
                        type="text"
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                    />
                </div>
                <div className={styles["register__form-control"]}>
                    <label>
                        Email
                    </label>
                    <EnterInput
                        type="text"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div className={styles["register__form-control"]}>
                    <label>
                        Phone
                    </label>
                    <EnterInput
                        type="text"
                        value={phoneNumber}
                        onChange={(e) => setPhoneNumber(e.target.value)}
                    />
                </div>
                <div className={styles["register__form-control"]}>
                    <label>
                        City
                    </label>
                    <EnterInput
                        type="text"
                        value={city}
                        onChange={(e) => setCity(e.target.value)}
                    />
                </div>
                <div className={styles["register__form-control"]}>
                    <label>
                        Password
                    </label>
                    <EnterInput
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <SubmitButton className={styles["register__form-button"]} type='submit' onClick={(e:any) => handleRegister(e)}>Sign Up</SubmitButton>
                <div className={styles["register__form-link"]}>
                    <Link to="/login">I already have an account</Link>
                </div>
            </form>
        </div>
    );
  };
  
  export default RegisterForm;