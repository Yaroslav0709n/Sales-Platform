import React, { useContext, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { UserContext } from '../../UserContext';
import axios from 'axios';
import {
	  Label,
    Form,
    Input,
    Button,
    LinkContainer
} from './LoginForm.elements';


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
      <div style={{background: "#483D8B", height: "100vh"}}>
        <Form>
          <h2>Log In</h2>
          <Label>
              Email
          </Label>
          <Input
              type="text"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
          />
          <Label>
              Password
          </Label>
          <Input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
          />
          <Button onClick={(e:any) => handleLogin(e)}>Log In</Button>
          <LinkContainer>
              <Link to="/registration">I don't have an account</Link>
          </LinkContainer>
        </Form>
      </div>
    );
  };
  
  export default LoginForm;