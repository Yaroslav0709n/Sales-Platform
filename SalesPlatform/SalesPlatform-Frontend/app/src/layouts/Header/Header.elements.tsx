import styled from "styled-components";

export const Headers = styled.header`
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 16px;
    background-color: #2E8B57;
    font-weight: bold;
    color: white;
    height: 110px;
`;

export const Title = styled.h1`
    margin-top: 10px;
    text-align: center;
`;

export const Navigation = styled.nav`
  ul {
    font-size: 18px;
    list-style: none;
    padding: 0;
    display: flex;
  }

  li {
    margin-right: 20px;
  }

  a {
    text-decoration: none;
    color: white;
  }
`;

export const UserInfo = styled.div`
  display: flex;
  align-items: center;
`;

export const UserName = styled.p`
    font-size: 18px;
  margin: 0;
  margin-right: 10px;
`;

export const Button = styled.button`
    height: 40px;
    background-color: #a72828;
    color: white;
    border: none;
    padding: 8px 16px;
    border-radius: 50px;
    cursor: pointer;
    font-size: 16px;
`;