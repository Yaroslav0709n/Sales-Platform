import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import {
	Label,
    Form,
    Input,
    Button,
    LinkContainer
} from './RegisterForm.element';


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
        <div style={{background: "#483D8B", height: "100vh"}}>
            <Form>
                <h2>Sign Up</h2>
                <Label>
                    First Name
                </Label>
                <Input
                    type="text"
                    value={firstName}
                    onChange={(e) => setFirstName(e.target.value)}
                />
                <Label>
                    Last Name
                </Label>
                <Input
                    type="text"
                    value={lastName}
                    onChange={(e) => setLastName(e.target.value)}
                />
                <Label>
                    Email
                </Label>
                <Input
                    type="text"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <Label>
                    Phone
                </Label>
                <Input
                    type="text"
                    value={phoneNumber}
                    onChange={(e) => setPhoneNumber(e.target.value)}
                />
                <Label>
                    City
                </Label>
                <Input
                    type="text"
                    value={city}
                    onChange={(e) => setCity(e.target.value)}
                />
                <Label>
                    Password
                </Label>
                <Input
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <Button onClick={(e:any) => handleRegister(e)}>Sign Up</Button>
                <LinkContainer>
                    <Link to="/login">I already have an account</Link>
                </LinkContainer>
            </Form>
        </div>
    );
  };
  
  export default RegisterForm;