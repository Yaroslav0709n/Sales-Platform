import styled from 'styled-components';

export const Form = styled.form`
    max-width: 400px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 4px;
    background-color: #f2f2f2;

    h2 {
        text-align: center;
        margin-bottom: 20px;
      }

`;

export const Input = styled.input`
    width: 95%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
    margin-bottom: 10px;
`;

export const Label = styled.label`
    margin-bottom: "10px";
	font-size: 16px;
    display: block;
`;

export const Button = styled.button`
    transition: 0.3s; 
    color: #fff;
    border: none;
    border-radius: 4px; 
    font-size: 12px;
    cursor: pointer; 
    margin-bottom: 10px;
    padding: 10px 20px;
    background: #007bff;
    text-align: center;

    :hover{
        background: #0055af;
    }
`;

export const LinkContainer = styled.div`
    margin-top: 10px;
    text-align: center;
`;